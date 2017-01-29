using System.Linq;
using System.Collections.Generic;

using Monopoly.Models.Contracts.Cards;
using Monopoly.Models.Contracts.Contexts;
using Monopoly.Models.Contracts.Players;
using Monopoly.Models.Contracts.Properties;

using Monopoly.Models.Enumerations;

using Monopoly.Models.Helpers;

using Monopoly.Models.Implementations.Cards;
using Monopoly.Models.Implementations.Contexts;
using Monopoly.Models.Implementations.Players;
using Monopoly.Models.Implementations.Properties;

namespace Monopoly.Logic
{
    public class Game
    {
        private IGameSettings gameSettings;

        private IBank bank;
        private List<IMapObject> mapObjects;
        private Queue<ICard> chanceCards;
        private Queue<ICard> communityChestCards;

        private List<IPlayer> players;

        private IDictionary<IPlayer, int> playerPositions;
        private IDictionary<IPlayer, PlayerStatusInformation> playerStatuses;

        private IPlayer currentPlayer;

        public Game(IGameSettings gameSettings, IDictionary<string, PlayerColour> playerInformation)
        {
            this.gameSettings = gameSettings;

            this.bank = new Bank(this.gameSettings.AvailableHouses, this.gameSettings.AvailableHotels);
            this.mapObjects = this.CreateProperties();

            this.chanceCards = this.CreateChanceCards();
            this.communityChestCards = this.CreateCommunityChestCards();

            this.players = this.CreatePlayers(playerInformation, this.gameSettings);

            this.SetupPlayerPositions();
            this.SetupPlayerStatuses();
        }

