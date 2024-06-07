namespace MartianTest;

public static class EnumerableExtensions
{
    public static IEnumerable<(int, int)> Pairwise(this IEnumerable<int> source)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                int first = enumerator.Current;

                if (!enumerator.MoveNext())
                    throw new ArgumentException("Enumerable must contain an even number of elements");

                int second = enumerator.Current;
                yield return (first, second);
            }
        }
    }

    public static IEnumerable<int> Flatten(this IEnumerable<(int, int)> source)
    {
        return source.SelectMany(it => new[] { it.Item1, it.Item2 });
    }
    
    public static IEnumerable<int> With(this IEnumerable<int> enumerable, Func<IEnumerable<int>, IEnumerable<int>> func)
    {
        return func.Invoke(enumerable);
    }
}