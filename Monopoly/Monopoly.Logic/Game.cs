using System.Collections.Generic;

using Monopoly.Models.Contracts.Cards;
using Monopoly.Models.Contracts.Contexts;
using Monopoly.Models.Contracts.Players;
using Monopoly.Models.Contracts.Properties;

using Monopoly.Models.Enumerations;

using Monopoly.Models.Implementations.Players;
using Monopoly.Models.Implementations.Properties;

namespace Monopoly.Logic
{
    public class Game
    {
        private IBank bank;
        private List<IMapObject> mapObjects;
        private Queue<ICard> chanceCards;
        private Queue<ICard> communityChestCards;

        private List<IPlayer> participants;        

        private IDictionary<IPlayer, int> playerPositions;
        
        public Game(IGameSettings gameSettings, IDictionary<string, PlayerColour> playerInformation)
        {
            this.bank = new Bank(gameSettings.AvailableHouses, gameSettings.AvailableHotels);
            this.mapObjects = this.CreateProperties(this.bank, gameSettings);



            //----------------------------------------------------
            // Create all cards
            // Zero all variables

            // Create players
            //----------------------------------------------------
        }

        private List<IMapObject> CreateProperties(IBank bank, IGameSettings gameSettings)
        {            
            var go = new SpecialObject("GO", MapObjectType.GO);

            var brownStreetGroup = new StreetGroup(StreetColour.Brown, 30, 30);
            var oldKentRoad = new StreetProperty("Old Kent Road", 60, bank, 2, brownStreetGroup, 10, 30, 90, 160, 250);

            var communityChest1 = new SpecialObject("Community Chest", MapObjectType.CommunityChest);

            var whitechapelRoad = new StreetProperty("Whitechapel Road", 60, bank, 4, brownStreetGroup, 20, 60, 180, 320, 450);

            var incomeTax = new SpecialObject("Income Tax", MapObjectType.IncomeTax);

            var kingsCrossStation = new RailwayStationProperty("Kings Cross Station", 200, bank, 25);

            var lightBlueStreetGroup = new StreetGroup(StreetColour.LightBlue, 50, 50);
            var theAngelIslington = new StreetProperty("The Angel Islington", 100, bank, 6, lightBlueStreetGroup, 30, 90, 270, 400, 550);

            var chance1 = new SpecialObject("Chance", MapObjectType.Chance);

            var eustonRoad = new StreetProperty("Euston Road", 100, bank, 6, lightBlueStreetGroup, 30, 90, 270, 400, 550);
            var pentonvilleRoad = new StreetProperty("Pentonville Road", 120, bank, 8, lightBlueStreetGroup, 40, 100, 300, 450, 600);

            var jail = new SpecialObject("Jail", MapObjectType.Jail);

            var purpleStreetGroup = new StreetGroup(StreetColour.Purple, 100, 100);
            var pallMall = new StreetProperty("Pall Mall", 140, bank, 10, purpleStreetGroup, 50, 150, 450, 625, 750);

            var electricCompany = new UtilityProperty("Electric Company", 150, bank);

            var whitehall = new StreetProperty("Whitehall", 140, bank, 10, purpleStreetGroup, 50, 150, 450, 625, 750);
            var northumberlandAvenue = new StreetProperty("Northumberland Avenue", 160, bank, 12, purpleStreetGroup, 60, 180, 500, 700, 900);

            var maryleboneStation = new RailwayStationProperty("Marylebone Station", 200, bank, 25);

            var orangeStreetGroup = new StreetGroup(StreetColour.Orange, 100, 100);
            var bowStreet = new StreetProperty("Bow Street", 180, bank, 14, orangeStreetGroup, 70, 200, 550, 750, 950);

            var communityChest2 = new SpecialObject("Community Chest", MapObjectType.CommunityChest);

            var marlboroughStreet = new StreetProperty("Marlborough Street", 180, bank, 14, orangeStreetGroup, 70, 200, 550, 750, 950);
            var vineStreet = new StreetProperty("Vine Street", 200, bank, 16, orangeStreetGroup, 80, 220, 600, 800, 1000);

            var freeParking = new SpecialObject("Free Parking", MapObjectType.FreeParking);

            var redStreetGroup = new StreetGroup(StreetColour.Red, 150, 150);
            var theStrand = new StreetProperty("The Strand", 220, bank, 18, redStreetGroup, 90, 250, 700, 875, 1050);

            var chance2 = new SpecialObject("Chance", MapObjectType.Chance);

            var fleetStreet = new StreetProperty("Fleet Street", 220, bank, 18, redStreetGroup, 90, 250, 700, 875, 1050);
            var trafalgarSquare = new StreetProperty("Trafalgar Square", 240, bank, 20, redStreetGroup, 100, 300, 750, 925, 1100);

            var fenchurchStStation = new RailwayStationProperty("Fenchurch St Station", 200, bank, 25);

            var yellowStreetGroup = new StreetGroup(StreetColour.Yellow, 150, 150);
            var leicesterSquare = new StreetProperty("Leicester Square", 260, bank, 22, yellowStreetGroup, 110, 330, 800, 975, 1150);
            var coventryStreet = new StreetProperty("Coventry Street", 260, bank, 22, yellowStreetGroup, 110, 330, 800, 975, 1150);

            var waterWorks = new UtilityProperty("Water Works", 150, bank);

            var piccadilly = new StreetProperty("Piccadilly", 280, bank, 24, yellowStreetGroup, 120, 360, 850, 1025, 1200);

            var goToJail = new SpecialObject("Go To Jail", MapObjectType.GoToJail);

            var greenStreetGroup = new StreetGroup(StreetColour.Green, 200, 200);
            var regentStreet = new StreetProperty("Regent Street", 300, bank, 26, greenStreetGroup, 130, 390, 900, 1100, 1275);
            var oxfordStreet = new StreetProperty("Oxford Street", 300, bank, 26, greenStreetGroup, 130, 390, 900, 1100, 1275);

            var communityChest3 = new SpecialObject("Community Chest", MapObjectType.CommunityChest);

            var bondStreet = new StreetProperty("Bond Street", 320, bank, 28, greenStreetGroup, 150, 450, 1000, 1200, 1400);

            var liverpoolStreetStation = new RailwayStationProperty("Liverpool Street Station", 200, bank, 25);

            var chance3 = new SpecialObject("Chance", MapObjectType.Chance);

            var darkBlueStreetGroup = new StreetGroup(StreetColour.DarkBlue, 200, 200);
            var parkLane = new StreetProperty("Park Lane", 350, bank, 35, darkBlueStreetGroup, 175, 500, 1100, 1300, 1500);

            var luxuryTax = new SpecialObject("Luxury Tax", MapObjectType.LuxuryTax);

            var mayfair = new StreetProperty("Mayfair", 400, bank, 50, darkBlueStreetGroup, 200, 600, 1400, 1700, 2000);

            var propertiesList = new List<IMapObject>(40)
            {
                go,
                oldKentRoad,
                communityChest1,
                whitechapelRoad,
                incomeTax,
                kingsCrossStation,
                theAngelIslington,
                chance1,
                eustonRoad,
                pentonvilleRoad,
                jail,
                pallMall,
                electricCompany,
                whitehall,
                northumberlandAvenue,
                maryleboneStation,
                bowStreet,
                communityChest2,
                marlboroughStreet,
                vineStreet,
                freeParking,
                theStrand,
                chance2,
                fleetStreet,
                trafalgarSquare,
                fenchurchStStation,
                leicesterSquare,
                coventryStreet,
                waterWorks,
                piccadilly,
                goToJail,
                regentStreet,
                oxfordStreet,
                communityChest3,
                bondStreet,
                liverpoolStreetStation,
                chance3,
                parkLane,
                luxuryTax,
                mayfair
            };

            return propertiesList;
        }
    }
}
