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
    public class ItemPickup
    {
        bool collisionEnabled;
        Game1 game;
        public BoundingRectangle bounds;
        Texture2D texture;
        public enum Type {goalItem, visionItem };
        Type type;

        public ItemPickup(Game1 game, int x, int y, Type type)
        {
            this.game = game;
            bounds.Width = 100;
            bounds.Height = 100;
            bounds.X = x;
            bounds.Y = y;
            this.type = type;
            

        }

        public void LoadContent(ContentManager content)
        {
            if (type == Type.goalItem)
                texture = content.Load<Texture2D>("WheatSheaf");
        }
        public void Draw(SpriteBatch spritebBatch)
        {
            spritebBatch.Draw(texture, bounds, Color.White);
        }
    }
}
