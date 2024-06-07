namespace MartianTest;

public class Rover
{
    private readonly Stepper _stepper;

    public Rover(Stepper stepper)
    {
        _stepper = stepper;
    }

    public void sendMessage(string message)
    {
    }
}