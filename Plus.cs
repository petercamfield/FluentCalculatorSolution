using System;

namespace Calculator
{
    public class Plus : IPartialOp<int>
    {
        private readonly int _number;

        public Plus(int number)
        {
            _number = number;
        }

        public Func<int, int> Apply => total => total + _number;
    }
}