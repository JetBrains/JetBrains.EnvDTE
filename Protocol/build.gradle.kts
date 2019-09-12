import com.jetbrains.rd.generator.gradle.RdgenParams
import org.gradle.api.tasks.testing.logging.TestExceptionFormat
import org.jetbrains.intellij.tasks.PrepareSandboxTask
import org.jetbrains.kotlin.daemon.common.toHexString
import org.jetbrains.kotlin.gradle.tasks.KotlinCompile

buildscript {
  repositories {
    maven { setUrl("https://cache-redirector.jetbrains.com/www.myget.org/F/rd-snapshots/maven") }
    maven { setUrl("https://cache-redirector.jetbrains.com/dl.bintray.com/kotlin/kotlin-eap") }
    mavenCentral()
  }
  dependencies {
    classpath("com.jetbrains.rd:rd-gen:0.192.36")
    classpath("org.jetbrains.kotlin:kotlin-gradle-plugin:1.3.31")
    classpath("org.jetbrains.kotlin:kotlin-reflect:1.3")
  }
}

plugins {
  id("org.jetbrains.intellij") version "0.4.9"
}

apply {
  plugin("kotlin")
  plugin("com.jetbrains.rdgen")
}

repositories {
  mavenCentral()
  maven { setUrl("https://cache-redirector.jetbrains.com/dl.bintray.com/kotlin/kotlin-eap") }
}

dependencies {
  implementation(kotlin("stdlib"))
  implementation(kotlin("reflect"))
}

java {
  sourceCompatibility = JavaVersion.VERSION_1_8
  targetCompatibility = JavaVersion.VERSION_1_8
}


val baseVersion = "2019.3"
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

configure<RdgenParams> {
  val hostOutput = File(repoRoot, "hostOutput")
  val clientOutput = File(repoRoot, "clientOutput")

  verbose = true
  hashFolder = "build/rdgen"
  logger.info("Configuring rdgen params")
  classpath({
    logger.info("Calculating classpath for rdgen, intellij.ideaDependency is ${intellij.ideaDependency}")
    val sdkPath = intellij.ideaDependency.classes
    val rdLibDirectory = File(sdkPath, "lib/rd").canonicalFile
    "$rdLibDirectory/rider-model.jar"
  })
  sources(File(repoRoot, "src/main/kotlin/model"))
  packages = "model"

  generator {
    language = "csharp"
    transform = "asis"
    root = "com.jetbrains.rider.model.nova.ide.IdeRoot"
    namespace = "com.jetbrains.rider.model"
    directory = "$clientOutput"
  }

  generator {
    language = "csharp"
    transform = "reversed"
    root = "com.jetbrains.rider.model.nova.ide.IdeRoot"
    namespace = "JetBrains.Rider.Model"
    directory = "$hostOutput"
  }
}
