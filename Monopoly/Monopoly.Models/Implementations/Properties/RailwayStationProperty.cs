using System;
using Monopoly.Models.Contracts.Properties;

namespace Monopoly.Models.Implementations.Properties
{
    public class RailwayStationProperty : Property, IRailwayStationProperty
    {
        private int rentPrice;

        public RailwayStationProperty(string name, int price, int mortgageValue, int rentPrice) : base(name, price, mortgageValue)
        {
            this.RentPrice = rentPrice;
        }

        public int RentPrice
        {
            get { return this.rentPrice; }
            set { this.rentPrice = value; }
        }

        public override int GetRentValue()
        {
            // Check Railway properties count of owner
            // switch by value (1, 2, 3, 4)

            throw new NotImplementedException();
        }
    }
}
