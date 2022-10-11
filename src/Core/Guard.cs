using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Kotlin.NET.Core {
    public static class Guard {
        [
            MethodImpl(MethodImplOptions.AggressiveInlining),
            Conditional("DEBUG"),
            AssertionMethod
        ]
        public static void IsNotNull<T>([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] T value, string argument)
            where T : class {

            if(value == null)
                throw new ArgumentNullException(argument);
        }
        [
            MethodImpl(MethodImplOptions.AggressiveInlining),
            Conditional("DEBUG"),
            AssertionMethod
        ]
        public static void IsNotNullOrEmpty([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] string value, string argumentName) {
            if(value == null)
                throw new ArgumentNullException(argumentName);
            if(string.IsNullOrEmpty(value))
                throw new ArgumentException(argumentName);
        }
    }
}