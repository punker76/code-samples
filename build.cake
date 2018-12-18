
//////////////////////////////////////////////////////////////////////
// TOOLS / ADDINS
//////////////////////////////////////////////////////////////////////

#tool paket:?package=vswhere
#addin paket:?package=Cake.Git
#addin paket:?package=Cake.Figlet
#addin paket:?package=Cake.Paket

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
if (string.IsNullOrWhiteSpace(target))
{
    target = "Default";
}

var configuration = Argument("configuration", "Release");
if (string.IsNullOrWhiteSpace(configuration))
{
    configuration = "Release";
}

var verbosity = Argument("verbosity", Verbosity.Normal);
if (string.IsNullOrWhiteSpace(configuration))
{
    verbosity = Verbosity.Normal;
}

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var repoName = "code-samples";
var local = BuildSystem.IsLocalBuild;

var latestInstallationPath = VSWhereLatest(new VSWhereLatestSettings { IncludePrerelease = true });
var msBuildPath = latestInstallationPath?.CombineWithFilePath("./MSBuild/15.0/Bin/MSBuild.exe");
var msBuildCurrentPath = latestInstallationPath?.CombineWithFilePath("./MSBuild/Current/Bin/MSBuild.exe");

var gitBranch = GitBranchCurrent(".");
var branchName = gitBranch.FriendlyName;

var isDevelopBranch = StringComparer.OrdinalIgnoreCase.Equals("develop", branchName);
var isReleaseBranch = StringComparer.OrdinalIgnoreCase.Equals("master", branchName);

// Define global marcos.
Action Abort = () => { throw new Exception("a non-recoverable fatal error occurred."); };

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(context =>
{
    if (!IsRunningOnWindows())
    {
        throw new NotImplementedException($"{repoName} will only build on Windows because it's not possible to target WPF and Windows Forms from UNIX.");
    }

    if (FileExists(msBuildCurrentPath))
    {
    	msBuildPath = msBuildCurrentPath;
    }

    Information(Figlet(repoName));

    Information("IsLocalBuild           : {0}", local);
    Information("Branch                 : {0}", branchName);
    Information("Configuration          : {0}", configuration);
    Information("MSBuildPath            : {0}", msBuildPath);
});

Teardown(context =>
{
    // Executed AFTER the last task.
});

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("CleanOutput")
  .ContinueOnError()
  .Does(() =>
{
    var directoriesToDelete = GetDirectories("./**/obj").Concat(GetDirectories("./**/bin"));
    DeleteDirectories(directoriesToDelete, new DeleteDirectorySettings { Recursive = true, Force = true });
});

Task("Restore")
    .Does(() =>
{
    PaketRestore();

    // var msBuildSettings = new MSBuildSettings { ToolPath = msBuildPath, ArgumentCustomization = args => args.Append("/m") };
    // MSBuild(iconPacksSolution, msBuildSettings
    //         .SetConfiguration(configuration)
    //         .SetVerbosity(Verbosity.Minimal)
    //         .WithTarget("restore")
    //         );
});

Task("BuildAll")
  .Does(() =>
{
  var msBuildSettings = new MSBuildSettings { ToolPath = msBuildPath, ArgumentCustomization = args => args.Append("/m") };
  var solutions = GetFiles("./**/*.sln");

  foreach(var solution in solutions)
  {
    MSBuild(solution, msBuildSettings
      .SetMaxCpuCount(0)
      .SetConfiguration(configuration)
      .SetVerbosity(Verbosity.Normal)
    );
  }
});

// Task Targets
Task("Default")
    .IsDependentOn("CleanOutput")
    .IsDependentOn("Restore")
    .IsDependentOn("BuildAll");

// Execution
RunTarget(target);