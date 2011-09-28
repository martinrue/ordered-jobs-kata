using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

    public static IDictionary<string, string> ConvertToMap(this string input)
    {
        return input.Split("\r\n")
            .Select(job => Regex.Match(job, @"(\w+) => (\w?)"))
            .ToDictionary(match => match.Groups[1].Value, match => match.Groups[2].Value);
    }
}