using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameProject1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        ItemPickup winItem;
        TileLocation[ , ] mapTiles;
        GrassBlock[ , ] blocks;
        int[ , ] blockChecks = { { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                               { 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                               { 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1 },
                               { 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1 },
                               { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 },
                               { 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                               { 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1 },
                               { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 },
                               { 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
                               { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1500;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.ApplyChanges();
            mapTiles = new TileLocation[15,10];
            blocks = new GrassBlock[15, 10];
            for(int i = 0; i< 15; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mapTiles[i, j] = new TileLocation(i * 100, j * 100, 100, 100, false);
                }
            }

            Random rando = new Random();
            int[,] locat = { { 1, 1 }, { 13, 8 }, { 13, 1 } };
            int choice = rando.Next(0, 3);
            winItem = new ItemPickup(this, (int)mapTiles[locat[choice,0], locat[choice, 1]].position.X, (int)mapTiles[locat[choice, 0], locat[choice, 1]].position.Y, ItemPickup.Type.goalItem);
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (blockChecks[j,i] == 1)
                    {
                        blocks[i, j] = new GrassBlock(this, (int)mapTiles[i, j].position.X, (int)mapTiles[i, j].position.Y);
                    }
                }
            }
            player = new Player(this, (int)mapTiles[8, 4].position.X, (int)mapTiles[8, 4].position.Y, blocks);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(Content);
            winItem.LoadContent(Content);
            foreach(GrassBlock block in blocks)
            {
                if(block != null)
                    block.LoadContent(Content);
            }
            

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);
            if (Collisions.CollidesWith(player.bounds, winItem.bounds))
                Exit();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
           
            winItem.Draw(spriteBatch);
            foreach (GrassBlock block in blocks)
            {
                if (block != null)
                    block.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
