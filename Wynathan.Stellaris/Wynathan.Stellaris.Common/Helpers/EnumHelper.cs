using System;

namespace Wynathan.Stellaris.Common.Helpers
{
    public static class EnumHelper
    {
        public static bool IsEnumOrNullableEnum(Type type)
        {
            Type actualType;
            return IsEnumOrNullableEnum(type, out actualType);
        }

        public static bool IsEnumOrNullableEnum(Type type, out Type enumType)
        {
            enumType = GetEnumOrUnderlyingEnumType(type);
            return enumType != null;
        }

        public static Type GetEnumOrUnderlyingEnumType(Type type)
        {
            if (type == null)
                return null;

            if (type.IsEnum)
                return type;

            var actualType = Nullable.GetUnderlyingType(type);
            if (actualType == null)
                return null;

            return actualType.IsEnum ? actualType : null;
        }
    }
}
