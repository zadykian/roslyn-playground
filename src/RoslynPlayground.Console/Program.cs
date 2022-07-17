

using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

const string projectPath =
	"/Users/zadykian/Repository" +
	"/skipp-mobile-park/mobile-park/demo-origin/MP.Locator.MTS.Audit/MP.Locator.MTS.Audit.csproj";

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