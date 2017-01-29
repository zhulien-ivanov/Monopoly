using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Helpers
{
    public class PlayerStatusInformation
    {
        private PlayerStatus playerStatus;
        private int turn;

        public PlayerStatusInformation()
        {
            this.PlayerStatus = PlayerStatus.Active;
            this.Turn = 0;
        }

        public PlayerStatus PlayerStatus
        {
            get { return this.playerStatus; }
            set { this.playerStatus = value; }
        }

        public int Turn
        {
            get { return this.turn; }
            set { this.turn = value; }
        }
    }
}
