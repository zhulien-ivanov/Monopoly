using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public abstract class MapObject : IMapObject
    {
        private string name;
        private MapObjectType objectType;

        public MapObject(string name, MapObjectType objectType)
        {
            this.Name = name;
            this.ObjectType = objectType;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public MapObjectType ObjectType
        {
            get { return this.objectType; }
            set { this.objectType = value; }
        }
    }
}
