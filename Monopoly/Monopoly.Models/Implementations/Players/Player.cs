using System.Collections.Generic;

using Monopoly.Models.Contracts.Cards;
using Monopoly.Models.Contracts.Players;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Players
{
    public class Player : Participant, IPlayer
    {
        private string name;
        private int money;
        private PlayerColour colour;
        private List<ICard> cards;

        public Player(string name, int money, PlayerColour colour)
        {
            this.Name = name;
            this.Money = money;
            this.Colour = colour;

            this.Cards = new List<ICard>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Money
        {
            get { return this.money; }
            set { this.money = value; }
        }

        public PlayerColour Colour
        {
            get { return this.colour; }
            set { this.colour = value; }
        }

        public List<ICard> Cards
        {
            get { return this.cards; }
            set { this.cards = value; }
        }
    }
}
