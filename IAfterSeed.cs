namespace Calculator
{
    public interface IAfterSeed
    {
        int Result();
        IAfterOp Plus(int number);
        IAfterOp Minus(int number);
    }
}