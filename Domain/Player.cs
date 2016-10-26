﻿using System;

namespace Domain
{
   public class Player
   {
      public bool IsInGame { get; private set; }

      public int CountChips { get; private set; }

      public Bet Bet { get; set; }

      public void BuyChips(int chipsNumber)
      {
         CountChips += chipsNumber;
      }

      public void Join(Game game)
      {
         if (IsInGame)
         {
            throw new InvalidOperationException();
         }

         if (game.CountPlayers >= 6)
         {
            return;
         }

         game.JoinPlayer(this);
         IsInGame = true;
      }

      public void Leave()
      {
         if (!IsInGame)
         {
            throw new InvalidOperationException();
         }

         IsInGame = false;
      }

      public void MakeBet(int chips)
      {
         if (this.CountChips < chips)
         {
            throw new InvalidOperationException();
         }

         Bet = new Bet(chips);
      }
   }
}


