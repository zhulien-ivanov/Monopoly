using Monopoly.Models.Contracts.Contexts;

namespace Monopoly.Models.Implementations.Contexts
{
    public class GameSettings : IGameSettings
    {
        private int playerStartMoney;
        private int availableHouses;
        private int availableHotels;
        private int availableTurnsInJail;
        private int jailReleaseTax;
        private int mortgageLiftTaxPercent;

        public GameSettings(int playerStartMoney = 1500, int availableHouses = 40, int availableHotels = 10, int availableTurnsInJail = 3, int jailReleaseTax = 50, int mortgageLiftTaxPercent = 10)
        {
            this.PlayerStartMoney = playerStartMoney;
            this.AvailableHouses = availableHouses;
            this.AvailableHotels = availableHotels;
            this.AvailableTurnsInJail = availableTurnsInJail;
            this.JailReleaseTax = jailReleaseTax;
            this.MortgageLiftTaxPercent = mortgageLiftTaxPercent;
        }

        public int PlayerStartMoney
        {
            get { return this.playerStartMoney; }
            private set { this.playerStartMoney = value; }
        }

        public int AvailableHouses
        {
            get { return this.availableHouses; }
            private set { this.availableHouses = value; }
        }

        public int AvailableHotels
        {
            get { return this.availableHotels; }
            private set { this.availableHotels = value; }
        }

        public int AvailableTurnsInJail
        {
            get { return this.availableTurnsInJail; }
            private set { this.availableTurnsInJail = value; }
        }

        public int JailReleaseTax
        {
            get { return this.jailReleaseTax; }
            private set { this.jailReleaseTax = value; }
        }

        public int MortgageLiftTaxPercent
        {
            get { return this.mortgageLiftTaxPercent; }
            private set { this.mortgageLiftTaxPercent = value; }
        }
    }
}
