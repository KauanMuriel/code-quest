﻿using Codequest.Domain.Enums;
using System.Numerics;
using System.Reflection;

namespace CodeQuest.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameMap = new Map();
            //gameMap.ChangeMap(LevelMap.Lobby);
            
            var player = new Player();
            var gameRender = new Render(gameMap, player);

            player.SetPlayerPos(Map.SpawnPoint.X, Map.SpawnPoint.Y);
            player.Lives = 3;
            gameRender.RenderMap();

            while (true)
            {
                gameRender.RenderMap();
                ConsoleKeyInfo key = Console.ReadKey();
                player.UpdatePosition(key);
            }
        }
    }
}