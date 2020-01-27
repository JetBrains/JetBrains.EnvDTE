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

./build.ps1
$code = $LastExitCode
Write-Host "Nuke build finished: $code"
if ($code -ne 0) { throw "Error: unable to build project: Nuke exit code $code" }