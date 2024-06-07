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
    public void TranslatesToMoves()
    {
        var expected = ToMoves("HOW");
        Assert.That(expected, Is.EqualTo(new[] { (4, 4), (-4, 11), (-10, 2) }));
    }

    [Test]
    public void METHOD()
    {
        var stepperTester = new StepperTester();
        Rover rover = new Rover(stepperTester);
        
        rover.sendMessage("HOW");
        
        Assert.That(stepperTester.RecordedMoves, Is.EqualTo(new List<int>()));
    }

    private (int, int)[] ToMoves(string message)
    {
        return AsSeparatedHex(message)
            .Flatten()
            .Aggregate(Enumerable.Empty<int>(), (moves, target) => moves.Append(target - moves.Sum()))
            .Pairwise()
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

public class Rover
{
    private readonly Stepper _stepper;

    public Rover(Stepper stepper)
    {
        _stepper = stepper;
    }

    public void sendMessage(string message)
    {
        throw new NotImplementedException();
    }
}

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
}