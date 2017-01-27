using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Contracts.Properties
{
    public interface IMapObject
    {
        MapObjectType ObjectType { get; set; }
    }
}
