import com.jetbrains.plugin.structure.base.utils.isFile
import org.jetbrains.intellij.platform.gradle.Constants
import kotlin.io.path.absolute
import kotlin.io.path.isDirectory


plugins {
    alias(libs.plugins.gradleIntelliJPlatform)
    alias(libs.plugins.kotlinJvm)
    alias(libs.plugins.changelog)

    alias(libs.plugins.gradleJvmWrapper)
    id("com.jetbrains.rdgen") version libs.versions.rdGen
}

dependencies {
    implementation(libs.rdGen)
    intellijPlatform {
        rider(libs.versions.riderSdk) {
            useInstaller = false
        }
    }
    implementation(libs.kotlinStdLib)
}

repositories {
    mavenCentral()
}

version = libs.versions.riderSdk

intellijPlatform {
    instrumentCode = false
}

val repoRoot = projectDir.parentFile!!

rdgen {
    val hostOutput = File(repoRoot, "EnvDTE.Host/Protocol")
    val clientOutput = File(repoRoot, "EnvDTE.Client/Protocol")

    verbose = true
    hashFolder = "build/rdgen"
    sources(File(projectDir, "src/main/kotlin/model"))
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
    val sdkPath = intellijPlatform.platformPath.resolve("lib/DotNetSdkForRdPlugins").absolute()
    if (!sdkPath.isDirectory()) error("$sdkPath does not exist or not a directory")

    println("SDK path: $sdkPath")
    return@lazy sdkPath
}

tasks {
    val generateDotNetSdkProperties by registering {
        val dotNetSdkPathPropsPath = File("build", "DotNetSdkPath.generated.props")
        doLast {
            dotNetSdkPathPropsPath.writeTextIfChanged(
                """<Project>
  <PropertyGroup>
    <DotNetSdkPath>$dotNetSdkPath</DotNetSdkPath>
  </PropertyGroup>
</Project>
"""
            )
        }
    }
    val generateNuGetConfig by registering {
        val nuGetConfigFile = File(repoRoot, "NuGet.Config")
        doLast {
            nuGetConfigFile.writeTextIfChanged(
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

    val rdGen = ":protocol:rdgen"

    register("prepare") {
        dependsOn(rdGen, generateDotNetSdkProperties, generateNuGetConfig)
    }
}

defaultTasks("prepare")


val riderModel: Configuration by configurations.creating {
    isCanBeConsumed = true
    isCanBeResolved = false
}

artifacts {
    add(riderModel.name, provider {
        intellijPlatform.platformPath.resolve("lib/rd/rider-model.jar").also {
            check(it.isFile) {
                "rider-model.jar is not found at $riderModel"
            }
        }
    }) {
        builtBy(Constants.Tasks.INITIALIZE_INTELLIJ_PLATFORM_PLUGIN)
    }
}

fun File.writeTextIfChanged(content: String) {
    val bytes = content.toByteArray()

    if (!exists() || !readBytes().contentEquals(bytes)) {
        println("Writing $path")
        parentFile.mkdirs()
        writeBytes(bytes)
    }
}
