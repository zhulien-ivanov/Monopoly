using System.Collections.Generic;

using Monopoly.Models.Contracts.Players;
using Monopoly.Models.Contracts.Properties;

namespace Monopoly.Models.Implementations.Players
{
    public abstract class Participant : IParticipant
    {
        private List<IProperty> properties;

        public Participant()
        {
            this.Properties = new List<IProperty>();
        }

        public List<IProperty> Properties
        {
            get { return this.properties; }
            set { this.properties = value; }
        }
    }
}
