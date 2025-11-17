param(
    [switch]$EnableBinLog,
    [ValidateSet('Debug','Release')][string]$Configuration = 'Debug'
)

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

function Build-Project {
    param(
        [Parameter(Mandatory)][string]$Project
    )

    if ($EnableBinLog) {
        $binLogArg = "/bl:$($Project)_log.binlog"
    }
    else {
        $binLogArg = $null
    }

    & .\dotnet.cmd build $binLogArg "/p:Configuration=$Configuration" $Project

    if ($LASTEXITCODE -ne 0) {
        throw "Could not build $Project (exit code $LASTEXITCODE)"
    }
}


function Pack-Project {
    param(
        [Parameter(Mandatory)][string]$Project
    )

    if ($EnableBinLog) {
        $binLogArg = "/bl:$($Project)_log.binlog"
    }
    else {
        $binLogArg = $null
    }

    & .\dotnet.cmd pack $binLogArg "/p:Configuration=$Configuration" $Project

    if ($LASTEXITCODE -ne 0) {
        throw "Could not pack $Project (exit code $LASTEXITCODE)"
    }
}

Write-Host "Building EnvDTE.Processor"

Build-Project -Project 'EnvDTE.Processor'

Write-Host "Building projects (Configuration=$Configuration, BinLog=$($EnableBinLog.IsPresent))"

Build-Project -Project 'EnvDTE100.Interfaces'
Build-Project -Project 'Shell.Interop'
Build-Project -Project 'Designer.Interfaces'
Build-Project -Project 'EnvDTE.Host'
Build-Project -Project 'EnvDTE.Client'
Build-Project -Project 'VisualStudio.Interop.Interfaces'

Write-Host "Packing interfaces"

Pack-Project -Project 'EnvDTE100.Interfaces'
