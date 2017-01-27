using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Contracts.Cards
{
    public interface ICard
    {
        string Text { get; set; }

        CardType Type { get; set; }
    }
}
