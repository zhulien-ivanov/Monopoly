using Monopoly.Models.Contracts.Players;

namespace Monopoly.Models.Contracts.Properties
{
    public interface IProperty : IMapObject
    {
        int Price { get; set; }

        IParticipant Owner { get; set; }

        bool IsMortgaged { get; set; }
    }
}
