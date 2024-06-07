namespace MartianTest;

public class StepperTester : Stepper
{
    public List<int> RecordedMoves = new();
    
    public override void MoveClockwise(int steps)
    {
        RecordedMoves.Append(steps);
    }

    public override void MoveAnticlockwise(int steps)
    {
        RecordedMoves.Append(-steps);
    }
    
    
}