using NUnit.Framework.Constraints;

namespace MartianTest;

public class Tests
{
    [Test]
    public void ConvertsTwoDigitsToAscii()
    {
        var howAlive = ToAscii("4", "8") +
                       ToAscii("4", "F") +
                       ToAscii("5", "7") +
                       ToAscii("2", "0") +
                       ToAscii("4", "1");
        Assert.That(howAlive, Is.EqualTo("HOW A"));
    }

    [Test]
    public void ConvertsAStringToHex()
    {
        var hex = ToHex("HOW A");
        Assert.That(hex, Is.EqualTo(new[] { 0x48, 0x4F, 0x57, 0x20, 0x41 }));
    }

    [Test]
    public void SeparatesAHexIntoTwoParts()
    {
        var expected = SeparateHex('H');
        Assert.That(expected, Is.EqualTo((4, 8)));
    }

    [Test]
    public void GivesSeparatedHexesForString()
    {
        var expected = AsSeparatedHex("HO");
        Assert.That(expected, Is.EqualTo(new[] { (4, 8), (4, 15) }));
    }

    [Test]
    public void METHOD()
    {
        Assert.That(ToMoves("HOW"), Is.EqualTo(new[] { (4, 4), (-4, 11), (-10,2) }));
    }

    private (int, int)[] ToMoves(string message)
    {
        var aggregate = AsSeparatedHex(message)
            .Aggregate(Enumerable.Empty<int>(), (accumulator, tuple) => accumulator.Append(tuple.Item1).Append(tuple.Item2));
        
        var start = 0;
        var moves = new List<int>();
        var position = start;
        foreach (var digit in aggregate)
        {
            moves.Add(digit - position);
            position += digit - position;
        }

        return Enumerable.Range(0, moves.Count / 2)
            .Select(i => (moves[2 * i], moves[2 * i + 1]))
            .ToArray();
    }

    private (int, int)[] AsSeparatedHex(string text)
    {
        return text.ToCharArray()
            .Select(it => SeparateHex(it))
            .ToArray();
    }

    private static (int first, int second) SeparateHex(int hex)
    {
        var first = hex / 16 % 16;
        var second = hex % 16;
        return (first, second);
    }


    private static char[] ToHex(string text)
    {
        return text.ToCharArray();
    }

    private static string ToAscii(string firstSign, string secondSign)
    {
        string hexString = firstSign + secondSign;
        int hexValue = Convert.ToInt32(hexString, 16);
        return (char)hexValue + "";
    }
}