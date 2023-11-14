using System.Numerics;
using System.Reflection;

namespace CodeQuest.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameMap = new Map();
            var player = new Player(gameMap.getColisionPoints(), gameMap.getActionPoints(), gameMap.getDangerPoints());
            var gameRender = new Render(gameMap, player);

            player.setPlayerPos(9, 5);
            player.setPlayerLives(3);
            gameRender.RenderMap();

            while (true)
            {
                gameRender.RenderMap();
                ConsoleKeyInfo key = Console.ReadKey();
                player.updatePosition(key);
            }

        }
    }
}