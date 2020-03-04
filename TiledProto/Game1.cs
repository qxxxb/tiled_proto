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
        Texture2D tileset5;


        int tileWidth;
        int tileHeight;
        int doorTilesetTilesWide;
        int blockTilesetTilesWide;
        int wallTilesetTilesWide;
        int doorTilesetTilesHigh;
        int wallTilesetTilesHigh;
        int blockTilesetTilesHigh;
        int nonoTilesetTilesHigh;
        int nonoTilesetTilesWide;



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
            graphics.PreferredBackBufferWidth = 1800;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();
        
            this.IsMouseVisible = true;

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
         
            map = new TmxMap(@"Maps\ZeldaMap.tmx");
            tileset1 = Content.Load<Texture2D>("block");
            tileset2 = Content.Load<Texture2D>("WallsPlusT");
            tileset3 = Content.Load<Texture2D>("DoorsFinal");
            tileset4 = Content.Load<Texture2D>("waterBlocks");
            tileset5 = Content.Load<Texture2D>("nonoZone");




            tileWidth = 32;
            tileHeight = 32;

            blockTilesetTilesWide = 22;
            blockTilesetTilesHigh = 2;
            wallTilesetTilesWide = 32;
            wallTilesetTilesHigh = 22;
            doorTilesetTilesWide = 20;
            doorTilesetTilesHigh = 16;
            nonoTilesetTilesWide = 8;
            nonoTilesetTilesHigh = 2;

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

            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
           
           

             spriteBatch.Begin();
            for (int j = 0; j <5 ; j++)
            {
                for (int i = 0; i < map.Layers[j].Tiles.Count; i++)
                {

                    int gid = map.Layers[j].Tiles[i].Gid;
                    float x = ((i % map.Width) * map.TileWidth);
                    float y = ((float)Math.Floor(i / (double)map.Width) * map.TileHeight);
                    // Empty tile, do nothing
                    if (gid == 0)
                    {

                    }
                    else
                    {
                        if (gid >= 1025 && gid < 2049)
                        {

                            int blockTileFrame = gid - 1025;
                            int blockColumn = ((int)((double)blockTileFrame) % 8);
                            int blockRow = (int)Math.Floor((double)blockTileFrame / (double)blockTilesetTilesWide);
                            Rectangle tilesetRec1 = new Rectangle(tileWidth * blockColumn, tileHeight * blockRow, tileWidth, tileHeight);
                            spriteBatch.Draw(tileset1, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec1, Color.White);
                        }
                        if (gid < 705)
                        {
                            int wallTileFrame = gid - 1;
                            int wallColumn = ((int)((double)wallTileFrame) % 32);
                            int wallRow = (int)Math.Floor((double)wallTileFrame / (double)wallTilesetTilesWide);

                            Rectangle tilesetRec2 = new Rectangle(tileWidth * wallColumn, tileHeight * wallRow, tileWidth, tileHeight);
                            spriteBatch.Draw(tileset2, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec2, Color.White);
                        }

                        if (gid >= 705 && gid < 1025)
                        {
                            int doorTileFrame = gid - 705;
                            int doorColumn = ((int)((double)doorTileFrame) % 20);
                            int doorRow = (int)Math.Floor((double)doorTileFrame / (double)doorTilesetTilesWide);

                            Rectangle tilesetRec3 = new Rectangle(tileWidth * doorColumn, tileHeight * doorRow, tileWidth, tileHeight);
                            spriteBatch.Draw(tileset3, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec3, Color.White);
                        }
                        if (gid == 2049)
                        {
                            Rectangle tilesetRec4 = new Rectangle(tileWidth , tileHeight, tileWidth, tileHeight);
                            spriteBatch.Draw(tileset4, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec4, Color.White);
                        }
                        if (gid >2049)
                        {
                            int nonoTileFrame = gid - 2050;
                            int nonoColumn = ((int)((double)nonoTileFrame) % 8);
                            int nonoRow = (int)Math.Floor((double)nonoTileFrame / (double)doorTilesetTilesWide);

                            Rectangle tilesetRec5 = new Rectangle(tileWidth * nonoColumn, tileHeight * nonoRow, tileWidth, tileHeight);
                            spriteBatch.Draw(tileset5, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec5, Color.White);
                        }
                    }
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
