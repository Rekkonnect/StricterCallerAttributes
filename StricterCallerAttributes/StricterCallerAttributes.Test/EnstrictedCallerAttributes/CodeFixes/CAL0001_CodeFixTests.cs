using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StricterCallerAttributes.Test.EnstrictedCallerAttributes.CodeFixes
{
    [TestClass]
    public class CAL0001_CodeFixTests : ArgumentRemoverCodeFixTests
    {
        [TestMethod]
        public void OptionalParameterSubstitutionCodeFix()
        {
            var testCode =
@"
class C
{
    void Example()
    {
        CallerAttributeFunctions.NormalFunctionWithFilePath(1, 2, 3, {|*:""file path""|});
    }
}
";

            var fixedCode =
@"
class C
{
    void Example()
    {
        CallerAttributeFunctions.NormalFunctionWithFilePath(1, 2, 3);
    }
}
";

            TestCodeFixWithUsings(testCode, fixedCode);
        }
    }
}
