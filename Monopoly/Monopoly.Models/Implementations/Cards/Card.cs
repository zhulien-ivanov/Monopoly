using System;

using Monopoly.Models.Contracts.Cards;
using Monopoly.Models.Contracts.Contexts;

using Monopoly.Models.Enumerations;

using Monopoly.Models.Helpers;

namespace Monopoly.Models.Implementations.Cards
{
    public class Card : ICard
    {
        private string text;
        private CardType type;
        private bool isTakeable;
        private Func<IGameContext, CardEffectResult> cardEffect;

        public Card(string text, CardType type, bool isTakeable, Func<IGameContext, CardEffectResult> cardEffect)
        {
            this.Text = text;
            this.Type = type;
            this.IsTakeable = isTakeable;
            this.cardEffect = cardEffect;
        }

        public string Text
        {
            get { return this.text; }
            private set { this.text = value; }
        }

        public CardType Type
        {
            get { return this.type; }
            private set { this.type = value; }
        }

        public bool IsTakeable
        {
            get { return this.isTakeable; }
            private set { this.isTakeable = value; }
        }

        public CardEffectResult Execute(IGameContext gameContext)
        {
            return cardEffect(gameContext);
        }
    }
}
