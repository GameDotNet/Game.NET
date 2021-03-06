param (
    [Parameter(Mandatory=$true)][string]$version = 0
)

# projects to pack
$projects = @(
    "Src\Game.NET\Game.NET.csproj"
)

# pack function for project
function Pack($path) {
    nuget pack $path -Build -Properties Configuration=Release -Prop Platform=AnyCPU -Version $version
}

write-host "Packaging started"
# Pack each project
foreach ($project in $projects){
    write-host "Packing " $project "with suffix version " $version
    Pack($project)
}

# Set build as failed if any error occurred
if($LastExitCode -ne 0) { $host.SetShouldExit($LastExitCode )  }

write-host "Packaging finished"