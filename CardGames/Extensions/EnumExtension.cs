using System;
using System.ComponentModel;

namespace CardGames.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription<T>(this T source) where T : Enum
        {
            var field = source.GetType().GetField(source.ToString());

            if (field == null) return string.Empty;

            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }
    }
}
