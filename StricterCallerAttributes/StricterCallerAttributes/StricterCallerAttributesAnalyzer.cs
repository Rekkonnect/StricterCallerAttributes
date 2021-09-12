using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;
using RoseLynn.Analyzers;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StricterCallerAttributes
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class StricterCallerAttributesAnalyzer : CSharpDiagnosticAnalyzer
    {
        protected override DiagnosticDescriptorStorageBase DiagnosticDescriptorStorage => CALDiagnosticDescriptorStorage.Instance;

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();

            context.RegisterOperationAction(AnalyzeInvocation, OperationKind.Invocation);
        }

        private static void AnalyzeInvocation(OperationAnalysisContext context)
        {
            var invocationOperation = context.Operation as IInvocationOperation;

            var method = invocationOperation.TargetMethod;
            var arguments = invocationOperation.Arguments;
            foreach (var argument in arguments)
            {
                if (argument.ArgumentKind is not ArgumentKind.Explicit)
                    continue;

                var parameter = argument.Parameter;
                if (parameter is null)
                    continue;

                var callerAttribute = parameter.GetAttributes().FirstOrDefault(IsCallerAttribute);
                if (callerAttribute is not null)
                    context.ReportDiagnostic(Diagnostics.CreateCAL0001(argument.Syntax, callerAttribute));
            }
        }

        private static readonly string callerAttributeNamespace = typeof(CallerFilePathAttribute).Namespace;

        private static bool IsCallerAttribute(AttributeData attribute)
        {
            var attributeClass = attribute.AttributeClass;
            return attributeClass.ContainingNamespace.ToDisplayString() == callerAttributeNamespace
                && attributeClass.Name.StartsWith("Caller");
        }
    }
}
