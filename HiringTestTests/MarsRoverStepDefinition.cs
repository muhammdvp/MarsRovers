using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rovers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RoversTests
{
    [Binding]
    public sealed class MarsRoverStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        Rover myRover;

        public MarsRoverStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Rover is initialized with following position")]
        public void GivenRoverIsInitializedWithFollowingPosition(Table table)
        {
            var row = table.Rows[0];
            var x = Convert.ToInt32(row["x"]);
            var y = Convert.ToInt32(row["y"]);

            Rover rover = new Rover(x, y);
            myRover = rover;
        }


        [When(@"Rover position is set to the following position")]
        public void WhenInitialPositionIsSetToTheFollowingPosition(Table table)
        {
            var row = table.Rows[0];
            var x = Convert.ToInt32(row["x"]);
            var y = Convert.ToInt32(row["y"]);
            var facing = Convert.ToInt32(row["facing"]);
            myRover.SetPosition(x,y, facing);
        }

        [Then(@"Rover is at the following position")]
        public void ThenRoverIsInitializedWithNoErrorsWithFollowingPosition(Table table)
        {
            var row = table.Rows[0];
            var x = row["x"];
            var y = row["y"];
            var facing = row["facing"];
            var position = x + "," + y + "," + facing;

            Assert.AreEqual(position, myRover.GetPosition());
        }

        [When(@"Rover is moved with following command")]
        public void WhenRoverIsMovedWithFollowingCommand(Table table)
        {
            var row = table.Rows[0];
            var command = row["Command"];
            myRover.Process(command);
        }

        [When(@"Rover is moved with random command")]
        public void WhenRoverIsMovedWithRandomCommand()
        {
            myRover.SetPosition(0, 0, 1);
            var randomStringCommand = GetRandomCommand();
            myRover.Process(randomStringCommand);
        }

        [Then(@"Rover is at a random position")]
        public void ThenRoverIsAtARandomPosition()
        {
            var actualPosition = myRover.GetPosition();
            var valus = actualPosition.Split(new char[] { ',' });

            var x = valus[0];
            var y = valus[1];
            var facing = valus[2];
            int position = 0;

            Assert.IsTrue(int.TryParse(x, out position));
            Assert.IsTrue(int.TryParse(y, out position));

            List<char> directions = new List<char>();
            directions.Add('N');
            directions.Add('E');
            directions.Add('S');
            directions.Add('W');

            bool isValidDirection = directions.Contains(facing[0]);
            Assert.IsTrue(isValidDirection);
        }


        private string GetRandomCommand()
        {
            Random randomNumber = new Random();
            int movementInitial = randomNumber.Next(0, 250);
            int directionLeft = randomNumber.Next(0, 100);
            int directionRight = randomNumber.Next(0, 100);
            int movementFinal = randomNumber.Next(0, 250);

            StringBuilder stringCommand = new StringBuilder("");
            for (int i = 0; i < movementInitial; i++)
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
            if (stringCommand.ToString() == string.Empty)
            {
                return "MLRM";
            }
            return stringCommand.ToString();
        }

        [Then(@"Rover position is set to the following invalid position and gives error")]
        public void ThenRoverPositionIsSetToTheFollowingInvalidPositionAndGivesError(Table table)
        {
            var row = table.Rows[0];
            var x = Convert.ToInt32(row["x"]);
            var y = Convert.ToInt32(row["y"]);
            var facing = Convert.ToInt32(row["facing"]);
            Assert.ThrowsException<IllegalArgumentException>(()=>myRover.SetPosition(x, y, facing));
        }

    }
}
