using static CSPreALevelSkeleton.CellReference;

namespace CSPreALevelSkeleton
{
    public class Enemy : Item
    {
        private bool Awake;

        public virtual void MakeMove(CellReference PlayerPosition)
        {
            if (NoOfCellsSouth < PlayerPosition.NoOfCellsSouth)
            {
                NoOfCellsSouth = NoOfCellsSouth + 1;
            }
            else
                if (NoOfCellsSouth > PlayerPosition.NoOfCellsSouth)
            {
                NoOfCellsSouth = NoOfCellsSouth - 1;
            }
            else
                if (NoOfCellsEast < PlayerPosition.NoOfCellsEast)
            {
                NoOfCellsEast = NoOfCellsEast + 1;
            }
            else
            {
                NoOfCellsEast = NoOfCellsEast - 1;
            }
        }

        public bool GetAwake()
        {
            return Awake;
        }

        public virtual void ToggleSleepStatus()
        {
            Awake = !Awake;
        }

        public Enemy()
        {
            Awake = false;
        }
    }
}