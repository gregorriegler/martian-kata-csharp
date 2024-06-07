using System.Text;

namespace MartianTest;

public class Tests
{
    [Test]
    public void AppleSauce()
    {
        var firstSign = 4;
        var secondSign = 8;
        var h = ((char)int.Parse("" + firstSign + secondSign, System.Globalization.NumberStyles.HexNumber)).ToString();
        var howAlive = h + "OW ALIVE?";
        Assert.That(howAlive, Is.EqualTo("HOW ALIVE?"));
    }
}
