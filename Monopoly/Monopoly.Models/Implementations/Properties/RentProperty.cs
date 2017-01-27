using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public abstract class RentProperty : Property, IRentProperty
    {
        private int rentPrice;

        public RentProperty(string name, int price, int mortgageValue, int rentPrice, MapObjectType objectType) : base(name, price, mortgageValue, objectType)
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
