using Monopoly.Models.Contracts.Properties;

namespace Monopoly.Models.Implementations.Properties
{
    public abstract class RentProperty : Property, IRentProperty
    {
        private int rentPrice;

        public RentProperty(string name, int price, int mortgageValue, int rentPrice) : base(name, price, mortgageValue)
        {
            this.RentPrice = rentPrice;
        }

        public int RentPrice
        {
            get { return this.rentPrice; }
            set { this.rentPrice = value; }
        }
    }
}
