using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Contracts.Properties
{
    public interface IStreetGroup
    {
        StreetColour StreetColour { get; set; }

        int HousePrice { get; set; }

        int HotelPrice { get; set; }
    }
}
