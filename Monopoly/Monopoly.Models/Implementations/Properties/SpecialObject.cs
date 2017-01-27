using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public class SpecialObject : MapObject, ISpecialObject
    {
        public SpecialObject(MapObjectType objectType) : base(objectType)
        {
        }
    }
}
