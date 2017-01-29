namespace Monopoly.Models.Helpers
{
    public class CardEffectResult
    {
        private bool shouldCheckIfGOWasPassed;
        private bool shouldCheckForPropertyAvailability;
        private bool shouldCheckForNegativeBalance;
        private bool shouldRollDice;

        public CardEffectResult(bool shouldCheckIfGOWasPassed, bool shouldCheckForPropertyAvailability, bool shouldCheckForNegativeBalance, bool shouldRollDice)
        {
            this.ShouldCheckIfGOWasPassed = shouldCheckIfGOWasPassed;
            this.ShouldCheckForPropertyAvailability = shouldCheckForPropertyAvailability;
            this.ShouldCheckForNegativeBalance = shouldCheckForNegativeBalance;
            this.ShouldRollDice = shouldRollDice;
        }

        public bool ShouldCheckIfGOWasPassed
        {
            get { return this.shouldCheckIfGOWasPassed; }
            private set { this.shouldCheckIfGOWasPassed = value; }
        }

        public bool ShouldCheckForPropertyAvailability
        {
            get { return this.shouldCheckForPropertyAvailability; }
            private set { this.shouldCheckForPropertyAvailability = value; }            
        }

        public bool ShouldCheckForNegativeBalance
        {
            get { return this.shouldCheckForNegativeBalance; }
            private set { this.shouldCheckForNegativeBalance = value; }
        }

        public bool ShouldRollDice
        {
            get { return this.shouldRollDice; }
            private set { this.shouldRollDice = value; }
        }
    }
}
