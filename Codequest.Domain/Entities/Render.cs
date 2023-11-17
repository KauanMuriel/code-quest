using Codequest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
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

            Console.WriteLine("Player Lives: " + _player.Lives);

            int lineCount = 0;
            foreach (var tile in Map.MapDesign)
            {
                if (tile.Y != lineCount)
                {
                    lineCount++;
                    Console.WriteLine();
                }
                switch (tile.Type)
                {
                    case TileMapType.Obstacle:
                        Console.Write(" # ");
                        break;
                    case TileMapType.Danger:
                        Console.Write("|-|");
                        break;
                    case TileMapType.Heal:
                        Console.Write("|+|");
                        break;
                    case TileMapType.SpawnPoint:
                        Console.Write(" ? ");
                        break;
                    default:
                        if (tile.X == _player.Position[0] && tile.Y == _player.Position[1])
                        {
                            Console.Write("[0]");
                        } else
                        {
                            Console.Write("   ");
                        }
                        break;
                }
            }
        }

        public Render(Map map, Player player)
        {
            _map = map;
            _player = player;
        }
    }
}
