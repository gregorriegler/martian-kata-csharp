namespace MartianTest;

public class StepperTester : Stepper
{
    public List<int> RecordedMoves = new();
    
    public override void MoveClockwise(int steps)
    {
        RecordedMoves.Add(steps);
    }

    public override void MoveAnticlockwise(int steps)
    {
        RecordedMoves.Add(-steps);
    }
    
    
}