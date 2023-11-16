using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest
{
    public class Render
    {
        private readonly Map _map;
        private readonly Player _player;

        public void RenderMap()
        {
            Console.Clear();
            Console.CursorVisible = false;

            int[,] mapDesign = _map.MapDesign;

            Console.WriteLine("Player Lives: " + _player.Lives);

            for (int x = 0; x < _map.MapDesignXSize; x++)
            {
                for (int y = 0; y < _map.MapDesignYSize; y++)
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
                            if (x == _player.Position[0] && y == _player.Position[1])
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
            _map = map;
            _player = player;
        }
    }
}
