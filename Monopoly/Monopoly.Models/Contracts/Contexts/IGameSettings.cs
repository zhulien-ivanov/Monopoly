namespace Monopoly.Models.Contracts.Contexts
{
    public interface IGameSettings
    {
        int PlayerStartMoney { get; }

        int AvailableHouses { get; }

        int AvailableHotels { get; }

        int AvailableTurnsInJail { get; }

        int JailReleaseTax { get; }

        int MortgagePercent { get; }

        int MortgageLiftTaxPercent { get; }
    }
}
