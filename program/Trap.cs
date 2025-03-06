namespace CSPreALevelSkeleton
{
    public class Trap : Item
    {
        private bool Triggered;

        public bool GetTriggered()
        {
            return Triggered;
        }

        public Trap()
        {
            Triggered = false;
        }

        public void ToggleTrap()
        {
            Triggered = !Triggered;
        }
    }
}