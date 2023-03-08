using System.Text.RegularExpressions;

namespace Blogger.Extensions.Extensions;

public static class StringExtensions
{
    public static bool ContainsAny(this string theString, params string[] tokens)
    {
        return tokens.Any(theString.Contains);
    }

    public static bool EqualsAny(this string theString, params string[] tokens)
    {
        return tokens.Any(token => theString.Equals(token, StringComparison.InvariantCultureIgnoreCase));
    }

    public static Uri ToUri(this string url, UriKind kind = UriKind.RelativeOrAbsolute)
    {
        return new Uri(url, kind);
    }

    public static DateTime? ToDate(this string theString, DateTime? defaultDate = null)
    {
        DateTime date;
        var success = DateTime.TryParse(theString, out date);
        return success ? date : defaultDate;
    }

    public static bool ToBool(this string theString)
    {
        bool value;
        var success = bool.TryParse(theString, out value);
        return success && value;
    }

    public static int ToInt(this string theString, int defaultValue = 0)
    {
        int number;
        var success = int.TryParse(theString, out number);
        return success ? number : defaultValue;
    }

    public static bool IsNullOrWhitespace(this string theString)
    {
        return string.IsNullOrWhiteSpace(theString);
    }

    public static bool IsAlphaNumeric(this string theString)
    {
        return string.IsNullOrWhiteSpace(theString);
    }

    public static string ToSlug(this string str)
    {
        var acentos = new[]
        {
            "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È",
            "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â",
            "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û"
        };
        var semAcento = new[]
        {
            "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E",
            "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a",
            "e", "i", "o", "u", "A", "E", "I", "O", "U"
        };

        for (var i = 0; i < acentos.Length; i++) str = str.Replace(acentos[i], semAcento[i]);

        var caracteresEspeciais = new[]
        {
            "¹", "²", "³", "£", "¢", "¬", "º", "¨", "\"", "'", ".", ",", "-", ":", "(", ")", "ª", "|", "\\\\", "°",
            "_", "@", "#", "!", "$", "%", "&", "*", ";", "/", "<", ">", "?", "[", "]", "{", "}", "=", "+", "§", "´",
            "`", "^", "~"
        };

        for (var i = 0; i < caracteresEspeciais.Length; i++) str = str.Replace(caracteresEspeciais[i], "");

        return str.Trim().ToLower().Replace("  ", " ").Replace(" ", "-");
    }

    public static bool EmailIsValid(this string email)
    {
        return Regex.Match(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$").Success;
    }
}