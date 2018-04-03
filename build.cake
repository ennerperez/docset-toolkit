#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define solutions.
var solutions = new Dictionary<string, string> {
     { "./src/ZDocs.sln", "Any" },
};

// Define AssemblyInfo source.
var assemblyInfoVersion = ParseAssemblyInfo("./src/.files/AssemblyInfo.Version.cs");
var assemblyInfoCommon = ParseAssemblyInfo("./src/.files/AssemblyInfo.Common.cs");

// Define version.
var elapsedSpan = new TimeSpan(DateTime.Now.Ticks - new DateTime(2001, 1, 1).Ticks);
var assemblyVersion = assemblyInfoVersion.AssemblyVersion.Replace("*", elapsedSpan.Ticks.ToString().Substring(4, 4));
var version = EnvironmentVariable("APPVEYOR_BUILD_VERSION") ?? Argument("version", assemblyVersion);

// Define directories.
var outputDirectory = "build/" + configuration;
var buildDir = Directory("../" + outputDirectory);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
	CleanDirectories("./**/bin");
    CleanDirectories("./**/obj");
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    foreach (var solution in solutions)
    {
        NuGetRestore(solution.Key);
    }
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    foreach (var solution in solutions)
    {
        if (IsRunningOnWindows())
        {
            var settings = new MSBuildSettings();
            // .WithProperty("PackageVersion", version)
            // .WithProperty("BuildSymbolsPackage", "false");
            settings.SetConfiguration(configuration);
            // Use MSBuild
            MSBuild(solution.Key, settings);
        }
        else
        {
            var settings = new XBuildSettings();
            // .WithProperty("PackageVersion", version)
            // .WithProperty("BuildSymbolsPackage", "false");
            settings.SetConfiguration(configuration);
            // Use XBuild
            XBuild(solution.Key, settings);
        }
    }
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    NUnit3("./src/**/bin/" + configuration + "/*.Tests.dll", new NUnit3Settings {
        NoResults = true
        });
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Run-Unit-Tests");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
