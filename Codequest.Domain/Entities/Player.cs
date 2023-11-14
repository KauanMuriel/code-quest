using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest
{
    public class Player
    {
        public int PlayerLives { get; set; } = 1; 

        public int[] PlayerPos = { 0, 0 };
        public List<int[]> ColisionPoints = new List<int[]>();
        public List<int[]> ActionPoints = new List<int[]>();
        public List<int[]> DangerPoints = new List<int[]>();

        public int[] getPlayerPos()
        {
            return PlayerPos;
        }

        public void setPlayerPos(int x, int y)
        {
            PlayerPos[0] = x;
            PlayerPos[1] = y;
        }

        public void UpdatePosition(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (CheckColision(PlayerPos[0] - 1, PlayerPos[1]))
                    {
                        break;
                    }
                    PlayerPos[0]--;
                    break;

                case ConsoleKey.DownArrow:
                    if (CheckColision(PlayerPos[0] + 1, PlayerPos[1]))
                    {
                        break;
                    }
                    PlayerPos[0]++;
                    break;

                case ConsoleKey.LeftArrow:
                    if (CheckColision(PlayerPos[0], PlayerPos[1] - 1))
                    {
                        break;
                    }
                    PlayerPos[1]--;
                    break;

                case ConsoleKey.RightArrow:
                    if (CheckColision(PlayerPos[0], PlayerPos[1] + 1))
                    {
                        break;
                    }
                    PlayerPos[1]++;
                    break;
            }
        }

        private bool CheckColision(int playerPosX, int playerPosY)
        {
            if (ColisionPoints.Any(point => point[0] == playerPosX && point[1] == playerPosY))
            {
                // COLISAO SIMPLES, PAREDE
                return true;
            }
            else if (ActionPoints.Any(point => point[0] == playerPosX && point[1] == playerPosY))
            {
                // COLISAO COM ACAO
                PlayerLives++;
                return true;
            }
            else if (DangerPoints.Any(point => point[0] == playerPosX && point[1] == playerPosY))
            {
                // COLISAO COM PERIGO
                PlayerLives--;
                return true;
            }
            else
            {
                return false;
            }
        }


        public Player(List<int[]> colisionPoints, List<int[]> actionPoints, List<int[]> dangerPoints)
        {
            ColisionPoints = colisionPoints;
            ActionPoints = actionPoints;
            DangerPoints = dangerPoints;
        }
    }
}
