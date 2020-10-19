$dotNetSdkUrl = "https://download.visualstudio.microsoft.com/download/pr/f090672d-ffb0-4126-8154-68649cc55ad4/a09964d24b1bf583ad2f283f84c0a89c/dotnet-sdk-3.1.109-win-x64.zip"

$dotNetSdkPath = Join-Path $PSScriptRoot ".dotnet"
$progressPreference = 'SilentlyContinue'

if (!(Test-Path $dotNetSdkPath))
{
    $archivePath = Join-Path $Env:Temp "$(New-Guid).zip"
    $tempFolderPath = Join-Path $Env:Temp $(New-Guid)
    (New-Object System.Net.WebClient).DownloadFile($dotNetSdkUrl, $archivePath)
    New-Item $tempFolderPath -ItemType Directory
    Expand-Archive -Path $archivePath -DestinationPath $tempFolderPath
    Move-Item $tempFolderPath $dotNetSdkPath
    Remove-Item $archivePath
}

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

&"$dotNetSdkPath\dotnet.exe" pack /p:Configuration=Release "$PSScriptRoot\EnvDTE100.Interfaces\EnvDTE100.Interfaces.csproj"
$code = $LastExitCode
if ($code -ne 0) { throw "Could not build solution" }
