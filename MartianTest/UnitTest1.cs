using System.Text;

namespace MartianTest;

public class Tests
{
    [Test]
    public void AppleSauce()
    {
        var howAlive = ToAscii("4", "8") + "O" + "W ALIVE?";
        Assert.That(howAlive, Is.EqualTo("HOW ALIVE?"));
    }

    private static string ToAscii(string firstSign, string secondSign)
    {
        string hexString = firstSign + secondSign;
        int hexValue = Convert.ToInt32(hexString, 16);
        return (char)hexValue + "";
    }
}
