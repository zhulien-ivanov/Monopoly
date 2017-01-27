using Monopoly.Models.Contracts.Players;
using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public class RailwayStationProperty : RentProperty, IRailwayStationProperty
    {
        public RailwayStationProperty(string name, int price, int mortgageValue, IParticipant owner, int rentPrice) : base(name, price, mortgageValue, owner, rentPrice, MapObjectType.RailwayStationProperty)
        {
        }
    }
}
