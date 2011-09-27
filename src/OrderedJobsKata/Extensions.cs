using System;

public static class Extensions
{
    public static bool Empty(this string input)
    {
        return String.IsNullOrEmpty(input);
    }

    public static string[] Split(this string input, string delimeter)
    {
        return input.Split(new[] { delimeter }, StringSplitOptions.RemoveEmptyEntries);
    }
}