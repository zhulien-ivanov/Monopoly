using Monopoly.Models.Contracts.Players;
using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public class UtilityProperty : Property, IUtilityProperty
    {
        public UtilityProperty(string name, int price, IParticipant owner) : base(name, price, owner, MapObjectType.UtilityProperty)
        {
        }
    }
}
