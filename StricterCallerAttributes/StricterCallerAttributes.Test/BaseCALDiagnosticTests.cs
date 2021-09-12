using Gu.Roslyn.Asserts;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoseLynn.Analyzers;
using RoseLynn.Testing;
using StricterCallerAttributes.Test.Helpers;

namespace StricterCallerAttributes.Test
{
    public abstract class BaseCALDiagnosticTests<TAnalyzer> : BaseCALDiagnosticTests
        where TAnalyzer : DiagnosticAnalyzer, new()
    {
        protected sealed override DiagnosticAnalyzer GetNewDiagnosticAnalyzerInstance() => new TAnalyzer();
    }

    public abstract class BaseCALDiagnosticTests : BaseDiagnosticTests
    {
        protected ExpectedDiagnostic ExpectedDiagnostic => ExpectedDiagnostic.Create(TestedDiagnosticRule);
        protected sealed override DiagnosticDescriptorStorageBase DiagnosticDescriptorStorage => CALDiagnosticDescriptorStorage.Instance;

        protected override UsingsProviderBase GetNewUsingsProviderInstance()
        {
            return CALUsingsProvider.Instance;
        }

        protected override void ValidateCode(string testCode)
        {
            RoslynAssert.Valid(GetNewDiagnosticAnalyzerInstance(), testCode);
        }
        protected override void AssertDiagnostics(string testCode)
        {
            RoslynAssert.Diagnostics(GetNewDiagnosticAnalyzerInstance(), ExpectedDiagnostic, testCode);
        }

        [TestMethod]
        public void EmptyCode()
        {
            ValidateCode(@"");
        }
        [TestMethod]
        public void EmptyCodeWithUsings()
        {
            ValidateCode(CALUsingsProvider.DefaultUsings);
        }
    }
}
