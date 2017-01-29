using System.Collections.Generic;

using Monopoly.Models.Contracts.Players;
using Monopoly.Models.Contracts.Properties;

using Monopoly.Models.Helpers;

namespace Monopoly.Models.Contracts.Contexts
{
    public interface IGameContext
    {
        IBank Bank { get; }

        List<IMapObject> MapObjects { get; }

        List<IPlayer> Players { get; }

        IDictionary<IPlayer, int> PlayerPositions { get; }

        IDictionary<IPlayer, PlayerStatusInformation> PlayerStatuses { get; }

        IPlayer CurrentPlayer { get; }
    }
}
