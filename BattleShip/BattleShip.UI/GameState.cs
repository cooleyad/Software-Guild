using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.Requests;
using BattleShip.UI;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class GameState

    {
        public Player P1 { get; }
        public Player P2 { get; }
        public bool IsPlayerOneTurn { get; set; }

        public GameState(Player p1, Player p2, bool p1Turn)
        {
            P1=p1;
            P2=p2;
            IsPlayerOneTurn = p1Turn;
        }
    }
}
