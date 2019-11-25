using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;

namespace FileReaderController.Application.Helpers
{
    public static class EnumeratorHelper
    {
        public static string GetDescription(Enum enumValue)
        {
            Type enumType = enumValue.GetType();

            FieldInfo fieldInfo = enumType.GetField(enumValue.ToString());
            DescriptionAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false) as DescriptionAttribute[];

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            
            return default(T);
        }
    }
}