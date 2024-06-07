using System.Text;

namespace MartianTest;

public class Tests
{
    [Test]
    public void AppleSauce()
    {
        var H = ((char)int.Parse("" + 4 + 8, System.Globalization.NumberStyles.HexNumber)).ToString();
        var howAlive = H + "OW ALIVE?";
        Assert.AreEqual("HOW ALIVE?", howAlive);
    }
}
