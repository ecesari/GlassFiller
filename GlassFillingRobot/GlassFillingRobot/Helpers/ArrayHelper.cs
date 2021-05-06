using System;
using System.Collections.Generic;
using System.Text;

namespace GlassFillingRobot.Helpers
{
    internal static class ArrayHelper
    {
        internal static int[] GetIntArrayByString(this string stringValue)
        {
            var intArray = Array.ConvertAll(stringValue.GetStringArrayByString(), int.Parse);
            return intArray;
        }

        internal static string[] GetStringArrayByString(this string stringValue)
        {
            var stringArray = stringValue.Split();
            return stringArray;
        }
    }
}
