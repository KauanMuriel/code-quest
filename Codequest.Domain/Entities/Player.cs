using Codequest.Domain.Entities;
using Codequest.Domain.Enums;

namespace CodeQuest
{
    public class Player
    {
        public int Lives { get; set; } = 1; 
        public int[] Position { get; set; } = { 0, 0 };

        public int[] GetPlayerPos()
        {
            return Position;
        }

        public void SetPlayerPos(int x, int y)
        {
            Position[0] = x;
            Position[1] = y;
        }

        public void UpdatePosition(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (CheckColision(Position[0] - 1, Position[1]))
                    {
                        Position[0]--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (CheckColision(Position[0] + 1, Position[1]))
                    {
                        Position[0]++;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (CheckColision(Position[0], Position[1] - 1))
                    {
                        Position[1]--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (CheckColision(Position[0], Position[1] + 1))
                    {
                        Position[1]++;
                    }
                    break;
            }
        }

        private bool CheckColision(int playerPosX, int playerPosY)
        {
            var colision = Map.MapDesign.Find(tile => tile.X == playerPosX && tile.Y == playerPosX);

            if (colision == null)
            {
                return false;
            }

            switch (colision.Type)
            {
                case TileMapType.Heal:
                    Lives++;
                    break;
                case TileMapType.Danger:
                    Lives--;
                    break;
            }

            return true;
        }

        public Player() { }
    }
}
