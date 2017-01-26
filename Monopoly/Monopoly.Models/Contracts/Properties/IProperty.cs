using Monopoly.Models.Contracts.Players;

namespace Monopoly.Models.Contracts.Properties
{
    public interface IProperty
    {
        string Name { get; set; }

        int Price { get; set; }

        int MortgageValue { get; set; }

        IParticipant Owner { get; set; }

        bool IsMortgaged { get; set; }
    }
}
