Feature: MarsRover
#a.	Write a test for Rover direction facing and positioning initialisation
#b.	Write A test for moving the rover x and y position and location
#c.	Write a test to move the rover as per the given scenario problem, given input : 
#5 5 
#1 2 N 
#LMLMLMLMM     	
######################################################################################################################################################

Scenario Outline:Initialize Mars Rover
Given Rover is initialized with following position
| x                  | y                  |
| <InitialPositionX> | <InitialPositionY> |
When Rover position is set to the following position
| x              | y              | facing      |
| <SetPositionX> | <SetPositionY> | <SetFacing> |
Then Rover is at the following position
| x                | y                | facing        |
| <FinalPositionX> | <FinalPositionY> | <FinalFacing> |
Examples:
| TestCase | InitialPositionX | InitialPositionY | SetPositionX | SetPositionY | SetFacing | FinalPositionX | FinalPositionY | FinalFacing |
| North    | 0                | 0                | 1            | 2            | 1         | 1              | 2              | N           |
| East     | 5                | 5                | 3            | 4            | 2         | 3              | 4              | E           |
| South    | 100              | 200              | 1            | 2            | 3         | 1              | 2              | S           |
| West     | 250              | 230              | 11           | 32           | 4         | 11             | 32             | W           |

######################################################################################################################################################


Scenario Outline:Move Rover With No Change in Direction
Given Rover is initialized with following position
| x   | y   |
| 500 | 500 |
When Rover position is set to the following position
| x              | y              | facing      |
| <SetPositionX> | <SetPositionY> | <SetFacing> |
And Rover is moved with following command
| Command   |
| <Command> |
Then Rover is at the following position
| x                | y                | facing        |
| <FinalPositionX> | <FinalPositionY> | <FinalFacing> |
Examples:
| TestCase    | SetPositionX | SetPositionY | SetFacing | Command | FinalPositionX | FinalPositionY | FinalFacing |
| North_Case1 | 0            | 0            | 1         | M       | 0              | 1              | N           |
| North_Case2 | 0            | 0            | 1         | MM      | 0              | 2              | N           |
| North_Case3 | 0            | 0            | 1         | MMM     | 0              | 3              | N           |
| East_Case1  | 0            | 0            | 2         | M       | 1              | 0              | E           |
| East_Case2  | 0            | 0            | 2         | MM      | 2              | 0              | E           |
| East_Case3  | 0            | 0            | 2         | MMM     | 3              | 0              | E           |
| South_Case1 | 0            | 0            | 3         | M       | 0              | -1             | S           |
| South_Case2 | 0            | 0            | 3         | MM      | 0              | -2             | S           |
| South_Case3 | 0            | 0            | 3         | MMM     | 0              | -3             | S           |
| West_Case1  | 0            | 0            | 4         | M       | -1             | 0              | W           |
| West_Case2  | 0            | 0            | 4         | MM      | -2             | 0              | W           |
| West_Case3  | 0            | 0            | 4         | MMM     | -3             | 0              | W           |

######################################################################################################################################################

Scenario Outline:Turn Rover Right
Given Rover is initialized with following position
| x   | y   |
| 500 | 500 |
When Rover position is set to the following position
| x              | y              | facing      |
| <SetPositionX> | <SetPositionY> | <SetFacing> |
And Rover is moved with following command
| Command   |
| <Command> |
Then Rover is at the following position
| x                | y                | facing        |
| <FinalPositionX> | <FinalPositionY> | <FinalFacing> |
Examples:
| TestCase               | SetPositionX | SetPositionY | SetFacing | Command | FinalPositionX | FinalPositionY | FinalFacing |
| Turns_Right_Once       | 0            | 0            | 1         | R       | 0              | 0              | E           |
| Turns_Right_Twice      | 0            | 0            | 1         | RR      | 0              | 0              | S           |
| Turns_Right_ThreeTimes | 0            | 0            | 1         | RRR     | 0              | 0              | W           |
| Turns_Right_FourTimes  | 0            | 0            | 1         | RRRR    | 0              | 0              | N           |

######################################################################################################################################################

