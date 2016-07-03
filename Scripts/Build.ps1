$version = "14.0"
$regKey = "HKLM:\software\Microsoft\MSBuild\ToolsVersions\$version"
$regProperty = "MSBuildToolsPath"

$msbuildExe = join-path -path (Get-ItemProperty $regKey).$regProperty -childpath "msbuild.exe"

# projects to pack
$projects = @(
    ".\Game.NET.sln"
)

# pack function for project
function Build($path) {
    &$msbuildExe $path
}

write-host "Packeging started"
foreach ($project in $projects){
    write-host "Building " $project
    Build($project)
}

# Set build as failed if any error occurred
if($LastExitCode -ne 0) { $host.SetShouldExit($LastExitCode )  }

write-host "Build finished"