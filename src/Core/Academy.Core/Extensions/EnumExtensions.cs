using System.Reflection;
using System.ComponentModel.DataAnnotations;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());

        if (field == null) return value.ToString();

        var attribute = field.GetCustomAttribute<DisplayAttribute>();

        return attribute?.Name ?? value.ToString();
    }
}