using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public class UtilityProperty : Property, IUtilityProperty
    {
        public UtilityProperty(string name, int price, int mortgageValue) : base(name, price, mortgageValue, MapObjectType.UtilityProperty)
        {
        }
    }
}
