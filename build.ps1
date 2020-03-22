$packageVersion="0.1.1.2"

Push-Location -Path Protocol
Try {
    .\gradlew
    $code = $LastExitCode
    Write-Host "Gradle finished: $code"
    if ($code -ne 0) { throw "Error: Unable to generate protocol model: gradlew exit code $code" }
}
Finally {
    Pop-Location
}

dotnet build
$code = $LastExitCode
if ($code -ne 0) { throw "Could not build solution" }
$packages = @(
  "JetBrains.EnvDTE.Client.nuspec",
  "JetBrains.EnvDTE.Host.nuspec",
  "JetBrains.EnvDTE.nuspec",
  "JetBrains.EnvDTE80.nuspec",
  "JetBrains.EnvDTE90.nuspec",
  "JetBrains.EnvDTE90a.nuspec",
  "JetBrains.EnvDTE100.nuspec")

foreach ($package in $packages) {
    nuget pack ".\NuGet\$package" -BasePath . -OutputDirectory .\artifacts -Properties packageVersion=$packageVersion
    $code = $LastExitCode
    if ($code -ne 0) { throw "Could not pack $package" }
}