using System.Collections.Immutable;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

MSBuildLocator.RegisterDefaults();

const string projectPath =
	@"D:\Repository\postgres-marula\src\Postgres.Marula.DatabaseAccess\Postgres.Marula.DatabaseAccess.csproj";

using var workspace = MSBuildWorkspace.Create();
var project = await workspace.OpenProjectAsync(projectPath);
// var projectCompilation = await project.GetCompilationAsync();

foreach (var document in project.Documents)
{
	var syntaxRoot = await document.GetSyntaxRootAsync();
	var syntaxTree = await document.GetSyntaxTreeAsync();

	var semanticModel = await document.GetSemanticModelAsync();

	var methodInvocations = syntaxRoot
		.DescendantNodes()
		.OfType<InvocationExpressionSyntax>()
		.ToImmutableArray();
}