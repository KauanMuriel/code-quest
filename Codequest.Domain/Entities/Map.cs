using Codequest.Domain.Entities;
using Codequest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest
{
    public class Map
    {   // 1 parede
        // 2 action
        // 3 perigo

        public int[,] MapDesign { get; private set; } =
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 2, 0, 0, 0, 0, 0, 3, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, }
        };

        public static List<TileMap> ColisionPoints { get; private set; } = new List<TileMap>();

        public int[] SpawnPoint { get; private set; } = { 0, 0 };

        public int MapDesignXSize => MapDesign.GetLength(0);
        public int MapDesignYSize => MapDesign.GetLength(1);

        public void SetSpawnPoint(int x, int y)
        {
            SpawnPoint[0] = x;
            SpawnPoint[1] = y;
        }

        public void SetColisionPoints()
        {
            for (int x = 0; x < MapDesignXSize; x++)
            {
                for (int y = 0; y < MapDesignYSize; y++)
                {
                    var tileType = TileMapType.Void;
                    
                    switch (MapDesign[x, y])
                    {
                        case 0:
                            tileType = TileMapType.Void;
                            break;
                        case 1:
                            tileType = TileMapType.Obstacle;
                            break;
                        case 2:
                            tileType = TileMapType.Heal;
                            break;
                        case 3:
                            tileType = TileMapType.Danger;
                            break;
                    }
                    var tileMap = new TileMap(x, y, tileType);

                    ColisionPoints.Add(tileMap);
                }
            }
        }

        public Map()
        {
            SetColisionPoints();
        }
    }
}
