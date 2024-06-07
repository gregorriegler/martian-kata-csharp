using MartianTest;

public static class MessageEncoder
{
    public static (int, int)[] ToMoves(string message)
    {
        return EnumerableExtensions.Flatten(AsSeparatedHex(message))
            .Aggregate(Enumerable.Empty<int>(), (moves, target) => moves.Append(target - moves.Sum()))
            .Pairwise()
            .ToArray();
    }

    public static (int, int)[] AsSeparatedHex(string text)
    {
        return text.ToCharArray()
            .Select(it => SeparateHex(it))
            .ToArray();
    }

    public static (int first, int second) SeparateHex(int hex)
    {
        var first = hex / 16 % 16;
        var second = hex % 16;
        return (first, second);
    }

    public static char[] ToHex(string text)
    {
        return text.ToCharArray();
    }

    public static string ToAscii(string firstSign, string secondSign)
    {
        string hexString = firstSign + secondSign;
        int hexValue = Convert.ToInt32(hexString, 16);
        return (char)hexValue + "";
    }
}