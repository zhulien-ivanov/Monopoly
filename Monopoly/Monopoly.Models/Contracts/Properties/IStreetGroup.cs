using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Contracts.Properties
{
    public interface IPropertyColourGroup
    {
        StreetColour StreetColour { get; set; }

        int HousePrice { get; set; }

        int HotelPrice { get; set; }
    }
}
