using System;
using System.Reflection;
using Wynathan.Stellaris.Common.Helpers;

namespace Wynathan.Stellaris.Common.Attributes
{
    public class CommonBindingAttribute : Attribute
    {
        public readonly string BoundName;

        public CommonBindingAttribute(string boundName)
        {
            this.BoundName = boundName;
        }

        public static string GetBindingName(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                return null;

            try
            {
                var attribute = propertyInfo.GetCustomAttribute<CommonBindingAttribute>(true);
                if (attribute == null)
                    return null;

                return attribute.BoundName;
            }
            catch
            {
                return null;
            }
        }

        public static string GetBindingName<TEnum>(string attributeValue)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return GetBindingNameFromEnum(typeof(TEnum), attributeValue);
        }

        public static string GetBindingNameFromEnum(Type enumType, string attributeValue)
        {
            return GetBindingNameFromEnum(ref enumType, attributeValue);
        }

        public static string GetBindingNameFromEnum(ref Type enumType, string attributeValue)
        {
            if (string.IsNullOrWhiteSpace(attributeValue))
                return null;

            enumType = EnumHelper.GetEnumOrUnderlyingEnumType(enumType);
            if (enumType == null)
                throw new ArgumentException("Invalid generic type. Expected enum.");

            var memberInfos = enumType.GetMembers(BindingFlags.Static | BindingFlags.Public);
            foreach (var memberInfo in memberInfos)
            {
                var attribute = memberInfo.GetCustomAttribute<CommonBindingAttribute>(true);
                if (attribute != null && attributeValue.Equals(attribute.BoundName, StringComparison.InvariantCultureIgnoreCase))
                    return memberInfo.Name;
            }

            return null;
        }

        public static bool TryGetBindingNameFromEnum(ref Type enumType, string attributeValue, out string enumName)
        {
            enumName = null;
            if (string.IsNullOrWhiteSpace(attributeValue))
                return false;

            enumType = EnumHelper.GetEnumOrUnderlyingEnumType(enumType);
            if (enumType == null)
                return false;

            var memberInfos = enumType.GetMembers(BindingFlags.Static | BindingFlags.Public);
            foreach (var memberInfo in memberInfos)
            {
                var attribute = memberInfo.GetCustomAttribute<CommonBindingAttribute>(true);
                if (attribute != null && attributeValue.Equals(attribute.BoundName, StringComparison.InvariantCultureIgnoreCase))
                {
                    enumName = memberInfo.Name;
                    return true;
                }
            }

            return false;
        }

        public static object GetEnumValueFromBindingName(Type enumType, string attributeValue)
        {
            string enumName;
            return TryGetBindingNameFromEnum(ref enumType, attributeValue, out enumName) && enumName != null 
                ? Enum.Parse(enumType, enumName, true)
                : null;
        }
    }
}
