using Monopoly.Models.Contracts.Properties;
using Monopoly.Models.Enumerations;

namespace Monopoly.Models.Implementations.Properties
{
    public class StreetProperty : RentProperty, IStreetProperty
    {
        private IStreetGroup streetGroup;
        private int oneHouseRentValue;
        private int twoHousesRentValue;
        private int threeHousesRentValue;
        private int fourHousesRentValue;
        private int hotelRentValue;
        private int houses;
        private int hotels;

        public StreetProperty(string name, int price, int mortgageValue, int rentPrice, IStreetGroup streetGroup, int oneHouseRentValue, int twoHousesRentValue, int threeHousesRentValue, int fourHousesRentValue, int hotelRentValue) : base(name, price, mortgageValue, rentPrice, MapObjectType.StreetProperty)
        {
            this.StreetGroup = streetGroup;
            this.OneHouseRentValue = oneHouseRentValue;
            this.TwoHousesRentValue = twoHousesRentValue;
            this.ThreeHousesRentValue = threeHousesRentValue;
            this.FourHousesRentValue = fourHousesRentValue;
            this.HotelRentValue = hotelRentValue;

            this.Houses = 0;
            this.Hotels = 0;
        }

        public IStreetGroup StreetGroup
        {
            get { return this.streetGroup; }
            set { this.streetGroup = value; }
        }

        public int OneHouseRentValue
        {
            get { return this.oneHouseRentValue; }
            set { this.oneHouseRentValue = value; }
        }

        public int TwoHousesRentValue
        {
            get { return this.twoHousesRentValue; }
            set { this.twoHousesRentValue = value; }
        }

        public int ThreeHousesRentValue
        {
            get { return this.threeHousesRentValue; }
            set { this.threeHousesRentValue = value; }
        }

        public int FourHousesRentValue
        {
            get { return this.fourHousesRentValue; }
            set { this.fourHousesRentValue = value; }
        }

        public int HotelRentValue
        {
            get { return this.hotelRentValue; }
            set { this.hotelRentValue = value; }
        }

        public int Houses
        {
            get { return this.houses; }
            set { this.houses = value; }
        }

        public int Hotels
        {
            get { return this.hotels; }
            set { this.hotels = value; }
        }
    }
}
