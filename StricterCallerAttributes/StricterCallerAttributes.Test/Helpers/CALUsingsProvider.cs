using RoseLynn.Testing;

namespace StricterCallerAttributes.Test.Helpers
{
    public sealed class CALUsingsProvider : UsingsProviderBase
    {
        public static readonly CALUsingsProvider Instance = new();

        public const string DefaultUsings =
@"
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using StricterCallerAttributes.Test.Resources;
";

        public override string DefaultNecessaryUsings => DefaultUsings;

        private CALUsingsProvider() { }
    }
}
