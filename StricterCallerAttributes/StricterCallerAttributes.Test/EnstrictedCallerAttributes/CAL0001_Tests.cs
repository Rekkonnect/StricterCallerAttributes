using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StricterCallerAttributes.Test.EnstrictedCallerAttributes
{
    [TestClass]
    public sealed class CAL0001_Tests : StricterCallerAttributesAnalyzerDiagnosticTests
    {
        [TestMethod]
        public void OptionalParameterSubstitution()
        {
            var testCode =
@"
class C
{
    void Example()
    {
        CallerAttributeFunctions.Function(↓""file path"", ↓69);
    }
}
";

            AssertDiagnosticsWithUsings(testCode);
        }
        [TestMethod]
        public void NormalFunctionOptionalParameterSubstitution()
        {
            var testCode =
@"
class C
{
    void Example()
    {
        CallerAttributeFunctions.NormalFunctionWithFilePath(1, 2, 3, ↓""file path"");
    }
}
";

            AssertDiagnosticsWithUsings(testCode);
        }
    }
}