Scenario Outline:Turn Rover Left
Given Rover is initialized with following position
| x   | y   |
| 500 | 500 |
When Rover position is set to the following position
| x              | y              | facing      |
| <SetPositionX> | <SetPositionY> | <SetFacing> |
And Rover is moved with following command
| Command   |
| <Command> |
Then Rover is at the following position
| x                | y                | facing        |
| <FinalPositionX> | <FinalPositionY> | <FinalFacing> |
Examples:
| TestCase              | SetPositionX | SetPositionY | SetFacing | Command | FinalPositionX | FinalPositionY | FinalFacing |
| Turns_Left_Once       | 0            | 0            | 1         | L       | 0              | 0              | W           |
| Turns_Left_Twice      | 0            | 0            | 1         | LL      | 0              | 0              | S           |
| Turns_Left_ThreeTimes | 0            | 0            | 1         | LLL     | 0              | 0              | E           |
| Turns_Left_FourTimes  | 0            | 0            | 1         | LLLL    | 0              | 0              | N           |

######################################################################################################################################################

Scenario Outline:Move Rover And Turn Right
Given Rover is initialized with following position
| x  | y  |
| 30 | 40 |
When Rover position is set to the following position
| x              | y              | facing      |
| <SetPositionX> | <SetPositionY> | <SetFacing> |
And Rover is moved with following command
| Command   |
| <Command> |
Then Rover is at the following position
| x                | y                | facing        |
| <FinalPositionX> | <FinalPositionY> | <FinalFacing> |
Examples:
| TestCase       | SetPositionX | SetPositionY | SetFacing | Command    | FinalPositionX | FinalPositionY | FinalFacing |
| MoveRightCase1 | 30           | 40           | 1         | MR         | 30             | 41             | E           |
| MoveRightCase2 | 30           | 41           | 2         | MRMR       | 31             | 40             | W           |
| MoveRightCase3 | 31           | 40           | 4         | MRMRMR     | 31             | 41             | S           |
| MoveRightCase4 | 31           | 41           | 3         | MRMRMRMR   | 31             | 41             | S           |
| MoveRightCase5 | 31           | 41           | 3         | MRMRMRMRMR | 31             | 40             | W           |



######################################################################################################################################################

Scenario Outline:Move Rover And Turn Left
Given Rover is initialized with following position
| x  | y  |
| 30 | 40 |
When Rover position is set to the following position
| x              | y              | facing      |
| <SetPositionX> | <SetPositionY> | <SetFacing> |
And Rover is moved with following command
| Command   |
| <Command> |
Then Rover is at the following position
| x                | y                | facing        |
| <FinalPositionX> | <FinalPositionY> | <FinalFacing> |
Examples:
| TestCase       | SetPositionX | SetPositionY | SetFacing | Command    | FinalPositionX | FinalPositionY | FinalFacing |
| MoveRightCase1 | 30           | 40           | 1         | ML         | 30             | 41             | W           |
| MoveRightCase2 | 30           | 41           | 4         | MLML       | 29             | 40             | E           |
| MoveRightCase3 | 29           | 40           | 2         | MLMLML     | 29             | 41             | S           |
| MoveRightCase4 | 29           | 41           | 3         | MLMLMLML   | 29             | 41             | S           |
| MoveRightCase5 | 29           | 41           | 3         | MLMLMLMLML | 29             | 40             | E           |



######################################################################################################################################################

Scenario: Move Rover With Input Command And Verify Final Position
Given Rover is initialized with following position
| x | y |
| 5 | 5 |
When Rover position is set to the following position
| x | y | facing |
| 1 | 2 | 1      |
And Rover is moved with following command
| Command   |
| LMLMLMLMM |
Then Rover is at the following position
| x | y | facing |
| 1 | 3 | N      |



######################################################################################################################################################

Scenario: Move Rover With Random Command And Verify Final Position
Given Rover is initialized with following position
| x    | y    |
| 1000 | 1000 |
When Rover is moved with random command
Then Rover is at a random position

######################################################################################################################################################

Scenario Outline:Initialize Rover Invalid Position Gives Error
Given Rover is initialized with following position
| x                  | y                  |
| <InitialPositionX> | <InitialPositionY> |
Then Rover position is set to the following invalid position and gives error
| x              | y              | facing      |
| <SetPositionX> | <SetPositionY> | <SetFacing> |

Examples:
| TestCase      | InitialPositionX | InitialPositionY | SetPositionX | SetPositionY | SetFacing |
| Invalid_Case1 | 0                | 0                | 0            | 0            | 0         |
| Invalid_Case2 | 5                | 5                | 5            | 5            | 5         |
######################################################################################################################################################
