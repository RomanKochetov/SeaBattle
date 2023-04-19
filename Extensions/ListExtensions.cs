using System;
using System.Collections.Generic;

namespace SeaBattle.Extensions;

public static class ListExtensions
{
    private static readonly Random Random = new();

    public static T GetRandom<T>(this List<T> source)
    {
        return source[Random.Next(source.Count)];
    }
}
