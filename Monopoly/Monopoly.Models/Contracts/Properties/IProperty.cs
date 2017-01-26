namespace Monopoly.Models.Contracts.Properties
{
    public interface IProperty
    {
        string Name { get; set; }

        int Price { get; set; }

        int MortgageValue { get; set; }

        IPlayer Owner { get; set; }

        bool IsMortgaged { get; set; }
    }
}
