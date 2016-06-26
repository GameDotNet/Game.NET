# packages to publish
$packages = Get-ChildItem ..\**\*.nupkg

# publish function
function Publish($package) {
    Push-AppveyorArtifact $package.FullName -FileName $package.Name
}
write-host "Publishing started. Packages to publish:" $packages.Count

# Publish all packages
foreach ($package in $packages){
    write-host "Publishing " $package
    Publish($package)
}

# Set build as failed if any error occurred
if($LastExitCode -ne 0) { $host.SetShouldExit($LastExitCode )  }

write-host "Publishing finished"