using System.Numerics;
using System.Reflection;

namespace CodeQuest.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameMap = new Map();
            var player = new Player();
            var gameRender = new Render(gameMap, player);

            player.SetPlayerPos(9, 5);
            player.PlayerLives = 3;
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