using static CSPreALevelSkeleton.Item;
using static CSPreALevelSkeleton.Character;
using static CSPreALevelSkeleton.Program;

namespace CSPreALevelSkeleton
{
    public class Game
    {
        private Character Player = new Character();
        private Grid Cavern = new Grid();
        private Enemy Monster = new Enemy();
        private Item Flask = new Item();
        private Trap Trap1 = new Trap();
        private Trap Trap2 = new Trap();
        private bool TrainingGame;


        public Game(bool IsATrainingGame)
        {
            TrainingGame = IsATrainingGame;
            SetUpGame();
            Play();
        }

        public void Play()
        {
            int Count;
            bool Eaten;
            bool FlaskFound;
            char MoveDirection;
            bool ValidMove;
            CellReference Position;
            Eaten = false;
            FlaskFound = false;
            Cavern.Display(Monster.GetAwake());
            do
            {
                do
                {
                    DisplayMoveOptions();
                    MoveDirection = GetMove();
                    ValidMove = CheckValidMove(MoveDirection);
                } while (!ValidMove);
                if (MoveDirection != 'M')
                {
                    Cavern.PlaceItem(Player.GetPosition(), ' ');
                    Player.MakeMove(MoveDirection);
                    Cavern.PlaceItem(Player.GetPosition(), '*');
                    Cavern.Display(Monster.GetAwake());
                    FlaskFound = Player.CheckIfSameCell(Flask.GetPosition());
                    if (FlaskFound)
                    {
                        DisplayWonGameMessage();
                    }
                    Eaten = Monster.CheckIfSameCell(Player.GetPosition());
                    // This selection structure checks to see if the player has 
                    // triggered one of the traps in the cavern
                    if (!Monster.GetAwake() && !FlaskFound && !Eaten && ((Player.CheckIfSameCell(Trap1.GetPosition()) && !Trap1.GetTriggered()) || (Player.CheckIfSameCell(Trap2.GetPosition()) && !Trap2.GetTriggered())))
                    {
                        Monster.ToggleSleepStatus();
                        DisplayTrapMessage();
                        Cavern.Display(Monster.GetAwake());
                    }
                    if (Monster.GetAwake() && !Eaten && !FlaskFound)
                    {
                        Count = 0;
                        do
                        {
                            Cavern.PlaceItem(Monster.GetPosition(), ' ');
                            Position = Monster.GetPosition();
                            Monster.MakeMove(Player.GetPosition());
                            Cavern.PlaceItem(Monster.GetPosition(), 'M');
                            if (Monster.CheckIfSameCell(Flask.GetPosition()))
                            {
                                Flask.SetPosition(Position);
                                Cavern.PlaceItem(Position, 'F');
                            }
                            Eaten = Monster.CheckIfSameCell(Player.GetPosition());
                            Console.WriteLine();
                            Console.WriteLine("Press Enter key to continue");
                            Console.ReadLine();
                            Cavern.Display(Monster.GetAwake());
                            Count++;
                        } while (Count != 2 && !Eaten);
                    }
                    if (Eaten)
                    {
                        DisplayLostGameMessage();
                    }
                }
            } while (!Eaten && !FlaskFound && MoveDirection != 'M');
        }

        public void DisplayMoveOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Enter N to move NORTH");
            Console.WriteLine("Enter S to move SOUTH");
            Console.WriteLine("Enter E to move EAST");
            Console.WriteLine("Enter W to move WEST");
            Console.WriteLine("Enter M to return to the Main Menu");
            Console.WriteLine();
        }

        public char GetMove()
        {
            char Move;
            Move = char.Parse(ReadLineSafely(maxChars:1));
            Console.WriteLine();
            return Char.ToUpper(Move);
        }

        public void DisplayWonGameMessage()
        {
            Console.WriteLine("Well done! you have found the flask containing the Styxian potion.");
            Console.WriteLine("You have won the game of MONSTER!");
            Console.WriteLine();
            Console.ReadLine();
        }

        public void DisplayTrapMessage()
        {
            Console.WriteLine("Oh no! You have set off a trap. Watch out, the monster is now awake!");
            Console.WriteLine();
            Console.ReadLine();
        }

        public void DisplayLostGameMessage()
        {
            Console.WriteLine("ARGHHHHHH! The monster has eaten you. GAME OVER.");
            Console.WriteLine("Maybe you will have better luck next time you play MONSTER!");
            Console.WriteLine();
            Console.ReadLine();
        }

        public bool CheckValidMove(char Direction)
        {
            bool ValidMove;
            ValidMove = true;
            char[] possibleDirections = new char[] {'N','S','E','W','M'};
            if (!possibleDirections.Contains(Char.ToUpper(Direction)))
            {
                ValidMove = false;
            }
            return ValidMove;
        }

        public CellReference SetPositionOfItem(char Item)
        {
            CellReference Position;
            do
            {
                Position = GetNewRandomPosition();
            } while (!Cavern.IsCellEmpty(Position));
            Cavern.PlaceItem(Position, Item);
            return Position;
        }

        public void SetUpGame()
        {
            CellReference Position;
            Cavern.Reset();
            if (!TrainingGame)
            {
                Position.NoOfCellsEast = 0;
                Position.NoOfCellsSouth = 0;
                Player.SetPosition(Position);
                Cavern.PlaceItem(Position, '*');
                Trap1.SetPosition(SetPositionOfItem('T'));
                Trap2.SetPosition(SetPositionOfItem('T'));
                Monster.SetPosition(SetPositionOfItem('M'));
                Flask.SetPosition(SetPositionOfItem('F'));
            }
            else
            {
                Position.NoOfCellsEast = 4;
                Position.NoOfCellsSouth = 2;
                Player.SetPosition(Position);
                Cavern.PlaceItem(Position, '*');
                Position.NoOfCellsEast = 6;
                Position.NoOfCellsSouth = 2;
                Trap1.SetPosition(Position);
                Cavern.PlaceItem(Position, 'T');
                Position.NoOfCellsEast = 4;
                Position.NoOfCellsSouth = 3;
                Trap2.SetPosition(Position);
                Cavern.PlaceItem(Position, 'T');
                Position.NoOfCellsEast = 4;
                Position.NoOfCellsSouth = 0;
                Monster.SetPosition(Position);
                Cavern.PlaceItem(Position, 'M');
                Position.NoOfCellsEast = 3;
                Position.NoOfCellsSouth = 1;
                Flask.SetPosition(Position);
                Cavern.PlaceItem(Position, 'F');
            }
        }

        public CellReference GetNewRandomPosition()
        {
            CellReference Position;
            Random rnd = new Random();
            Position.NoOfCellsSouth = rnd.Next(0, NS + 1);
            Position.NoOfCellsEast = rnd.Next(0, WE + 1);
            return Position;
        }
    }
}