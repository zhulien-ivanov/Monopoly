using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Contracts.Properties
{
    public interface IMapObject
    {
        string Name { get; set; }

        MapObjectType ObjectType { get; set; }
    }
}
