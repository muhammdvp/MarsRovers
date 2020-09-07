using System;
using System.Collections.Generic;
using System.Linq;

namespace Rovers
{
    /// <summary>
    ///  class representing Rover
    /// </summary>
    public class Rover
    {
        public static readonly int N = 1;
        public static readonly int E = 2;
        public static readonly int S = 3;
        public static readonly int W = 4;

        int x = 0;
        int y = 0;
        int facing = N;

        List<char> directions = new List<char>() { 'N','E','S','W'};

        public Rover()
        {
        }

        public Rover(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void SetPosition(int x, int y, int facing)
        {
            if( !directions.Contains(GetFacingCharacter(facing)))            
            {
                throw new IllegalArgumentException("Speak in Mars language, please!");
            }
            this.x = x;
            this.y = y;
            this.facing = facing;
        }

        public char GetFacingCharacter(int input)
        {
            char dir = 'N';
            if (input == 1)
            {
                dir = 'N';
            }
            else if (input == 2)
            {
                dir = 'E';
            }
            else if (input == 3)
            {
                dir = 'S';
            }
            else if (input == 4)
            {
                dir = 'W';
            }
            else
                dir = 'X';

            return dir;
            
        }

        public void PrintPosition()
        {
            char dir = 'N';
            if (facing == 1)
            {
                dir = 'N';
            }
            else if (facing == 2)
            {
                dir = 'E';
            }
            else if (facing == 3)
            {
                dir = 'S';
            }
            else if (facing == 4)
            {
                dir = 'W';
            }
            //System.out.println(x   " "   y   " "   dir);
            Console.WriteLine(x.ToString() + "," + y.ToString() + "," + dir.ToString());
        }

        public string GetPosition()
        {
            char dir = 'N';
            if (facing == 1)
            {
                dir = 'N';
            }
            else if (facing == 2)
            {
                dir = 'E';
            }
            else if (facing == 3)
            {
                dir = 'S';
            }
            else if (facing == 4)
            {
                dir = 'W';
            }
            //System.out.println(x   " "   y   " "   dir);
            Console.WriteLine(x.ToString() + "," + y.ToString() + "," + dir.ToString());

            return x.ToString() + "," + y.ToString() + "," + dir.ToString();
        }

        public void Process(string commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                process(commands[i]);
            }
        }
        
        private void process(char command)
        {
            if (command.Equals('L'))
            {
                turnLeft();
            }
            else if (command.Equals('R'))
            {
                turnRight();
            }
            else if (command.Equals('M'))
            {
                move();
            }
            else
            {
                throw new IllegalArgumentException("Speak in Mars language, please!");
            }
        }

        private void move()
        {
            if (facing == N)
            {
                this.y++;
            }
            else if (facing == E)
            {
                this.x++;
            }
            else if (facing == S)
            {
                this.y--;
            }
            else if (facing == W)
            {
                this.x--;
            }
        }
        private void turnLeft()
        {
            facing = (facing - 1) < N ? W : facing - 1;
        }
        private void turnRight()
        {
            facing = (facing +  1) > W ? N : facing + 1;
        }

        public void ExecuteRoverCommands(string[] args)
        {
            Rover rover = new Rover();
            rover.SetPosition(1, 2, N);
            rover.Process("LMLMLMLMM");
            rover.PrintPosition(); // prints 1 3 N
            var position1 = rover.GetPosition();

            rover.SetPosition(3, 3, E);
            rover.Process("MMRMMRMRRM");
            rover.PrintPosition(); // prints 5 1 E
            var position2 = rover.GetPosition();
        }

    }
}
