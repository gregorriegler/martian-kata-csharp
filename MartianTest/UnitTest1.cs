using System.Text;

namespace MartianTest;

public class Tests
{
    [Test]
    public void AppleSauce()
    {
        var howAlive = ToAscii(4, 8) + "OW ALIVE?";
        Assert.That(howAlive, Is.EqualTo("HOW ALIVE?"));
    }

    private static string ToAscii(int firstSign, int secondSign)
    {
        return ((char)int.Parse("" + firstSign + secondSign, System.Globalization.NumberStyles.HexNumber)).ToString();
    }
}
