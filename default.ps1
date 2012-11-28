properties {
	$base_dir  = resolve-path .
	$lib_dir = "$base_dir\SharedLibs"
	$build_dir = "$base_dir\build"
	$buildartifacts_dir = "$build_dir\"
	$sln_file = "$base_dir\Swampy.sln"
	$version = "1.0"
	$tools_dir = "$base_dir\Tools"
	$release_dir = "$base_dir\Release"
	$configuration = "Debug"
	$unit_tests = @("Swampy.UnitTest.dll");
	$integration_tests = @("Swampy.IntegrationTest.dll");
}	
	
	

task default -depends Compile, UnitTest

task Verify40 {
	if( (ls "$env:windir\Microsoft.NET\Framework\v4.0*") -eq $null ) {
		throw "Building Raven requires .NET 4.0, which doesn't appear to be installed on this machine"
	}
}


task Clean {
	Remove-Item -force -recurse $buildartifacts_dir -ErrorAction SilentlyContinue
	Remove-Item -force -recurse $release_dir -ErrorAction SilentlyContinue
}

task Init -depends Verify40 


task Compile -depends Init {
	
	$v4_net_version = (ls "$env:windir\Microsoft.NET\Framework\v4.0*").Name
	
	
	try { 
		Write-Host "Compiling with '$configuration' configuration"
		exec { &"C:\Windows\Microsoft.NET\Framework\$v4_net_version\MSBuild.exe" "$sln_file" /p:OutputPath=$build_dir /p:Configuration=$configuration }
	} catch {
		Throw
	} finally { 
	}
}

task UnitTest -depends Compile {
	Write-Host $unit_tests
	$unit_tests | ForEach-Object { 
		Write-Host "Testing $build_dir\$_"
		exec { &"$base_dir\packages\NUnit.Runners.2.6.2\tools\nunit-console.exe" "$build_dir\$_" }
	}
}