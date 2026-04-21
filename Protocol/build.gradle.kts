import com.jetbrains.plugin.structure.base.utils.isFile
import com.jetbrains.rd.generator.gradle.RdGenTask
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
    intellijPlatform {
        defaultRepositories()
    }
}

version = libs.versions.riderSdk

intellijPlatform {
    instrumentCode = false
}

val repoRoot: File = projectDir.parentFile

val modelRoot = "model.DteRoot"
val modelNamespace = "JetBrains.Rider.Model"

rdgen {
    val hostOutput = repoRoot.resolve("EnvDTE.Host/Protocol")
    val clientOutput = repoRoot.resolve("EnvDTE.Client/Protocol")

    verbose = true
    packages = "model"

    generator {
        language = "csharp"
        transform = "asis"
        root = modelRoot
        namespace = modelNamespace
        directory = "$clientOutput"
    }

    generator {
        language = "csharp"
        transform = "reversed"
        root = modelRoot
        namespace = modelNamespace
        directory = "$hostOutput"
    }
}

val riderSdkPath by lazy {
    val sdkPath = intellijPlatform.platformPath.resolve("lib/DotNetSdkForRdPlugins").absolute()
    if (!sdkPath.isDirectory()) error("$sdkPath does not exist or not a directory")

    println("Rider SDK path: $sdkPath")
    return@lazy sdkPath
}

tasks {
    val generateDotNetSdkProperties by registering {
        val dotNetSdkPathPropsPath = File("build", "DotNetSdkPath.generated.props")
        doLast {
            dotNetSdkPathPropsPath.writeTextIfChanged("""
                <Project>
                  <PropertyGroup>
                    <DotNetSdkPath>$riderSdkPath</DotNetSdkPath>
                  </PropertyGroup>
                </Project>
                """.trimIndent()
            )
        }
    }
    val generateNuGetConfig by registering {
        val nuGetConfigFile = repoRoot.resolve("NuGet.Config")
        doLast {
            nuGetConfigFile.writeTextIfChanged("""
                <?xml version="1.0" encoding="utf-8"?>
                <configuration>
                  <packageSources>
                    <add key="rider-sdk" value="$riderSdkPath" />
                  </packageSources>
                </configuration>
                """.trimIndent()
            )
        }
    }

    register("prepare") {
        dependsOn("rdgen", generateDotNetSdkProperties, generateNuGetConfig)
    }
}

tasks.withType<RdGenTask> {
    val classPath = sourceSets["main"].runtimeClasspath
    dependsOn(classPath)
    classpath(classPath)
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
