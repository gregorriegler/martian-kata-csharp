using System.Text;

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

    private static string ToAscii(string firstSign, string secondSign)
    {
        string hexString = firstSign + secondSign;
        int hexValue = Convert.ToInt32(hexString, 16);
        return (char)hexValue + "";
    }
}