import com.jetbrains.rd.generator.gradle.RdGenExtension
import org.jetbrains.kotlin.daemon.common.toHexString

// Some build script code borrowed from F# and T4 plugins

buildscript {
  repositories {
    maven { setUrl("https://cache-redirector.jetbrains.com/www.myget.org/F/rd-snapshots/maven") }
    mavenCentral()
  }
  dependencies {
    classpath("com.jetbrains.rd:rd-gen:0.203.161")
  }
}

plugins {
  id("org.jetbrains.intellij") version "0.4.26"
  kotlin("jvm") version "1.4.10"
  id("me.filippov.gradle.jvm.wrapper") version "0.9.3"
}

apply {
  plugin("kotlin")
  plugin("com.jetbrains.rdgen")
}

repositories {
  mavenCentral()
}

dependencies {
  implementation(kotlin("stdlib"))
  implementation(kotlin("reflect"))
}

java {
  sourceCompatibility = JavaVersion.VERSION_1_8
  targetCompatibility = JavaVersion.VERSION_1_8
}

val baseVersion = "2020.3"
version = baseVersion

intellij {
  type = "RD"
  version = "$baseVersion-SNAPSHOT"
  instrumentCode = false
  downloadSources = false
  updateSinceUntilBuild = false
  // Workaround for https://youtrack.jetbrains.com/issue/IDEA-179607
  setPlugins("rider-plugins-appender")
}

val repoRoot = projectDir.parentFile!!

configure<RdGenExtension> {
  val hostOutput = File(repoRoot, "EnvDTE.Host/Protocol")
  val clientOutput = File(repoRoot, "EnvDTE.Client/Protocol")

  verbose = true
  hashFolder = "build/rdgen"
  classpath({
    val sdkPath = intellij.ideaDependency.classes
    val rdLibDirectory = File(sdkPath, "lib/rd").canonicalFile
    "$rdLibDirectory/rider-model.jar"
  })
  sources(File(repoRoot, "Protocol/src/main/kotlin/model"))
  packages = "model"

  generator {
    language = "csharp"
    transform = "asis"
    root = "model.DteRoot"
    namespace = "JetBrains.Rider.Model"
    directory = "$clientOutput"
  }

  generator {
    language = "csharp"
    transform = "reversed"
    root = "model.DteRoot"
    namespace = "JetBrains.Rider.Model"
    directory = "$hostOutput"
  }
}

val dotNetSdkPath by lazy {
  val sdkPath = intellij.ideaDependency.classes.resolve("lib").resolve("DotNetSdkForRdPlugins")
  if (sdkPath.isDirectory.not()) error("$sdkPath does not exist or not a directory")

  println("SDK path: $sdkPath")
  return@lazy sdkPath
}

val nugetConfigPath = File(repoRoot, "NuGet.Config")
val dotNetSdkPathPropsPath = File("build", "DotNetSdkPath.generated.props")

fun File.writeTextIfChanged(content: String) {
  val bytes = content.toByteArray()
  if (exists() && readBytes().toHexString() == bytes.toHexString()) return
  writeBytes(bytes)
}

tasks {
  create("writeDotNetSdkPathProps") {
    doLast {
      dotNetSdkPathPropsPath.writeTextIfChanged("""<Project>
  <PropertyGroup>
    <DotNetSdkPath>$dotNetSdkPath</DotNetSdkPath>
  </PropertyGroup>
</Project>
"""
      )
    }
  }
  create("writeNuGetConfig") {
    doLast {
      nugetConfigPath.writeTextIfChanged(
        """<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="resharper-sdk" value="$dotNetSdkPath" />
  </packageSources>
</configuration>
"""
      )
    }
  }
  create("prepare") {
    dependsOn("writeDotNetSdkPathProps", "writeNuGetConfig", "rdgen")
  }
}

defaultTasks("prepare")
