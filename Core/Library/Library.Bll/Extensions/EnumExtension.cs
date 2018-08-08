using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace Library.Bll.Extensions
{
    public static class EnumExtension
    {
        public static string GetEnumDescription(this Enum value)
        {
            var displayAttribute = value.GetType()
                     .GetMember(value.ToString())
                     .FirstOrDefault()
                     ?.GetCustomAttribute<DisplayAttribute>();

            if (displayAttribute == null)
                return value.ToString();

            var resourceManager = new ResourceManager(displayAttribute.ResourceType);
            return resourceManager.GetString(displayAttribute.Name) ?? value.ToString();
        }
    }
}
