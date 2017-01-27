using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public class RailwayStationProperty : RentProperty, IRailwayStationProperty
    {
        public RailwayStationProperty(string name, int price, int mortgageValue, int rentPrice) : base(name, price, mortgageValue, rentPrice, MapObjectType.RailwayStationProperty)
        {
        }
    }
}
