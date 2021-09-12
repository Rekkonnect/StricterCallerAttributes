using StricterCallerAttributes.Test.Helpers;

namespace StricterCallerAttributes.Test.EnstrictedCallerAttributes.CodeFixes
{
    public abstract class StricterCallerAttributesAnalyzerCodeFixTests<TCodeFix> : BaseCodeFixTests<StricterCallerAttributesAnalyzer, TCodeFix>
        where TCodeFix : CALCodeFixProvider, new()
    {
        public void TestCodeFixWithUsings(string markupCode, string expected, int codeActionIndex = 0)
        {
            TestCodeFix(CALUsingsProvider.Instance.WithUsings(markupCode), CALUsingsProvider.Instance.WithUsings(expected), codeActionIndex);
        }
    }
}
