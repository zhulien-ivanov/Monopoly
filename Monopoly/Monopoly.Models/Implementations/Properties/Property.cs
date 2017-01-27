using Monopoly.Models.Contracts.Players;
using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public abstract class Property : MapObject, IProperty
    {
        private int price;
        private IParticipant owner;
        private bool isMortgaged;

        protected Property(string name, int price, IParticipant owner, MapObjectType objectType) : base(name, objectType)
        {
            this.Price = price;
            this.Owner = owner;
            this.IsMortgaged = false;
        }

        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public IParticipant Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public bool IsMortgaged
        {
            get { return this.isMortgaged; }
            set { this.isMortgaged = value; }
        }
    }
}
