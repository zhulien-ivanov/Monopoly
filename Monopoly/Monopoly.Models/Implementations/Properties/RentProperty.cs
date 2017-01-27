using Monopoly.Models.Contracts.Players;
using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public abstract class RentProperty : Property, IRentProperty
    {
        private int rentPrice;

        public RentProperty(string name, int price, int mortgageValue, IParticipant owner, int rentPrice, MapObjectType objectType) : base(name, price, mortgageValue, owner, objectType)
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
