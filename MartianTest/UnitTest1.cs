namespace MartianTest;

public class Tests
{
    [Test]
    public void AppleSauce()
    {
        var howAlive = "HOW ALIVE?";
        Assert.AreEqual("HOW ALIVE?", howAlive);
    }
}