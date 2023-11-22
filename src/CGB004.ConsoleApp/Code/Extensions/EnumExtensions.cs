using System.ComponentModel;
using System.Reflection;

namespace CGB004.ConsoleApp.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// Obtém o Decorator System.ComponentModel.Description do Enum ou o ToString().
    /// </summary>
    /// <param name="value">Enum.</param>
    /// <returns>Description.</returns>
    /// <typeparam name="TEnum">Tipo do Enum</typeparam>
    /// Rogério Siqueira
    public static string? GetDescriptionOrName<TEnum>(TEnum value)
    {
        _ = value ?? throw new ArgumentException(nameof(value));

        Type type = value.GetType();
        string? name = Enum.GetName(type, value);
        if (name != null)
        {
            FieldInfo? field = type.GetField(name);
            if (field != null)
            {
                // Se possuir o atributo Description, retornar descrição
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                    return attr.Description;
                
                // Caso não possua, retornar nome do atributo ToString().
                return name;
            }
        }
        return null;
    }
}
