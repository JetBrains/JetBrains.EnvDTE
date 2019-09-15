Push-Location -Path Protocol
Try {
    .\gradlew
    $code = $LastExitCode
    Write-Host "Gradle finished: $code"
    if ($code -ne 0) { throw "Error: Unable to generate protocole model: gradlew exit code $code" }
}
Finally {
    Pop-Location
}
& dotnet restore
$code = $LastExitCode
Write-Host "dotnet restore returned: $code"
if ($code -ne 0) { throw "Error: unable to restore packages: dotnet restore exit code $code" }

& "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
$code = $LastExitCode
Write-Host "msbuild finished: $code"
if ($code -ne 0) { throw "Error: unable to build project: msbuild exit code $code" }
