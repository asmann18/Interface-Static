using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace Interface_Static.Extensions;

public static class Helper
{
    public static bool IsOdd(this int number)
    {
        if (number % 2 == 0) return false;
        return true;
    }
    public static bool IsEven(this int number)
    {
        if (number % 2 == 0) return true;
        return false;
    }
    public static bool HasDigit(this string str)
    {
        bool hasDigit = false;
        foreach (char c in str)
        {
            if (char.IsDigit(c)) hasDigit = true;
        }
        return hasDigit;
    }
    public static bool CheckPassword(this string password)
    {
        byte upperCount = 0;
        byte lowerCount = 0;
        byte digitCount = 0;
        foreach (char c in password)
        {
            if (char.IsUpper(c)) upperCount++;
            if (char.IsLower(c)) lowerCount++;
            if (char.IsDigit((char)c)) digitCount++;
        }
        if (upperCount > 0 && lowerCount > 0 && digitCount > 0 && password.Length >= 8)
        {
            return true;
        }
        return false;

    }


    public static string Capitalize(this string text)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            if (i == 0)
            {
                stringBuilder.Append(char.ToUpper(text[i]));
            }
            else if (char.IsWhiteSpace(text[i]))
            {
                if (!char.IsWhiteSpace(text[i + 1]))
                {
                    stringBuilder.Append(text[i]);
                    stringBuilder.Append(char.ToUpper(text[i + 1]));
                    i++;
                }
            }
            else
            {
                stringBuilder.Append(text[i]);
            }
        }
        return stringBuilder.ToString();
    }
}
