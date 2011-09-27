using System;

public static class Extensions
{
    public static bool Empty(this string input)
    {
        return String.IsNullOrEmpty(input);
    }
}