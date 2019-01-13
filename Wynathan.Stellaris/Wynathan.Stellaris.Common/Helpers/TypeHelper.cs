using System;

namespace Wynathan.Stellaris.Common.Helpers
{
    public static class TypeHelper
    {
        public static object Convert(string value, Type targetType)
        {
            var actualType = Nullable.GetUnderlyingType(targetType);
            if (actualType == null)
                actualType = targetType;

            if (actualType.IsEnum)
                return Enum.Parse(actualType, value, true);

            return System.Convert.ChangeType(value, actualType);
        }
    }
}
