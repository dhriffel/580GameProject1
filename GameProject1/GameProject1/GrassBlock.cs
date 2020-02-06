using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject1
{
    public class GrassBlock
    {
        bool collisionEnabled = true;
        Game1 game;
        public BoundingRectangle bounds;
        Texture2D texture;

        public GrassBlock(Game1 game, int x, int y)
        {
            this.game = game;
            bounds.Width = 100;
            bounds.Height = 100;
            bounds.X = x;
            bounds.Y = y;// game.GraphicsDevice.Viewport.Height / 2 - bounds.Height / 2;
        }
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("grass");
        }
        public void Draw(SpriteBatch spritebBatch)
        {
            spritebBatch.Draw(texture, bounds, Color.White);
        }
    }
}
