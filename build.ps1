$progressPreference = 'SilentlyContinue'

./dotnet.cmd --version

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
$packageVersion = "1.0.0-preview1"
if ($Env:PackageVersion -ne "") {
    $packageVersion = $Env:PackageVersion
}

Write-Host "Building EnvDTE.Processor"

./dotnet.cmd build EnvDTE.Processor
$code = $LastExitCode
if ($code -ne 0) { throw "Could not build EnvDTE.Processor" }

Write-Host "Packing interfaces"

./dotnet.cmd pack /p:Configuration=Release "$PSScriptRoot\EnvDTE100.Interfaces\EnvDTE100.Interfaces.csproj"
$code = $LastExitCode
if ($code -ne 0) { throw "Could not pack interfaces" }
