using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

const string projectPath =
	"/Users/zadykian/Repository/personal" +
	"/postgres-marula/src/Postgres.Marula.DatabaseAccess/Postgres.Marula.DatabaseAccess.csproj";

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