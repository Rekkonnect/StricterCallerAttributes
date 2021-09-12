using RoseLynn.CodeFixes;
using System.Resources;

namespace StricterCallerAttributes
{
    public abstract class CALCodeFixProvider : MultipleDiagnosticCodeFixProvider
    {
        protected sealed override ResourceManager ResourceManager => CodeFixResources.ResourceManager;
    }
}
