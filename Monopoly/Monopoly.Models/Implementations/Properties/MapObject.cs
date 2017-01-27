using System;
using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public abstract class MapObject : IMapObject
    {
        private MapObjectType objectType;

        public MapObject(MapObjectType objectType)
        {
            this.ObjectType = objectType;
        }

        public MapObjectType ObjectType
        {
            get { return this.objectType; }
            set { this.objectType = value; }
        }
    }
}
