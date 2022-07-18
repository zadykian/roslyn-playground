using System.Collections.Immutable;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

MSBuildLocator.RegisterDefaults();

const string projectPath =
	"/Users/zadykian/Repository/personal" +
	"/postgres-marula/src/Postgres.Marula.DatabaseAccess/Postgres.Marula.DatabaseAccess.csproj";

using var workspace = MSBuildWorkspace.Create();
var project = await workspace.OpenProjectAsync(projectPath);

static bool ContainsClassDeclaration(SyntaxNode documentSyntaxRoot, string className)
	=> documentSyntaxRoot
		.DescendantNodes()
		.OfType<ClassDeclarationSyntax>()
		.Any(classDeclaration => classDeclaration.Identifier.Text == className);

foreach (var document in project.Documents)
{
	var syntaxRoot = (await document.GetSyntaxRootAsync())!;
	if (!ContainsClassDeclaration(syntaxRoot, "DefaultDatabaseServer"))
	{
		continue;
	}

	var semanticModel = await document.GetSemanticModelAsync();
	
	var methodInvocations = syntaxRoot
		.DescendantNodes()
		.OfType<InvocationExpressionSyntax>()
		.ToImmutableArray();
}