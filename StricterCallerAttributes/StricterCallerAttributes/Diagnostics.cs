using Microsoft.CodeAnalysis;

namespace StricterCallerAttributes
{
    using static CALDiagnosticDescriptorStorage;

    public static class Diagnostics
    {
        public static Diagnostic CreateCAL0001(SyntaxNode argumentNode, AttributeData attribute)
        {
            return Diagnostic.Create(Instance[0001], argumentNode.GetLocation(), attribute.AttributeClass.Name);
        }
    }
}
