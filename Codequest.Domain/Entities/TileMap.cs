using Codequest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codequest.Domain.Entities
{
    public class TileMap
    {
        public TileMapType Type { get; }
        public int X { get; }
        public int Y { get; }

        public TileMap(int x, int y, TileMapType type)
        {
            Type = type;
            X = x;
            Y = y;
        }
    }
}
