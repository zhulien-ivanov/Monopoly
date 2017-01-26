using System.Collections.Generic;

using Monopoly.Models.Contracts.Properties;

namespace Monopoly.Models.Contracts.Players
{
    public interface IParticipant
    {
        List<IProperty> Properties { get; set; }
    }
}
