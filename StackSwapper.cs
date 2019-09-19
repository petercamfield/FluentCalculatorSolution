using System.Collections.Generic;

namespace Calculator
{
    public interface ISwapStackItems
    {
        void PopAndPush<T>(Stack<T> popStack, Stack<T> pushStack);
    }

    public class StackSwapper : ISwapStackItems
    {
        public void PopAndPush<T>(Stack<T> popStack, Stack<T> pushStack)
        {
            if (popStack.Count > 0) pushStack.Push(popStack.Pop());
        }
    }

    public class DoNothingSwapper : ISwapStackItems
    {
        public void PopAndPush<T>(Stack<T> popStack, Stack<T> pushStack) { }
    }

}