using Rovers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace RoversTests
{
    [TestClass()]
    public class RoverTests    {


        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void InitializeDoesNotThrowException()
        {
            //case 1 
            Rover rover = new Rover();            
            rover.SetPosition(1,2,3);

            //case 2
            Rover rover2 = new Rover(5,5);
            rover.SetPosition(1, 2, 3);
        }

        [TestMethod()]
        [ExpectedException(typeof(IllegalArgumentException))]
        public void InitializeInvalidDirectionThrowsException_Test1()
        {
            Rover rover = new Rover(10, 15);
            rover.SetPosition(1, 2, 5);
        }

        [TestMethod()]
        [ExpectedException(typeof(IllegalArgumentException))]
        public void InitializeInvalidDirectionThrowsException_Test2()
        {
            Rover rover = new Rover(100, 50);
            rover.SetPosition(1, 2, 0);
        }

        [TestMethod()]
        public void MoveRoverNorth_WithNoDirectionChange()
        {
            Rover rover = new Rover(200, 100);

            rover.SetPosition(0, 0, 1);
            rover.Process("M");
            Assert.AreEqual(rover.GetPosition(), "0,1,N");

            rover.SetPosition(0, 0, 1);
            rover.Process("MM");
            Assert.AreEqual(rover.GetPosition(), "0,2,N");

            rover.SetPosition(0, 0, 1);
            rover.Process("MMM");
            Assert.AreEqual(rover.GetPosition(), "0,3,N");
        }

        [TestMethod()]
        public void MoveRoverEast_WithNoDirectionChange()
        {
            Rover rover = new Rover(200, 100);

            rover.SetPosition(0, 0, 2);
            rover.Process("M");
            Assert.AreEqual(rover.GetPosition(), "1,0,E");

            rover.SetPosition(0, 0, 2);
            rover.Process("MM");
            Assert.AreEqual(rover.GetPosition(), "2,0,E");

            rover.SetPosition(0, 0, 2);
            rover.Process("MMM");
            Assert.AreEqual(rover.GetPosition(), "3,0,E");
        }

        [TestMethod()]
        public void MoveRoverSouth_WithNoDirectionChange()
        {
            Rover rover = new Rover(200, 100);

            rover.SetPosition(0, 0, 3);
            rover.Process("M");
            Assert.AreEqual(rover.GetPosition(), "0,-1,S");

            rover.SetPosition(0, 0, 3);
            rover.Process("MM");
            Assert.AreEqual(rover.GetPosition(), "0,-2,S");

            rover.SetPosition(0, 0, 3);
            rover.Process("MMM");
            Assert.AreEqual(rover.GetPosition(), "0,-3,S");
        }

        [TestMethod()]
        public void MoveRoverWest_WithNoDirectionChange()
        {
            Rover rover = new Rover(200, 100);

            rover.SetPosition(0, 0, 4);
            rover.Process("M");
            Assert.AreEqual(rover.GetPosition(), "-1,0,W");

            rover.SetPosition(0, 0, 4);
            rover.Process("MM");
            Assert.AreEqual(rover.GetPosition(), "-2,0,W");

            rover.SetPosition(0, 0, 4);
            rover.Process("MMM");
            Assert.AreEqual(rover.GetPosition(), "-3,0,W");
        }

        [TestMethod()]
        public void TurnRight()
        {
            Rover rover = new Rover(200,100);
           
            rover.SetPosition(0, 0, 1);
            rover.Process("R");
            Assert.AreEqual(rover.GetPosition(), "0,0,E");

            rover.SetPosition(0, 0, 1);
            rover.Process("RR");
            Assert.AreEqual(rover.GetPosition(), "0,0,S");

            rover.SetPosition(0, 0, 1);
            rover.Process("RRR");
            Assert.AreEqual(rover.GetPosition(), "0,0,W");

            rover.SetPosition(0, 0, 1);
            rover.Process("RRRR");
            Assert.AreEqual(rover.GetPosition(), "0,0,N");
        }

        [TestMethod()]
        public void TurnLeft()
        {
            Rover rover = new Rover(200, 100);

            rover.SetPosition(0, 0, 1);
            rover.Process("L");
            Assert.AreEqual(rover.GetPosition(), "0,0,W");

            rover.SetPosition(0, 0, 1);
            rover.Process("LL");
            Assert.AreEqual(rover.GetPosition(), "0,0,S");

            rover.SetPosition(0, 0, 1);
            rover.Process("LLL");
            Assert.AreEqual(rover.GetPosition(), "0,0,E");

            rover.SetPosition(0, 0, 1);
            rover.Process("LLLL");
            Assert.AreEqual(rover.GetPosition(), "0,0,N");
        }


        [TestMethod()]
        public void MoveAndTurnRight()
        {
            Rover rover = new Rover(200, 100);

            rover.SetPosition(30, 40, 1);
            rover.Process("MR");
            Assert.AreEqual(rover.GetPosition(), "30,41,E");

            rover.Process("MRMR");
            Assert.AreEqual(rover.GetPosition(), "31,40,W");

            rover.Process("MRMRMR");
            Assert.AreEqual(rover.GetPosition(), "31,41,S");

            rover.Process("MRMRMRMR");
            Assert.AreEqual(rover.GetPosition(), "31,41,S");

            rover.Process("MRMRMRMRMR");
            Assert.AreEqual(rover.GetPosition(), "31,40,W");

        }

        [TestMethod()]
        public void MoveAndTurnLeft()
        {
            Rover rover = new Rover(200, 100);

            rover.SetPosition(30, 40, 1);
            rover.Process("ML");
            Assert.AreEqual(rover.GetPosition(), "30,41,W");

            rover.Process("MLML");
            Assert.AreEqual(rover.GetPosition(), "29,40,E");

            rover.Process("MLMLML");
            Assert.AreEqual(rover.GetPosition(), "29,41,S");

            rover.Process("MLMLMLML");
            Assert.AreEqual(rover.GetPosition(), "29,41,S");

            rover.Process("MLMLMLMLML");
            Assert.AreEqual(rover.GetPosition(), "29,40,E");

        }

        [TestMethod()]
        public void MoveAndTurnRandom()
        {
            Rover rover = new Rover(500, 500);

            rover.SetPosition(0, 0, 1);
            var randomStringCommand = GetRandomCommand();
            rover.Process(randomStringCommand);
        }

        [TestMethod()]
        public void MoveAndTurnAndVerifyPosition()
        {
            Rover rover = new Rover(5, 5);
            rover.SetPosition(1, 2, 1);

            rover.Process("LMLMLMLMM");
            var currentPosition = rover.GetPosition();
            Assert.AreEqual(currentPosition, "1,3,N");
        }

        private string GetRandomCommand()
        {
            Random randomNumber = new Random();
            int movementInitial = randomNumber.Next(0, 250);
            int directionLeft = randomNumber.Next(0, 100);
            int directionRight = randomNumber.Next(0, 100);
            int movementFinal = randomNumber.Next(0, 250);

            StringBuilder stringCommand = new StringBuilder("");
            for(int i=0;i<movementInitial; i++)
            {
                stringCommand.Append("M");
            }
            for (int i = 0; i < directionLeft; i++)
            {
                stringCommand.Append("L");
            }
            for (int i = 0; i < directionRight; i++)
            {
                stringCommand.Append("R");
            }
            for (int i = 0; i < movementFinal; i++)
            {
                stringCommand.Append("M");
            }
            if(stringCommand.ToString()==string.Empty)
            {
                return "MLRM";
            }
            return stringCommand.ToString();
        }
        
    }
}

