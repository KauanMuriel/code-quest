using Codequest.Domain.Enums;

namespace CodeQuest
{
    public class Player
    {
        public int PlayerLives { get; set; } = 1; 
        public int[] PlayerPos = { 0, 0 };

        public int[] GetPlayerPos()
        {
            return PlayerPos;
        }

        public void SetPlayerPos(int x, int y)
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
                        PlayerPos[0]--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (CheckColision(PlayerPos[0] + 1, PlayerPos[1]))
                    {
                        PlayerPos[0]++;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (CheckColision(PlayerPos[0], PlayerPos[1] - 1))
                    {
                        PlayerPos[1]--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (CheckColision(PlayerPos[0], PlayerPos[1] + 1))
                    {
                        PlayerPos[1]++;
                    }
                    break;
            }
        }

        private bool CheckColision(int playerPosX, int playerPosY)
        {
            var colision = Map.ColisionPoints.Find(tile => tile.X == playerPosX && tile.Y == playerPosY);

            if (colision == null)
            {
                return false;
            }

            switch (colision.Type)
            {
                case TileMapType.Heal:
                    PlayerLives++;
                    break;
                case TileMapType.Danger:
                    PlayerLives--;
                    break;
            }

            return true;
        }

        public Player() { }
    }
}
