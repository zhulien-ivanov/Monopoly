using System.Collections.Generic;

using Monopoly.Models.Contracts.Contexts;
using Monopoly.Models.Contracts.Players;
using Monopoly.Models.Contracts.Properties;

using Monopoly.Models.Helpers;

namespace Monopoly.Models.Implementations.Contexts
{
    public class GameContext : IGameContext
    {
        private IBank bank;
        private List<IMapObject> mapObjects;
        private List<IPlayer> players;
        IDictionary<IPlayer, int> playerPositions;
        IDictionary<IPlayer, PlayerStatusInformation> playerStatuses;
        private IPlayer currentPlayer;

        public GameContext(IBank bank, List<IMapObject> mapObjects, List<IPlayer> players, IDictionary<IPlayer, int> playerPositions, IDictionary<IPlayer, PlayerStatusInformation> playerStatuses, IPlayer currentPlayer)
        {
            this.Bank = bank;
            this.MapObjects = mapObjects;
            this.Players = players;
            this.PlayerPositions = playerPositions;
            this.PlayerStatuses = playerStatuses;
            this.CurrentPlayer = currentPlayer;
        }

        public IBank Bank
        {
            get { return this.bank; }
            private set { this.bank = value; }
        }

        public List<IMapObject> MapObjects
        {
            get { return this.mapObjects; }
            private set { this.mapObjects = value; }
        }

        public List<IPlayer> Players
        {
            get { return this.players; }
            private set { this.players = value; }
        }

        public IDictionary<IPlayer, int> PlayerPositions
        {
            get { return this.playerPositions; }
            private set { this.playerPositions = value; }
        }

        public IDictionary<IPlayer, PlayerStatusInformation> PlayerStatuses
        {
            get { return this.playerStatuses; }
            private set { this.playerStatuses = value; }
        }

        public IPlayer CurrentPlayer
        {
            get { return this.currentPlayer; }
            set { this.currentPlayer = value; }
        }
    }
}
