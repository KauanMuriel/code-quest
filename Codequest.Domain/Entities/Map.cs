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
    {
        public static List<TileMap> MapDesign { get; set; } = new List<TileMap>();
        public static int XSize { get; set;} = 0;
        public static int YSize { get; set;} = 0;
        public static TileMap SpawnPoint
        {
            get => MapDesign.Find(t => t.Type == TileMapType.SpawnPoint);
        }

        public void ChangeMap(LevelMap levelMap)
        {
            
        }

        public Map()
        {
            MapBuilder.SetMapLevel(LevelMap.Lobby); // DEFINIDO O LOB QUANDO O MAPA E GERADO, JOGADOR INICIA NO LOBBY
        }
    }
}
