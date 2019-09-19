namespace Calculator
{
    public interface IAfterUndo : IAfterOp
    {
        IAfterUndo Redo();
    }
}