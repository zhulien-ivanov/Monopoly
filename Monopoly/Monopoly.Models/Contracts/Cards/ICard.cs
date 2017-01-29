using Monopoly.Models.Contracts.Contexts;

using Monopoly.Models.Enumerations;

using Monopoly.Models.Helpers;

namespace Monopoly.Models.Contracts.Cards
{
    public interface ICard
    {
        string Text { get; }

        CardType Type { get; }

        bool IsTakeable { get; }

        CardEffectResult Execute(IGameContext gameContext);
    }
}
