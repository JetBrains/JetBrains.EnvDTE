rootProject.name = "Protocol"

val propertiesFile = rootDir.resolve("local.properties")
if (propertiesFile.exists()) {
    val props = java.util.Properties()
    props.load(propertiesFile.inputStream())
    if (props.getProperty("gradle.offline") == "true") {
        gradle.startParameter.isOffline = true
    }
}

pluginManagement {
    repositories {
        gradlePluginPortal()
        mavenCentral()
    }
    resolutionStrategy {
        eachPlugin {
            if (requested.id.id == "com.jetbrains.rdgen") {
                useModule("com.jetbrains.rd:rd-gen:${requested.version}")
            }
        }
    }
}