        private List<IMapObject> CreateProperties()
        {
            var go = new SpecialObject("GO", MapObjectType.GO);

            var brownStreetGroup = new StreetGroup(StreetColour.Brown, 30, 30);
            var oldKentRoad = new StreetProperty("Old Kent Road", 60, this.bank, 2, brownStreetGroup, 10, 30, 90, 160, 250);

            var communityChest1 = new SpecialObject("Community Chest", MapObjectType.CommunityChest);

            var whitechapelRoad = new StreetProperty("Whitechapel Road", 60, this.bank, 4, brownStreetGroup, 20, 60, 180, 320, 450);

            var incomeTax = new SpecialObject("Income Tax", MapObjectType.IncomeTax);

            var kingsCrossStation = new RailwayStationProperty("Kings Cross Station", 200, this.bank, 25);

            var lightBlueStreetGroup = new StreetGroup(StreetColour.LightBlue, 50, 50);
            var theAngelIslington = new StreetProperty("The Angel Islington", 100, this.bank, 6, lightBlueStreetGroup, 30, 90, 270, 400, 550);

            var chance1 = new SpecialObject("Chance", MapObjectType.Chance);

            var eustonRoad = new StreetProperty("Euston Road", 100, this.bank, 6, lightBlueStreetGroup, 30, 90, 270, 400, 550);
            var pentonvilleRoad = new StreetProperty("Pentonville Road", 120, this.bank, 8, lightBlueStreetGroup, 40, 100, 300, 450, 600);

            var jail = new SpecialObject("Jail", MapObjectType.Jail);

            var purpleStreetGroup = new StreetGroup(StreetColour.Purple, 100, 100);
            var pallMall = new StreetProperty("Pall Mall", 140, this.bank, 10, purpleStreetGroup, 50, 150, 450, 625, 750);

            var electricCompany = new UtilityProperty("Electric Company", 150, this.bank);

            var whitehall = new StreetProperty("Whitehall", 140, this.bank, 10, purpleStreetGroup, 50, 150, 450, 625, 750);
            var northumberlandAvenue = new StreetProperty("Northumberland Avenue", 160, this.bank, 12, purpleStreetGroup, 60, 180, 500, 700, 900);

            var maryleboneStation = new RailwayStationProperty("Marylebone Station", 200, this.bank, 25);

            var orangeStreetGroup = new StreetGroup(StreetColour.Orange, 100, 100);
            var bowStreet = new StreetProperty("Bow Street", 180, this.bank, 14, orangeStreetGroup, 70, 200, 550, 750, 950);

            var communityChest2 = new SpecialObject("Community Chest", MapObjectType.CommunityChest);

            var marlboroughStreet = new StreetProperty("Marlborough Street", 180, this.bank, 14, orangeStreetGroup, 70, 200, 550, 750, 950);
            var vineStreet = new StreetProperty("Vine Street", 200, this.bank, 16, orangeStreetGroup, 80, 220, 600, 800, 1000);

            var freeParking = new SpecialObject("Free Parking", MapObjectType.FreeParking);

            var redStreetGroup = new StreetGroup(StreetColour.Red, 150, 150);
            var theStrand = new StreetProperty("The Strand", 220, this.bank, 18, redStreetGroup, 90, 250, 700, 875, 1050);

            var chance2 = new SpecialObject("Chance", MapObjectType.Chance);

            var fleetStreet = new StreetProperty("Fleet Street", 220, this.bank, 18, redStreetGroup, 90, 250, 700, 875, 1050);
            var trafalgarSquare = new StreetProperty("Trafalgar Square", 240, this.bank, 20, redStreetGroup, 100, 300, 750, 925, 1100);

            var fenchurchStStation = new RailwayStationProperty("Fenchurch St Station", 200, this.bank, 25);

            var yellowStreetGroup = new StreetGroup(StreetColour.Yellow, 150, 150);
            var leicesterSquare = new StreetProperty("Leicester Square", 260, this.bank, 22, yellowStreetGroup, 110, 330, 800, 975, 1150);
            var coventryStreet = new StreetProperty("Coventry Street", 260, this.bank, 22, yellowStreetGroup, 110, 330, 800, 975, 1150);

            var waterWorks = new UtilityProperty("Water Works", 150, this.bank);

            var piccadilly = new StreetProperty("Piccadilly", 280, this.bank, 24, yellowStreetGroup, 120, 360, 850, 1025, 1200);

            var goToJail = new SpecialObject("Go To Jail", MapObjectType.GoToJail);

            var greenStreetGroup = new StreetGroup(StreetColour.Green, 200, 200);
            var regentStreet = new StreetProperty("Regent Street", 300, this.bank, 26, greenStreetGroup, 130, 390, 900, 1100, 1275);
            var oxfordStreet = new StreetProperty("Oxford Street", 300, this.bank, 26, greenStreetGroup, 130, 390, 900, 1100, 1275);

            var communityChest3 = new SpecialObject("Community Chest", MapObjectType.CommunityChest);

            var bondStreet = new StreetProperty("Bond Street", 320, this.bank, 28, greenStreetGroup, 150, 450, 1000, 1200, 1400);

            var liverpoolStreetStation = new RailwayStationProperty("Liverpool Street Station", 200, this.bank, 25);

            var chance3 = new SpecialObject("Chance", MapObjectType.Chance);

            var darkBlueStreetGroup = new StreetGroup(StreetColour.DarkBlue, 200, 200);
            var parkLane = new StreetProperty("Park Lane", 350, this.bank, 35, darkBlueStreetGroup, 175, 500, 1100, 1300, 1500);

            var luxuryTax = new SpecialObject("Luxury Tax", MapObjectType.LuxuryTax);

            var mayfair = new StreetProperty("Mayfair", 400, this.bank, 50, darkBlueStreetGroup, 200, 600, 1400, 1700, 2000);

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

        private Queue<ICard> CreateChanceCards()
        {
            var advanceToMayfair = new Card("Advance to Mayfair", CardType.Chance, false, x =>
            {
                x.PlayerPositions[x.CurrentPlayer] = x.MapObjects.FindIndex(y => y.Name == "Mayfair");

                return new CardEffectResult(true, true, false, false);
            });

            var advanceToGo = new Card("Advance to GO", CardType.Chance, false, x =>
            {
                x.PlayerPositions[x.CurrentPlayer] = x.MapObjects.FindIndex(y => y.Name == "GO");
                x.CurrentPlayer.Money += 200;

                return new CardEffectResult(false, false, false, false);
            });

            var repairAssessment = new Card("You are Assessed for Street Repairs $40 per House $115 per Hotel", CardType.Chance, false, x =>
            {
                int housesCount = 0;
                int hotelsCount = 0;

                var playerStreetProperties = x.CurrentPlayer.Properties.Where(y => y.ObjectType == MapObjectType.StreetProperty);

                foreach (var property in playerStreetProperties)
                {
                    var streetProperty = property as StreetProperty;

                    housesCount += streetProperty.Houses;
                    hotelsCount += streetProperty.Hotels;
                }

                var fine = (housesCount * 40) + (hotelsCount * 115);

                x.CurrentPlayer.Money -= fine;

                return new CardEffectResult(false, false, true, false);
            });

            var goToJail = new Card("Go to Jail. Move Directly to Jail. Do not pass GO. Do not collect $200.", CardType.Chance, false, x =>
            {
                //x.PlayerPositions[x.CurrentPlayer] = x.MapObjects.FindIndex(y => y.Name == "Jail");
                x.PlayerPositions[x.CurrentPlayer] = x.MapObjects.FindIndex(y => y.ObjectType == MapObjectType.Jail);

                x.PlayerStatuses[x.CurrentPlayer].PlayerStatus = PlayerStatus.InJail;

                return new CardEffectResult(false, false, false, false);
            });

            var receiveDividents = new Card("Bank pays you Dividend of $50.", CardType.Chance, false, x =>
            {
                x.CurrentPlayer.Money += 50;

                return new CardEffectResult(false, false, false, false);
            });

            var goBack3Spaces = new Card("Go back 3 Spaces.", CardType.Chance, false, x =>
            {
                var newPosition = x.PlayerPositions[x.CurrentPlayer] - 3;

                if (newPosition < 0)
                {
                    x.PlayerPositions[x.CurrentPlayer] = 40 - (newPosition * -1);
                }
                else
                {
                    x.PlayerPositions[x.CurrentPlayer] = newPosition;
                }

                return new CardEffectResult(false, true, false, false);
            });

            var paySchoolFees = new Card("Pay School Fees of $150.", CardType.Chance, false, x =>
            {
                x.CurrentPlayer.Money -= 150;

                return new CardEffectResult(false, false, true, false);
            });

            var repairProperties = new Card("Make General Repairs on all of Your Houses. For each House pay $25. For each Hotel pay $100.", CardType.Chance, false, x =>
            {
                int housesCount = 0;
                int hotelsCount = 0;

                var playerStreetProperties = x.CurrentPlayer.Properties.Where(y => y.ObjectType == MapObjectType.StreetProperty);

                foreach (var property in playerStreetProperties)
                {
                    var streetProperty = property as StreetProperty;

                    housesCount += streetProperty.Houses;
                    hotelsCount += streetProperty.Hotels;
                }

                var fine = (housesCount * 25) + (hotelsCount * 100);

                x.CurrentPlayer.Money -= fine;

                return new CardEffectResult(false, false, true, false);
            });

            var speedingFine = new Card("Speeding Fine $15.", CardType.Chance, false, x =>
            {
                x.CurrentPlayer.Money -= 15;

                return new CardEffectResult(false, false, true, false);
            });

            var winCrosswordCompetition = new Card("You have won a Crossword Competition collect $100.", CardType.Chance, false, x =>
            {
                x.CurrentPlayer.Money += 100;

                return new CardEffectResult(false, false, false, false);
            });

            var loanMatures = new Card("Your Building and Loan Matures collect $150.", CardType.Chance, false, x =>
            {
                x.CurrentPlayer.Money += 150;

                return new CardEffectResult(false, false, false, false);
            });

            var getOutOfJail = new Card("Get out of Jail Free.", CardType.Chance, true, x =>
            {
                x.PlayerStatuses[x.CurrentPlayer].PlayerStatus = PlayerStatus.Active;
                x.PlayerStatuses[x.CurrentPlayer].Turn = 0;

                return new CardEffectResult(false, false, false, true);
            });

            var advanceToTrafalgarSquare = new Card("Avance to Trafalgar Square if you pass GO collect $200.", CardType.Chance, false, x =>
            {
                x.PlayerPositions[x.CurrentPlayer] = x.MapObjects.FindIndex(y => y.Name == "Trafalgar Square");

                return new CardEffectResult(true, true, false, false);
            });

            var tripToMaryleboneStation = new Card("Take a Trip to Marylebone Station and if you pass GO collect $200.", CardType.Chance, false, x =>
            {
                x.PlayerPositions[x.CurrentPlayer] = x.MapObjects.FindIndex(y => y.Name == "Marylebone Station");

                return new CardEffectResult(true, true, false, false);
            });

            var advanceToPallMall = new Card("Advance to Pall Mall if you pass GO collect $200.", CardType.Chance, false, x =>
            {
                x.PlayerPositions[x.CurrentPlayer] = x.MapObjects.FindIndex(y => y.Name == "Pall Mall");

                return new CardEffectResult(true, true, false, false);
            });

            var drunkFine = new Card("Drunk in Charge Fine $20.", CardType.Chance, false, x =>
            {
                x.CurrentPlayer.Money -= 20;

                return new CardEffectResult(false, false, true, false);
            });

            var chanceCardsQueue = new Queue<ICard>();
            chanceCards.Enqueue(advanceToMayfair);
            chanceCards.Enqueue(advanceToGo);
            chanceCards.Enqueue(repairAssessment);
            chanceCards.Enqueue(goToJail);
            chanceCards.Enqueue(receiveDividents);
            chanceCards.Enqueue(goBack3Spaces);
            chanceCards.Enqueue(paySchoolFees);
            chanceCards.Enqueue(repairProperties);
            chanceCards.Enqueue(speedingFine);
            chanceCards.Enqueue(winCrosswordCompetition);
            chanceCards.Enqueue(loanMatures);
            chanceCards.Enqueue(getOutOfJail);
            chanceCards.Enqueue(advanceToTrafalgarSquare);
            chanceCards.Enqueue(tripToMaryleboneStation);
            chanceCards.Enqueue(advanceToPallMall);
            chanceCards.Enqueue(drunkFine);

            return chanceCardsQueue;
        }

        private Queue<ICard> CreateCommunityChestCards()
        {
            var incomeTaxRefund = new Card("Income Tax refund Collect $20.", CardType.CommunityChest, false, x =>
            {
                x.CurrentPlayer.Money += 20;

                return new CardEffectResult(false, false, false, false);
            });

            var stockSale = new Card("From Sale of Stock you get $50.", CardType.CommunityChest, false, x =>
            {
                x.CurrentPlayer.Money += 50;

                return new CardEffectResult(false, false, false, false);
            });

            // NEED REWORK
            var collectFromEachPlayer = new Card("It is Your Birthday Collect $10 from each Player.", CardType.CommunityChest, false, x =>
            {
                //foreach (var player in x.Players)
                //{
                //    if (player != x.CurrentPlayer && x.PlayerStatuses[player].PlayerStatus != PlayerStatus.Bankrupt)
                //    {
                //        //CANT WORK BECAUSE THE PLAYER MIGHT NOT HAVE A TOTAL OF $10(even with properties)
                //        player.Money -= 10;
                //        x.CurrentPlayer.Money += 10;

                //        if (player.Money < 0)
                //        {
                //            // TAKE ACTIONS HERE
                //            // SELL HOUSES
                //            // MORTGAGE PROPERTIES
                //            // TRADE
                //        }
                //    }
                //}

                return new CardEffectResult(false, false, false, false);
            });

            var receiveReferenceOnShares = new Card("Receive Interest on 7% Preference Shares $25.", CardType.CommunityChest, false, x =>
            {
                x.CurrentPlayer.Money += 25;

                return new CardEffectResult(false, false, false, false);
            });

            var getOutOfJail = new Card("Get out of Jail Free.", CardType.CommunityChest, true, x =>
            {
                x.PlayerStatuses[x.CurrentPlayer].PlayerStatus = PlayerStatus.Active;
                x.PlayerStatuses[x.CurrentPlayer].Turn = 0;

                return new CardEffectResult(false, false, false, true);
            });

            var advanceToGo = new Card("Advance to GO.", CardType.CommunityChest, false, x =>
            {
                x.PlayerPositions[x.CurrentPlayer] = x.MapObjects.FindIndex(y => y.Name == "GO");
                x.CurrentPlayer.Money += this.gameSettings.PassGOAward;

                return new CardEffectResult(false, false, false, false);
            });

            var payHospitalFine = new Card("Pay Hospital $100.", CardType.CommunityChest, false, x =>
            {
                x.CurrentPlayer.Money -= 100;

                return new CardEffectResult(false, false, true, false);
            });

            var prizeInBeautyContest = new Card("You have Won Second Prize in a Beauty Contest Collect $10.", CardType.CommunityChest, false, x =>
            {
                x.CurrentPlayer.Money += 10;

                return new CardEffectResult(false, false, false, false);
            });

            var collectFromBankError = new Card("Bank Error in your Favour Collect $200.", CardType.CommunityChest, false, x =>
            {
                x.CurrentPlayer.Money += 200;

                return new CardEffectResult(false, false, false, false);
            });

            var inheritance = new Card("You Inherit $100.", CardType.CommunityChest, false, x =>
            {
                x.CurrentPlayer.Money += 100;

                return new CardEffectResult(false, false, false, false);
            });

            var goToJail = new Card("Go to Jail. Move Directly to Jail. Do not pass GO. Do not collect $200.", CardType.CommunityChest, false, x =>
            {
                //x.PlayerPositions[x.CurrentPlayer] = x.MapObjects.FindIndex(y => y.Name == "Jail");
                x.PlayerPositions[x.CurrentPlayer] = x.MapObjects.FindIndex(y => y.ObjectType == MapObjectType.Jail);

                x.PlayerStatuses[x.CurrentPlayer].PlayerStatus = PlayerStatus.InJail;

                return new CardEffectResult(false, false, false, false);
            });

            var payInsurancePremium = new Card("Pay your Insurance Premium $50.", CardType.CommunityChest, false, x =>
            {
                x.CurrentPlayer.Money -= 50;

                return new CardEffectResult(false, false, true, false);
            });

            // NEED REWORK
            var payFineOrTakeChance = new Card("Pay a $10 Fine or Take a Chance.", CardType.CommunityChest, false, x =>
            {
                return new CardEffectResult(false, false, true, false);
            });

            var payDoctorsFee = new Card("Doctor's Fee Pay $50.", CardType.CommunityChest, false, x =>
            {
                x.CurrentPlayer.Money -= 50;

                return new CardEffectResult(false, false, true, false);
            });

            var getBackToOldKentRoad = new Card("Go Back to Old Kent Road.", CardType.CommunityChest, false, x =>
            {
                x.PlayerPositions[x.CurrentPlayer] = x.MapObjects.FindIndex(y => y.Name == "Old Kent Road");

                return new CardEffectResult(false, true, false, false);
            });

            var collectAnnuity = new Card("Annuity Matures Collect $100.", CardType.CommunityChest, false, x =>
            {
                x.CurrentPlayer.Money += 100;

                return new CardEffectResult(false, false, false, false);
            });

            var communityChestCardsQueue = new Queue<ICard>();
            communityChestCardsQueue.Enqueue(incomeTaxRefund);
            communityChestCardsQueue.Enqueue(stockSale);
            communityChestCardsQueue.Enqueue(collectFromEachPlayer);
            communityChestCardsQueue.Enqueue(receiveReferenceOnShares);
            communityChestCardsQueue.Enqueue(getOutOfJail);
            communityChestCardsQueue.Enqueue(advanceToGo);
            communityChestCardsQueue.Enqueue(payHospitalFine);
            communityChestCardsQueue.Enqueue(prizeInBeautyContest);
            communityChestCardsQueue.Enqueue(collectFromBankError);
            communityChestCardsQueue.Enqueue(inheritance);
            communityChestCardsQueue.Enqueue(goToJail);
            communityChestCardsQueue.Enqueue(payInsurancePremium);
            communityChestCardsQueue.Enqueue(payFineOrTakeChance);
            communityChestCardsQueue.Enqueue(payDoctorsFee);
            communityChestCardsQueue.Enqueue(getBackToOldKentRoad);
            communityChestCardsQueue.Enqueue(collectAnnuity);

            return communityChestCardsQueue;
        }

        private List<IPlayer> CreatePlayers(IDictionary<string, PlayerColour> playerInformation, IGameSettings gameSettings)
        {
            var participants = new List<IPlayer>(playerInformation.Count);
            IPlayer player;

            foreach (var playerInfo in playerInformation)
            {
                player = new Player(playerInfo.Key, gameSettings.PlayerStartMoney, playerInfo.Value);

                participants.Add(player);
            }

            return participants;
        }

        private void SetupPlayerPositions()
        {
            this.playerPositions = new Dictionary<IPlayer, int>();

            foreach (var player in this.players)
            {
                this.playerPositions[player] = 0;
            }
        }

        private void SetupPlayerStatuses()
        {
            this.playerStatuses = new Dictionary<IPlayer, PlayerStatusInformation>();

            foreach (var player in this.players)
            {
                this.playerStatuses[player] = new PlayerStatusInformation();
            }
        }

        private IGameContext CreateGameContext()
        {
            var gameContext = new GameContext(this.bank, this.mapObjects, this.players, this.playerPositions, this.playerStatuses, this.currentPlayer);

            return gameContext;
        }
    }
}
