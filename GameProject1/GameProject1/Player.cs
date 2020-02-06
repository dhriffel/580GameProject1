using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject1
{
    public class Player
    {
        Game1 game;
        public BoundingRectangle bounds;
        BoundingRectangle viewbound;
        Texture2D texture;
        Texture2D view;
        GrassBlock[,] blocks;
        bool touchcheck = false;
        KeyboardState oldKeyboardState = Keyboard.GetState();

        public Player(Game1 game,int x, int y, GrassBlock[,] blocks)
        {
            this.game =game;
            bounds.Width = 50;
            bounds.Height = 50;
            bounds.X = x;
            bounds.Y = y;
            this.blocks = blocks;
            viewbound.Width = 3500;
            viewbound.Height = 3500;
            viewbound.X = x - viewbound.Width/2 + bounds.Width/2;
            viewbound.Y = y - viewbound.Height/2 + bounds.Height/2;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("cow");
            view = content.Load<Texture2D>("Viewhole");
        }
        public void Update(GameTime gameTime)
        {
            var newKeyboardState = Keyboard.GetState();
            if (newKeyboardState.IsKeyDown(Keys.Up))
            {
                foreach (GrassBlock block in blocks)
                {
                    if (block != null)
                        if (Collisions.TouchingBottom(this.bounds, block.bounds))
                            touchcheck = true;

                }
                if (!touchcheck)
                {
                bounds.Y -= (int)gameTime.ElapsedGameTime.TotalMilliseconds/2;
                viewbound.Y -= (int)gameTime.ElapsedGameTime.TotalMilliseconds/2;
                }
                    
                touchcheck = false;
            }
            if (newKeyboardState.IsKeyDown(Keys.Down))
            {
                foreach (GrassBlock block in blocks)
                {
                    if (block != null)
                        if (Collisions.TouchingTop(this.bounds, block.bounds))
                            touchcheck = true;

                }
                if (!touchcheck)
                {
                    bounds.Y += (int)gameTime.ElapsedGameTime.TotalMilliseconds/2;
                    viewbound.Y += (int)gameTime.ElapsedGameTime.TotalMilliseconds/2;
                }
                    touchcheck = false;
            }
            if (newKeyboardState.IsKeyDown(Keys.Left))
            {
                foreach (GrassBlock block in blocks)
                {
                    if (block != null)
                        if (Collisions.TouchingRight(this.bounds, block.bounds))
                        touchcheck = true;

                }
                if (!touchcheck)
                {
                    bounds.X -= (int)gameTime.ElapsedGameTime.TotalMilliseconds/2;
                    viewbound.X -= (int)gameTime.ElapsedGameTime.TotalMilliseconds/2;
                }
                    touchcheck = false;
            }
            if (newKeyboardState.IsKeyDown(Keys.Right))
            {
                foreach(GrassBlock block in blocks)
            {
                    if (block != null)
                        if (Collisions.TouchingLeft(this.bounds, block.bounds))
                        touchcheck = true;

            }
                if (!touchcheck)
                {
                    bounds.X += (int)gameTime.ElapsedGameTime.TotalMilliseconds/2;
                    viewbound.X += (int)gameTime.ElapsedGameTime.TotalMilliseconds/2;
                }
                    touchcheck = false;
            }

            if (bounds.Y < 0) { bounds.Y = 0; };
            if (bounds.Y > game.GraphicsDevice.Viewport.Height - bounds.Height)
            {
                bounds.Y = game.GraphicsDevice.Viewport.Height - bounds.Height;
            }
            if (bounds.X < 0) { bounds.X = 0; };
            if (bounds.X > game.GraphicsDevice.Viewport.Width - bounds.Width)
            {
                bounds.X = game.GraphicsDevice.Viewport.Width - bounds.Width;
            }

            oldKeyboardState = Keyboard.GetState();
            
        }
        public void Draw(SpriteBatch spritebBatch)
        {
            spritebBatch.Draw(texture, bounds, Color.White);
            spritebBatch.Draw(view, viewbound, Color.White);

        }
    }
}
