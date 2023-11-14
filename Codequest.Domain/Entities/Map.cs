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

        public List<int[]> colisionPoints = new List<int[]>();
        public List<int[]> dangerPoints = new List<int[]>();
        public List<int[]> actionPoints = new List<int[]>();


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
                    if (MapDesign[x, y] == 1)
                    {
                        colisionPoints.Add(new int[] { x, y });
                    }
                    else if (MapDesign[x, y] == 2)
                    {
                        actionPoints.Add(new int[] { x, y });
                    }
                    else if (MapDesign[x, y] == 3)
                    {
                        dangerPoints.Add(new int[] { x, y });
                    }
                }
            }
        }

        public Map()
        {
            SetColisionPoints();
        }
    }
}
