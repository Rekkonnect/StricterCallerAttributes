using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoseLynn;
using RoseLynn.CSharp.Syntax;
using System.Collections.Generic;
using System.Composition;
using System.Threading;
using System.Threading.Tasks;

namespace StricterCallerAttributes
{
    using static CALDiagnosticDescriptorStorage;

    [Shared]
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ArgumentRemover))]
    public sealed class ArgumentRemover : CALCodeFixProvider
    {
        protected override IEnumerable<DiagnosticDescriptor> FixableDiagnosticDescriptors => new DiagnosticDescriptor[]
        {
            Instance[0001]
        };

        protected override Task<Document> PerformCodeFixActionAsync(CodeFixContext context, SyntaxNode syntaxNode, CancellationToken cancellationToken)
        {
            var document = context.Document;
            var argumentNode = syntaxNode as ArgumentSyntax;
            var argumentListNode = argumentNode.GetNearestParentOfType<ArgumentListSyntax>();
            var newArgumentList = argumentListNode.Arguments.Remove(argumentNode);
            return document.ReplaceNodeAsync(argumentListNode, argumentListNode.WithArguments(newArgumentList));
        }
    }
}
