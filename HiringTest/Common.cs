using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovers
{
    public enum Direction
    {
        N = 1,  // Facing North
        E = 2,  // Facing East
        S = 3,  // Facing South
        W = 4   // Facing West
    }

    public class IllegalArgumentException : Exception
    {
        public IllegalArgumentException() : base()
        {

        }

        public IllegalArgumentException(string message) : base(message)
        {

        }

        public IllegalArgumentException(string message , Exception ex) : base(message,ex)
        {

        }
    }
}
