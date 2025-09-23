import com.jetbrains.rd.generator.gradle.RdGenExtension
import org.jetbrains.kotlin.daemon.common.toHexString

// Some build script code borrowed from F# and T4 plugins

buildscript {
  repositories {
    maven { setUrl("https://packages.jetbrains.team/maven/p/ij/intellij-dependencies") }
    maven { setUrl("https://cache-redirector.jetbrains.com/maven-central") }
  }
  dependencies {
    // https://search.maven.org/artifact/com.jetbrains.rd/rd-gen
    classpath("com.jetbrains.rd:rd-gen:2025.2.2")
  }
}

plugins {
  id("org.jetbrains.intellij") version "1.13.3"
  id("org.jetbrains.kotlin.jvm") version "1.8.10"
  id("me.filippov.gradle.jvm.wrapper") version "0.15.0"
}

apply {
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

val baseVersion = "2025.1.4"
version = baseVersion

intellij {
  type.set("RD")
  version.set("$baseVersion")
  instrumentCode.set(false)
  downloadSources.set(false)
  updateSinceUntilBuild.set(false)
  // Workaround for https://youtrack.jetbrains.com/issue/IDEA-179607
  plugins.set(listOf("rider-plugins-appender"))
}

val repoRoot = projectDir.parentFile!!

configure<RdGenExtension> {
  val hostOutput = File(repoRoot, "EnvDTE.Host/Protocol")
  val clientOutput = File(repoRoot, "EnvDTE.Client/Protocol")

  verbose = true
  hashFolder = "build/rdgen"
  classpath({
    val sdkPath = tasks.setupDependencies.get().idea.get().classes
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
  val sdkPath = tasks.setupDependencies.get().idea.get().classes.resolve("lib").resolve("DotNetSdkForRdPlugins")
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
  wrapper {
    gradleVersion = "8.1.1"
    distributionType = Wrapper.DistributionType.ALL
  }

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
