using MichelMichels.CliSharp.Attributes;
using System;
using System.Reflection;

namespace MichelMichels.CliSharp.Extensions;

public static class EnumExtensions
{
    public static string ToFriendlyString(this Enum enumeration)
    {
        Type enumType = enumeration.GetType();
        MemberInfo[] memberInfo = enumType.GetMember(enumeration.ToString());

        if (memberInfo is not null && memberInfo.Length > 0)
        {
            object[] attrs = memberInfo[0].GetCustomAttributes(typeof(ParameterName), false);
            if (attrs is not null && attrs.Length > 0)
            {
                return ((ParameterName)attrs[0]).Name;
            }
        }

        return enumeration.ToString();
    }
}
