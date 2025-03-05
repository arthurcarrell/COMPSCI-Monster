namespace CSPreALevelSkeleton
{
    public class Trap : Item
    {
        private Boolean Triggered;

        public Boolean GetTriggered()
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