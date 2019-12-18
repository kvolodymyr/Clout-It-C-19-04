using System;

namespace Module6Task1
{
    public class IncorrectInputException : Exception
    {
        public IncorrectInputException()
        {
        }
        public IncorrectInputException(string message) : base(message)
        {
        }
    }
}
