using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest
{
    public class Render
    {
        private Map map;
        private Player player;

        public void RenderMap()
        {
            Console.Clear();
            Console.CursorVisible = false;

            int[,] mapDesign = map.getMapDesign();

            Console.WriteLine("Player Lives: " + player.getPlayerLives());

            for (int x = 0; x < map.mapDesignXSize; x++)
            {
                for (int y = 0; y < map.mapDesignYSize; y++)
                {
                    switch (mapDesign[x, y])
                    {
                        case 1:
                            Console.Write(" # ");
                            break;
                        case 2:
                            Console.Write("|+|");
                            break;
                        case 3:
                            Console.Write("|-|");
                            break;
                        default:
                            if (x == player.playerPos[0] && y == player.playerPos[1])
                            {
                                Console.Write("[0]");
                            }
                            else
                            {
                                Console.Write("   ");
                            }
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public Render(Map map, Player player)
        {
            this.map = map;
            this.player = player;
        }
    }
}
