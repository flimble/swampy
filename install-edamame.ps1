$base = (resolve-path .)

$nuget_dir = resolve-path '.\.nuget\'
$nuget = join-path $nuget_dir 'nuget.exe'
$packages_config = join-path $nuget_dir 'packages.config'
$output_dir = join-path $base 'packages'
& $nuget install $packages_config -OutputDirectory $output_dir -source 'http://nuget.saig.frd.global/nuget/'

$packages_dir = join-path $base 'packages'
$edamame_dir = (get-childitem $packages_dir edamame* | select-object -last 1).fullname
$edamame_path = join-path $edamame_dir 'tools\edamame.psm1'
Import-Module ($edamame_path) -DisableNameChecking -force 