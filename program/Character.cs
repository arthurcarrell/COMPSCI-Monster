namespace CSPreALevelSkeleton
{
    public class Character : Item
    {
        public void MakeMove(char Direction)
        {
            switch (Direction)
            {
                case 'N':
                    NoOfCellsSouth = NoOfCellsSouth - 1;
                    break;
                case 'S':
                    NoOfCellsSouth = NoOfCellsSouth + 1;
                    break;
                case 'W':
                    NoOfCellsEast = NoOfCellsEast - 1;
                    break;
                case 'E':
                    NoOfCellsEast = NoOfCellsEast + 1;
                    break;
            }
        }
    }
}