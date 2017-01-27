using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public class SpecialObject : MapObject, ISpecialObject
    {
        public SpecialObject(string name, MapObjectType objectType) : base(name, objectType)
        {
        }
    }
}
