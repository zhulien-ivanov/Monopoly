using Monopoly.Models.Contracts.Players;
using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public abstract class Property : MapObject, IProperty
    {
        private string name;
        private int price;
        private int mortgageValue;
        private IParticipant owner;
        private bool isMortgaged;

        protected Property(string name, int price, int mortgageValue, MapObjectType objectType) : base(objectType)
        {
            this.Name = name;
            this.Price = price;
            this.MortgageValue = mortgageValue;

            //this.owner = Bank;
            this.IsMortgaged = false;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public int MortgageValue
        {
            get { return this.mortgageValue; }
            set { this.mortgageValue = value; }
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
