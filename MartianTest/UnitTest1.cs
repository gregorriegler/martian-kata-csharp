namespace MartianTest;

public class Tests
{
    [Test]
    public void AppleSauce()
    {
        var howAlive = "H" + "OW ALIVE?";
        Assert.AreEqual("HOW ALIVE?", howAlive);
    }
}