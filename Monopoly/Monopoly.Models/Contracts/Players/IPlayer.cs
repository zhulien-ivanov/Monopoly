using System.Collections.Generic;

using Monopoly.Models.Contracts.Cards;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Contracts.Players
{
    public interface IPlayer : IParticipant
    {
        string Name { get; set; }

        int Money { get; set; }

        PlayerColour Colour { get; set; }

        List<ICard> Cards { get; set; }
    }
}
