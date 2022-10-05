using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Serialization;

namespace DEVinCar.Domain.Enuns
{
    public enum Permissoes
    {
        [XmlEnumAttribute("V")]
        [Display(Name = "Vendedor")]
        Vendedor = 1,

        [XmlEnumAttribute("G")]
        [Display(Name = "Gerente")]
        Gerente,

        [XmlEnumAttribute("C")]
        [Display(Name = "Comprador")]
        Comprador
    }
}

public static class EnumExtensions
{
    public static string GetName(this Enum enumValue)
    {
        string displayName;
        displayName = enumValue.GetType()
          .GetMember(enumValue.ToString())
          .First()
          ?.GetCustomAttribute<DisplayAttribute>()
          ?.GetName();

        if (String.IsNullOrEmpty(displayName))
        {
            displayName = enumValue.ToString();
        }
        return displayName;
    }
}