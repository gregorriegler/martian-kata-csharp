using System.Text;

namespace MartianTest;

public class Tests
{
    [Test]
    public void AppleSauce()
    {
        var howAlive = Encoding.UTF8.GetString([0x48]) + "OW ALIVE?";
        Assert.AreEqual("HOW ALIVE?", howAlive);
    }
}
