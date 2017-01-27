using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public class StreetGroup : IStreetGroup
    {
        private StreetColour streetColour;
        private int housePrice;
        private int hotelPrice;

        public StreetGroup(StreetColour streetColour, int housePrice, int hotelPrice)
        {
            this.StreetColour = streetColour;
            this.HousePrice = housePrice;
            this.HotelPrice = hotelPrice;
        }

        public StreetColour StreetColour
        {
            get { return this.streetColour; }
            set { this.streetColour = value; }
        }

        public int HousePrice
        {
            get { return this.housePrice; }
            set { this.housePrice = value; }
        }

        public int HotelPrice
        {
            get { return this.hotelPrice; }
            set { this.hotelPrice = value; }
        }
    }
}
