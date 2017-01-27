using Monopoly.Models.Contracts.Cards;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Cards
{
    public class Card : ICard
    {
        private string text;
        private CardType type;

        public Card(string text, CardType type)
        {
            this.Text = text;
            this.Type = type;
        }

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        public CardType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}
