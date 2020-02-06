using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject1
{
    public struct TileLocation
    {
        public Vector2 position;
        int Width;
        int Height;
        bool isWall;

        public TileLocation(int X, int Y, int Width, int Height, bool isWall)
        {
            this.position.X = X;
            this.position.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.isWall = isWall;
        }

    }
}
