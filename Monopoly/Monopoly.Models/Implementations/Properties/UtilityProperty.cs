using Monopoly.Models.Contracts.Players;
using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public class UtilityProperty : Property, IUtilityProperty
    {
        public UtilityProperty(string name, int price, int mortgageValue, IParticipant owner) : base(name, price, mortgageValue, owner, MapObjectType.UtilityProperty)
        {
        }
    }
}
