using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{

    //1. get names
    //2. Determine Player Order
    //3. Instantiate two board objects
    //4. Create Player object
    //5. Loop through each ship type and place


    public class SetUp

    {
        public GameState Start()
        {
            BshipOutput.DisplayTitle();
            BshipOutput.WelcomePlayers();

            string P1 = BshipInput.GetNameFromPlayer(1);
            string P2 = BshipInput.GetNameFromPlayer(2);

            Board PlayerOneBoard = BoardCreated(P1);
            Board PlayerTwoBoard = BoardCreated(P2);

            Player p1 = new Player(P1, PlayerOneBoard);
            Player p2 = new Player(P2, PlayerTwoBoard);


            bool IsPlayerTurn = WhoGoesFirst();

            GameState gameState = new GameState(p1, p2, IsPlayerTurn);

            return gameState;

        }


        private Board BoardCreated(string PlayerName)
        {

            Board toReturn = new Board();

            for (ShipType s = ShipType.Carrier; s >= ShipType.Destroyer; s--)
            {

                bool IsShipSpotValid = false;
                do
                {
                    PlaceShipRequest request = new PlaceShipRequest();
                    request.Coordinate = BshipInput.GetCoordinate();
                    request.Direction = BshipInput.GetDirection(PlayerName, s);
                    request.ShipType = s;

                    var result = toReturn.PlaceShip(request);

                    if (result == ShipPlacement.NotEnoughSpace)
                    {
                        BshipOutput.TooFar();
                    }
                    if (result == ShipPlacement.Overlap)
                    {
                        BshipOutput.GGOverlap();
                    }
                    if (result == ShipPlacement.Ok)
                    {
                        BshipOutput.PlaceSuccess();
                        IsShipSpotValid = true;
                    }
                }
                while (!IsShipSpotValid);
            }
            return toReturn;
        }
        private bool WhoGoesFirst()
        {
            return RNG.CoinFlip();
        }
    }
}

