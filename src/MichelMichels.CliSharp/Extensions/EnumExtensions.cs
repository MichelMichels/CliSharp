using MichelMichels.CliSharp.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace MichelMichels.CliSharp.Extensions;

public static class EnumExtensions
{
    public static string ToFriendlyString(this Enum enumeration)
    {
        FieldInfo? field = enumeration.GetType().GetField(enumeration.ToString());
        if (field is null)
        {
            return enumeration.ToString();
        }

        ParameterNameAttribute? attribute = field.GetCustomAttributes(typeof(ParameterNameAttribute), false).FirstOrDefault() as ParameterNameAttribute;

        return attribute?.Name ?? enumeration.ToString();
    }
}
