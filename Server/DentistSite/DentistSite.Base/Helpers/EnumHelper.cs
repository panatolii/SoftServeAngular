using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace DentistSite.Base.Helpers
{
    public static class EnumHelper
    {
      

        public static IDictionary<int, string> GetDictionary(Type type)
        {
            return GetDictionary(type, c => true);
        }

        public static IDictionary<int, string> GetDictionary(Type type, Func<int, bool> predicate)
        {
            var dictionary = new Dictionary<int, string>();
            var keys = Enum.GetValues(type).Cast<int>();
            if (predicate != null)
                keys = keys.Where(predicate);
            foreach (var key in keys)
            {
                var @enum = (Enum)Enum.ToObject(type, key);
                dictionary.Add(key, GetDisplayName(@enum));
            }

            return dictionary;
        }

        



        public static string GetDisplayName(Enum @enum)
        {
            var type = @enum.GetType();
            var enumName = Enum.GetName(type, @enum);
            if (string.IsNullOrEmpty(enumName))
                return string.Empty;

            var field = type.GetField(enumName);
            var customAttribute = ((MemberInfo)field).GetCustomAttribute<DisplayAttribute>(false);
            if (customAttribute != null)
            {
                string name = customAttribute.GetName();
                if (!string.IsNullOrEmpty(name))
                    return name;
            }
            return field.Name;
        }

        public static string GetDescription(Enum @enum)
        {
            var type = @enum.GetType();
            var name = Enum.GetName(type, @enum);
            if (string.IsNullOrEmpty(name))
                return string.Empty;

            var field = type.GetField(name);
            if (field == null)
                return name;

            var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attr == null ? name : attr.Description;
        }

        public static T GetEnumValueFromDescription<T>(string description)
        {
            MemberInfo[] fis = typeof(T).GetFields();

            foreach (var fi in fis)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0 && attributes[0].Description == description)
                    return (T)Enum.Parse(typeof(T), fi.Name);
            }

            throw new Exception("Enum description attribute not found. EarthIntegrate.CmsSystem.Base.Helpers.EnumHelper - public static T GetEnumValueFromDescription<T>(string description)");
        }
    }
}
