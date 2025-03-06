using static CSPreALevelSkeleton.Program;

namespace CSPreALevelSkeleton {
    public class Grid
    {
        private char[,] CavernState = new char[NS + 1, WE + 1];

        public void Reset()
        {
            int Count1;
            int Count2;
            for (Count1 = 0; Count1 <= NS; Count1++)
            {
                for (Count2 = 0; Count2 <= WE; Count2++)
                {
                        CavernState[Count1, Count2] = ' ';
                }
            }
        }

        public void Display(bool MonsterAwake)
        {
            // clear the console to make it more easier to read.
            Console.Clear();

            int Count1;
            int Count2;
            for (Count1 = 0; Count1 <= NS; Count1++)
            {
                Console.WriteLine(" ------------- ");
                for (Count2 = 0; Count2 <= WE; Count2++)
                {
                    if (CavernState[Count1, Count2] == ' ' || CavernState[Count1, Count2] == '*' || (CavernState[Count1, Count2] == 'M' && MonsterAwake))
                    {
                        Console.Write("|" + CavernState[Count1, Count2]);
                    }
                    else
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(" ------------- ");
            Console.WriteLine();
        }

        public void PlaceItem(CellReference Position, char Item)
        {
            CavernState[Position.NoOfCellsSouth, Position.NoOfCellsEast] = Item;
        }

        public bool IsCellEmpty(CellReference Position)
        {
            if (CavernState[Position.NoOfCellsSouth, Position.NoOfCellsEast] == ' ')
                return true;
            else
                return false;
        }
    }
}