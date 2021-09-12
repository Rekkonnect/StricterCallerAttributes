using System.Runtime.CompilerServices;

namespace StricterCallerAttributes.Test.Resources
{
    public static class CallerAttributeFunctions
    {
        public static void Function
        (
            [CallerFilePath]
            string filePath = default,
            [CallerLineNumber]
            int line = default,
            [CallerMemberName]
            string memberName = default
        )
        {
        }

        public static void NormalFunctionWithFilePath(int a, int b, int c, [CallerFilePath] string filePath = default) { }
    }
}
