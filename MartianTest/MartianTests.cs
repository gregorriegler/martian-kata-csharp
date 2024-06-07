namespace MartianTest;

public class Tests
{
    [Test]
    public void ConvertsTwoDigitsToAscii()
    {
        var howAlive = MessageEncoder.ToAscii("4", "8") + MessageEncoder.ToAscii("4", "F") + MessageEncoder.ToAscii("5", "7") + MessageEncoder.ToAscii("2", "0") + MessageEncoder.ToAscii("4", "1");
        Assert.That(howAlive, Is.EqualTo("HOW A"));
    }

    [Test]
    public void ConvertsAStringToHex()
    {
        var hex = MessageEncoder.ToHex("HOW A");
        Assert.That(hex, Is.EqualTo(new[] { 0x48, 0x4F, 0x57, 0x20, 0x41 }));
    }

    [Test]
    public void SeparatesAHexIntoTwoParts()
    {
        var expected = MessageEncoder.SeparateHex('H');
        Assert.That(expected, Is.EqualTo((4, 8)));
    }

    [Test]
    public void GivesSeparatedHexesForString()
    {
        var expected = MessageEncoder.AsSeparatedHex("HO");
        Assert.That(expected, Is.EqualTo(new[] { (4, 8), (4, 15) }));
    }

    [Test]
    public void TranslatesToMoves()
    {
        var expected = MessageEncoder.ToMoves("HOW");
        Assert.That(expected, Is.EqualTo(new[] { (4, 4), (-4, 11), (-10, 2), (-7, 0)}));
    }

    [Test]
    public void SendsMessageToRover()
    {
        var stepperTester = new StepperTester();
        Rover rover = new Rover(stepperTester);
        
        rover.SendMessage("HOW");
        
        Assert.That(stepperTester.RecordedMoves, Is.EqualTo(new List<int> {4,4,-4,11,-10,2,-7,0})); //ignoring stepsize
    }
}