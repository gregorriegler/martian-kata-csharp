namespace MartianTest;

public class Rover
{
    private readonly Stepper _stepper;

    public Rover(Stepper stepper)
    {
        _stepper = stepper;
    }

    public void SendMessage(string message)
    {
        foreach (var move in MessageEncoder.ToMoves(message))
        {
            moveIt(move.Item1);
            moveIt(move.Item2);
        }
    }

    private void moveIt(int move)
    {
        if (move > 0)
        {
            _stepper.MoveClockwise(move);
        }
        else
        {
            _stepper.MoveAnticlockwise(-move);
        }
    }
}