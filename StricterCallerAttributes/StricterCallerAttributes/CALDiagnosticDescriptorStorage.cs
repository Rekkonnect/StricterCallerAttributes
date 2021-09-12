using Microsoft.CodeAnalysis;
using RoseLynn.Analyzers;
using System.Resources;

namespace StricterCallerAttributes
{
    internal sealed class CALDiagnosticDescriptorStorage : DiagnosticDescriptorStorageBase
    {
        public static readonly CALDiagnosticDescriptorStorage Instance = new();

        protected override string BaseRuleDocsURI => "https://github.com/AlFasGD/StricterCallerAttributes/blob/master/docs/rules";
        protected override string DiagnosticIDPrefix => "CAL";
        protected override ResourceManager ResourceManager => Resources.ResourceManager;

        #region Category Constants
        public const string APIRestrictionsCategory = "API Restrictions";
        #endregion

        #region Rules
        private CALDiagnosticDescriptorStorage()
        {
            SetDefaultDiagnosticAnalyzer<StricterCallerAttributesAnalyzer>();

            CreateDiagnosticDescriptor(0001, APIRestrictionsCategory, DiagnosticSeverity.Error);
        }
        #endregion
    }
}
