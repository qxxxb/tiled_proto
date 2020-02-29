using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TiledSharp;

namespace TiledProto
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TmxMap map;
        Texture2D tileset1;
        Texture2D tileset2;
        Texture2D tileset3;
        Texture2D tileset4;

        int tileWidth;
        int tileHeight;
        int tilesetTilesWide;
    
        int tilesetTilesHigh;
    


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

            map = new TmxMap(@"Maps\ZeldaLevel.tmx");
            tileset1 = Content.Load<Texture2D>("Blocks");
            tileset2 = Content.Load<Texture2D>("Wall");
            tileset3 = Content.Load<Texture2D>("Doors");
       
          

            tileWidth = 32;
            tileHeight = 32;

            tilesetTilesWide = 32;
            tilesetTilesHigh = 32;

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

            for (var i = 0; i < map.Layers[0].Tiles.Count; i++) {
                int gid = map.Layers[0].Tiles[i].Gid;

                // Empty tile, do nothing
                if (gid == 0) {

                }
                else {
                    int tileFrame = gid - 1;
                    int column = (int)Math.Floor((double)tileFrame / (double)tilesetTilesHigh);
                    int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);

                   

                    float x = (i % map.Width) * map.TileWidth;
                    float y = (float)Math.Floor(i / (double)map.Width) * map.TileHeight;

                    Rectangle tilesetRec1 = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);
                    

                    spriteBatch.Draw(tileset1, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec1, Color.White);
                    spriteBatch.Draw(tileset2, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec1, Color.White);
                    spriteBatch.Draw(tileset3, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec1, Color.White);
                   
                    
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
