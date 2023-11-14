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

        public int[,] mapDesign =
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


        public int[] spawnPoint = { 0, 0 };

        public int mapDesignXSize => mapDesign.GetLength(0);
        public int mapDesignYSize => mapDesign.GetLength(1);

        public int[,] getMapDesign()
        {
            return mapDesign;
        }

        public int[] getSpawnPoint()
        {
            return spawnPoint;
        }

        public void setSpawnPoint(int x, int y)
        {
            spawnPoint[0] = x;
            spawnPoint[1] = y;
        }

        public void setColisionPoints()
        {
            for (int x = 0; x < mapDesignXSize; x++)
            {
                for (int y = 0; y < mapDesignYSize; y++)
                {
                    if (mapDesign[x, y] == 1)
                    {
                        colisionPoints.Add(new int[] { x, y });
                    }
                    else if (mapDesign[x, y] == 2)
                    {
                        actionPoints.Add(new int[] { x, y });
                    }
                    else if (mapDesign[x, y] == 3)
                    {
                        dangerPoints.Add(new int[] { x, y });
                    }
                }
            }
        }

        public List<int[]> getColisionPoints()
        {
            return colisionPoints;
        }

        public List<int[]> getActionPoints()
        {
            return actionPoints;
        }
        public List<int[]> getDangerPoints()
        {
            return dangerPoints;
        }

        public Map()
        {
            setColisionPoints();
        }
    }
}
