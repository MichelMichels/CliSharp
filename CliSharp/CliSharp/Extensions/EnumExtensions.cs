using CliSharp.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CliSharp.Extensions
{
    public static class EnumExtensions
    {
        public static string ToFriendlyString(this Enum enumeration)
        {
            var enumType = enumeration.GetType();
            var memInfo = enumType.GetMember(enumeration.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(ParameterName), false);
                if (attrs != null && attrs.Length > 0)
                    return ((ParameterName)attrs[0]).Name;
            }

            return enumeration.ToString();
        }
    }
    
}
