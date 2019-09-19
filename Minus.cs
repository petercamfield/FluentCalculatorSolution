using System;

namespace Calculator
{
    public class Minus : IPartialOp<int>
    {
        private readonly int _number;

        public Minus(int number)
        {
            _number = number;
        }

        public Func<int, int> Apply => total => total - _number;
    }
}