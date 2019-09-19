using System;

namespace Calculator
{
    public interface IPartialOp<T>
    {
        Func<T, T> Apply { get; }
    }
}