namespace Calculator
{
    using System.Collections.Generic;
    using System.Linq;

    public class Calculator : IAfterUndo
    {
        private int _seed;
        private readonly Stack<IPartialOp<int>> _operations = new Stack<IPartialOp<int>>();
        private readonly Stack<IPartialOp<int>> _redoOperations = new Stack<IPartialOp<int>>();
        private ISwapStackItems _stackSwapper = new StackSwapper();

        public IAfterSeed Seed(int number)
        {
            _seed = number;
            return this;
        }

        int IAfterSeed.Result() => _operations.Aggregate(_seed, (number, op) => op.Apply(number));
        
        IAfterOp IAfterSeed.Plus(int number) => RecordOp(new Plus(number));

        IAfterOp IAfterSeed.Minus(int number) => RecordOp(new Minus(number));

        IAfterUndo IAfterOp.Undo() => PopAndPush(_operations, _redoOperations);

        IAfterUndo IAfterUndo.Redo() => PopAndPush(_redoOperations, _operations);

        IAfterOp IAfterOp.Save()
        {
            _stackSwapper = new DoNothingSwapper();
            return this;
        }

        private IAfterOp RecordOp(IPartialOp<int> operation)
        {
            _operations.Push(operation);
            _redoOperations.Clear();
            return this;
        }

        private IAfterUndo PopAndPush(Stack<IPartialOp<int>> popStack, Stack<IPartialOp<int>> pushStack)
        {
            _stackSwapper.PopAndPush(popStack, pushStack);
            return this;
        }
    }
}