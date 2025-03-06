using static CSPreALevelSkeleton.Program;

namespace CSPreALevelSkeleton 
{
    public class Item
    {
        protected int NoOfCellsEast;
        protected int NoOfCellsSouth;

        public CellReference GetPosition()
        {
            CellReference Position;
            Position.NoOfCellsEast = NoOfCellsEast;
            Position.NoOfCellsSouth = NoOfCellsSouth;
            return Position;
        }

        public void SetPosition(CellReference Position)
        {
            NoOfCellsEast = Position.NoOfCellsEast;
            NoOfCellsSouth = Position.NoOfCellsSouth;
        }

        public bool CheckIfSameCell(CellReference Position)
        {
            if (NoOfCellsEast == Position.NoOfCellsEast && NoOfCellsSouth == Position.NoOfCellsSouth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}