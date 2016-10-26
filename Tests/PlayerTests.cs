﻿using System;
using System.Data;
using System.Security.Permissions;
using System.Security.Policy;
using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Join_IsInGame()
        {
            var player = new Player();
            var game = new Game();

            player.Join(game);
                
            Assert.IsTrue(player.InGame);
        }

        [Test]
        public void ByDefault_IsNotInGame()
        {
            var player = new Player();

            Assert.IsFalse(player.InGame);
        }


        [Test]
        public void GoOut_NotJoin_ThrowsInvalidOperationException()
        {
            var player = new Player();

            Assert.Catch<InvalidOperationException>(() => player.GoOutFromGame());
        }


        [Test]
        public void GoOut_AfterJoin_IsNotInGame()
        {
            var player = new Player();
            var game = new Game();
            player.Join(game);

            player.GoOutFromGame();

            Assert.IsFalse(player.InGame);
        }

        [Test]
        public void JoinGame2_AlreadyJoinedGame1_ThrowsInvalidOperationException()
        {
            var player = new Player();
            var game1 = new Game();
            var game2 = new Game();
            player.Join(game1);
            
            Assert.Catch<InvalidOperationException>(()=>player.Join(game2));
        }

        [Test]
        public void Buy1Chip_Has1Chip()
        {
            var player = new Player();

            player.BuyChips(1);

            Assert.AreEqual(1, player.Chips);
        }
    }
}



//## Упражнение 2. Ставки
//* Я, как игрок, могу купить фишки у казино, чтобы делать ставки
//* Я, как игрок, могу сделать ставку в игре в кости, чтобы выиграть
//* Я, как игрок, не могу поставить фишек больше, чем я купил
//* Я, как игрок, могу сделать несколько ставок на разные числа, чтобы повысить вероятность выигрыша
//* Я, как казино, принимаю только ставки, кратные 5
//* Я, как игрок, могу поставить только на числа 1 - 6