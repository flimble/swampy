properties {
	$root_path  = resolve-path .
	$sln_file = 'Swampy.sln'
	$configuration = 'Debug'
	$build_dir = Join-Path $root_path 'build'
	$buildartifacts_dir = Join-Path $root_path 'buildartifacts'
	$release_dir = Join-Path $root_path 'release'
	$verbosity = 'quiet'
	$framework = '4.5'
	$nunit_exe = Join-Path $root_path 'packages\NUnit.Runners.2.6.2\tools\nunit-console-x86.exe'
	$unittest_assembly_filter = '*UnitTest*.dll'
	$integrationtest_assembly_filter = '*IntegrationTest*.dll'
	$sqltarget_server = "(local)"
}

$base = (resolve-path .)

$nuget_dir = resolve-path '.\.nuget\'
$nuget = join-path $nuget_dir 'nuget.exe'
$packages_config = join-path $nuget_dir 'packages.config'
$output_dir = join-path $base 'packages'
& $nuget install $packages_config -OutputDirectory $output_dir -source 'http://ausydhc-pspap12.saig.frd.global:81/nuget/'

$packages_dir = join-path $base 'packages'
$edamame_dir = (get-childitem $packages_dir edamame* | select-object -last 1).fullname
$edamame_path = join-path $edamame_dir 'tools\edamame.psm1'
Import-Module ($edamame_path) -DisableNameChecking -force 



TaskSetup {
    TeamCity-ReportBuildProgress "Running task $($psake.context.Peek().currentTaskName)"
}

task default -depends UnitTest 



task Clean {
	Remove-Item -force -recurse $build_dir -ErrorAction SilentlyContinue
	Remove-Item -force -recurse $release_dir -ErrorAction SilentlyContinue
	Remove-Item -force -recurse $buildartifacts_dir -ErrorAction SilentlyContinue
}

task Init -depends Clean, DownloadDependencies {

	Verify-Net-45-Installed
	
	
	New-Item $release_dir -itemType directory -ErrorAction SilentlyContinue | Out-Null
	New-Item $build_dir -itemType directory -ErrorAction SilentlyContinue | Out-Null
	New-Item $buildartifacts_dir -itemType directory -ErrorAction SilentlyContinue | Out-Null
}


task ConfigureRelease { 
	$configuration = 'Release'
	$build_dir = $release_dir
}

task Compile -depends Init {
	
	$v4_net_version = (ls "c:\windows\Microsoft.NET\Framework\v4.0*").Name
	
	try { 
		Write-Host "Compiling with '$configuration' configuration"
		exec { msbuild $sln_file "/p:OutDir=$build_dir" /p:Configuration=$configuration /verbosity:$verbosity  }
	} catch {
		Throw
	} finally { 
	}
}

task UnitTest -depends Compile {
	$unittest_assemblies = Get-ChildItem $build_dir -filter $unittest_assembly_filter

	Write-Host $unittest_assemblies
	$unittest_assemblies | ForEach-Object { 
		Write-Host "Testing $build_dir\$_"
		exec { &"$nunit_exe" "$build_dir\$_" "/xml=$buildartifacts_dir\Results.UnitTest.xml" }
	}
}

task IntegrationTest -depends Compile, UnitTest {
	$integrationtest_assemblies = Get-ChildItem $build_dir -filter $integrationtest_assembly_filter

	Write-Host $integrationtest_assemblies
	$integrationtest_assemblies | ForEach-Object { 
		Write-Host "Testing $build_dir\$_"
		exec { &"$nunit_exe" "$build_dir\$_" "/xml=$buildartifacts_dir\Results.IntegrationTest.xml" }
	}
}

task BuildDatabaseForTest { 
	Write-Host "db:Swampy, server:$sqltarget_server, environment:LOCAL, dropcreate:true"
	Roundhouse-Kick-Database -DatabaseName:"Swampy" -TargetServer:$sqltarget_server -Environment:"LOCAL" -DropCreate:$true
}

task DownloadDependencies {
	$packages_dir = Join-Path $root_path 'packages'

	Install-Nuget-Packages $packages_dir

}

