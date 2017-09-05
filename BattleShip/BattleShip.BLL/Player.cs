﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;

namespace BattleShip.BLL
{
    public class Player

        //1. Store Player Input
        //2. Store Player Board
    {
        public string PlayerName { get; }
        public Board PlayerBoard { get; }

        public Player (string name, Board playerBoard)
        {
            PlayerName = name;
            PlayerBoard = playerBoard;
        } 
    }
}
