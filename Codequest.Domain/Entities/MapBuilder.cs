using Codequest.Domain.Enums;
using CodeQuest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Codequest.Domain.Entities
{
    public class MapBuilder
    {
        public static void SetMapLevel(LevelMap levelMap)
        {
            string basePath = AppContext.BaseDirectory;
            var path = basePath + "..\\..\\..\\Assets\\Maps\\" + levelMap.ToString() + ".txt";
            var lines = File.ReadLines(path).ToList();
            Map.YSize = lines.Count;

            for (int y = 0; y < lines.Count; y++)
            {
                var lineLength = lines[y].Length;
                Map.XSize = lineLength;

                for (int x = 0; x < lineLength ; x++)
                {
                    var tile = new TileMap(x, y, CheckSymbol(lines[x][y]));
                    Map.MapDesign.Add(tile);
                }
            }
        }

        private static TileMapType CheckSymbol(char symbol) {
            switch (symbol) {
                case '#':
                    return TileMapType.Obstacle;
                    break;
                case '-':
                    return TileMapType.Danger;
                    break;
                case '+':
                    return TileMapType.Heal;
                    break;
                case '?':
                    return TileMapType.SpawnPoint;
                    break;
                default:
                    return TileMapType.Void;
                    break;
            }
        }

        public MapBuilder() { }
    }
}
