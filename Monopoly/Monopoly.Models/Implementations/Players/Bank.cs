using Monopoly.Models.Contracts.Players;

namespace Monopoly.Models.Implementations.Players
{
    public class Bank : Participant, IBank
    {
        private int housesCount;
        private int hotelsCount;
        
        public Bank(int housesCount, int hotelsCount)
        {
            this.HousesCount = housesCount;
            this.HotelsCount = hotelsCount;
        }

        public int HousesCount
        {
            get { return this.housesCount; }
            set { this.housesCount = value; }
        }

        public int HotelsCount
        {
            get { return this.hotelsCount; }
            set { this.hotelsCount = value; }
        }
    }
}
