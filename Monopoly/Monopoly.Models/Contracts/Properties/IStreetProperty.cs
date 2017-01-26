namespace Monopoly.Models.Contracts.Properties
{
    public interface IStreetProperty : IProperty, IRentProperty
    {
        IStreetGroup StreetGroup { get; set; }

        int OneHouseRentValue { get; set; }

        int TwoHousesRentValue { get; set; }

        int ThreeHousesRentValue { get; set; }

        int FourHousesRentValue { get; set; }

        int HotelRentValue { get; set; }

        int Houses { get; set; }

        int Hotels { get; set; }
    }
}
