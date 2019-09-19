namespace Calculator
{
    public interface IAfterOp : IAfterSeed
    {
        IAfterUndo Undo();

        IAfterOp Save();
    }
}