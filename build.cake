#tool "nuget:?package=NUnit.ConsoleRunner"
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./src/ExpenseTracker.WebUI/bin/Debug/netcoreapp1.0");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() => {
    	DotNetCoreRestore("./");
	});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
	{
	    if(IsRunningOnWindows())
	    {
	    	DotNetCoreBuild(@"C:\Development\ExpenseTracker\ExpenseTracker.WebUI\src\ExpenseTracker.Tests");
	    	DotNetCoreBuild(@"C:\Development\ExpenseTracker\ExpenseTracker.WebUI\src\ExpenseTracker.WebUI");
	      // Use MSBuild
	      //MSBuild("./ExpenseTracker.WebUI.sln", settings =>
	      //  settings.SetConfiguration(configuration));
	    }
	    else
	    {
	      // Use XBuild
	      //XBuild("./ExpenseTracker.WebUI.sln", settings =>
	      //  settings.SetConfiguration(configuration));
	    }
	});

Task("RunTests")
	.IsDependentOn("Build")
	.Does(() => {
		StartAndReturnProcess("dotnet test ./src/expensetracker.tests");
	});

Task("Default")
	.IsDependentOn("RunTests");

RunTarget(target);