using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest
{
    public class Player
    {
        public int playerLives = 1;

        public int[] playerPos = { 0, 0 };
        public List<int[]> colisionPoints = new List<int[]>();
        public List<int[]> actionPoints = new List<int[]>();
        public List<int[]> dangerPoints = new List<int[]>();

        public int getPlayerLives()
        {
            return playerLives;
        }

        public void setPlayerLives(int playerLives)
        {
            this.playerLives = playerLives;
        }

        public int[] getPlayerPos()
        {
            return playerPos;
        }

        public void setPlayerPos(int x, int y)
        {
            this.playerPos[0] = x;
            this.playerPos[1] = y;
        }

        public void updatePosition(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (checkColision(playerPos[0] - 1, playerPos[1]))
                    {
                        break;
                    }
                    playerPos[0]--;
                    break;

                case ConsoleKey.DownArrow:
                    if (checkColision(playerPos[0] + 1, playerPos[1]))
                    {
                        break;
                    }
                    playerPos[0]++;
                    break;

                case ConsoleKey.LeftArrow:
                    if (checkColision(playerPos[0], playerPos[1] - 1))
                    {
                        break;
                    }
                    playerPos[1]--;
                    break;

                case ConsoleKey.RightArrow:
                    if (checkColision(playerPos[0], playerPos[1] + 1))
                    {
                        break;
                    }
                    playerPos[1]++;
                    break;
            }
        }

        private bool checkColision(int playerPosX, int playerPosY)
        {
            if (colisionPoints.Any(point => point[0] == playerPosX && point[1] == playerPosY))
            {
                // COLISAO SIMPLES, PAREDE
                return true;
            }
            else if (actionPoints.Any(point => point[0] == playerPosX && point[1] == playerPosY))
            {
                // COLISAO COM ACAO
                setPlayerLives(playerLives + 1);
                return true;
            }
            else if (dangerPoints.Any(point => point[0] == playerPosX && point[1] == playerPosY))
            {
                // COLISAO COM PERIGO
                setPlayerLives(playerLives - 1);
                return true;
            }
            else
            {
                return false;
            }
        }


        public Player(List<int[]> colisionPoints, List<int[]> actionPoints, List<int[]> dangerPoints)
        {
            this.colisionPoints = colisionPoints;
            this.actionPoints = actionPoints;
            this.dangerPoints = dangerPoints;
        }
    }
}
