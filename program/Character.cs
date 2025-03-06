namespace CSPreALevelSkeleton
{
    public class Character : Item
    {

        private bool IsOutOfBounds(int squareToMove, int bound) 
        {
            bool outOfBounds = false;

            if (squareToMove > bound) outOfBounds = true;
            if (squareToMove < 0) outOfBounds = true;
            
            return outOfBounds;
        }
        public void MakeMove(char Direction)
        {
            switch (Direction)
            {
                case 'N':
                    if(!IsOutOfBounds(NoOfCellsSouth-1, Program.NS)) {
                        NoOfCellsSouth--;
                    }
                    break;
                case 'S':
                    if(!IsOutOfBounds(NoOfCellsSouth+1, Program.NS)) {
                        NoOfCellsSouth++;
                    }
                    break;
                case 'W':
                    if(!IsOutOfBounds(NoOfCellsEast-1, Program.WE)) {
                        NoOfCellsEast--;
                    }
                    break;
                case 'E':
                    if(!IsOutOfBounds(NoOfCellsEast+1, Program.WE)) {
                        NoOfCellsEast++;
                    }
                    break;
            }
        }
    }
}