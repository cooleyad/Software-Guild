﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            SetUp flow = new SetUp();
            GameState state= flow.Start();

            Gameflow game = new Gameflow();
            game.PlayGame(state);
        }
    }
}
