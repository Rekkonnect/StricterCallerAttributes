using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoseLynn.Analyzers;
using RoseLynn.Testing;
using System.Threading.Tasks;

namespace StricterCallerAttributes.Test
{
    public abstract class BaseCodeFixTests<TAnalyzer, TCodeFix> : BaseCodeFixDiagnosticTests<TAnalyzer, TCodeFix>
        where TAnalyzer : DiagnosticAnalyzer, new()
        where TCodeFix : CALCodeFixProvider, new()
    {
        protected sealed override DiagnosticDescriptorStorageBase DiagnosticDescriptorStorage => CALDiagnosticDescriptorStorage.Instance;

        protected sealed override async Task VerifyCodeFixAsync(string markupCode, string expected, int codeActionIndex)
        {
            await CSharpCodeFixVerifier<TAnalyzer, TCodeFix>.VerifyCodeFixAsync(markupCode, expected);
        }

        [TestMethod]
        public void TestExistingCodeFixName()
        {
            Assert.IsNotNull(new TCodeFix().CodeFixTitle);
        }
    }
}
