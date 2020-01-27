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

msbuild
$code = $LastExitCode
Write-Host "msbuild finished: $code"
if ($code -ne 0) { throw "Error: unable to build project: msbuild exit code $code" }