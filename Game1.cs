using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D man;
        Vector2 manPos = new Vector2(40, 200);

        Texture2D croshair;
        Vector2 cursorPos;

        Player player;

        Texture2D groundTexture;
        Texture2D rock;

        const int BLOCK_SIZE = 40;

        char[,] map = new char[,] {
            { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' , '0', '0', '0', '0', '0', '0', '0', '0', '1', '1'},
            { '0', '0', '0', '0', '0', '0', '1', '1', '1', '1' , '1', '1', '1', '0', '0', '0', '0', '0', '1', '1'},
            { '0', '0', '0', '0', '0', '0', '1', '1', '1', '0' , '0', '0', '1', '0', '0', '0', '0', '0', '1', '1'},
            { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1' , '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
            { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1' , '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
            { '1', '1', '1', '0', '0', '1', '1', '1', '1', '1' , '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
            { '1', '1', '1', '0', '0', '1', '1', '1', '1', '1' , '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
            { '1', '1', '1', '1', '1', '1', '1', '1', '1', '2' , '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
            { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1' , '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
            { '0', '0', '0', '0', '0', '0', '1', '1', '1', '0' , '0', '0', '1', '0', '0', '0', '0', '0', '1', '1'},
            { '0', '0', '0', '0', '0', '0', '1', '1', '1', '1' , '1', '1', '1', '0', '0', '0', '0', '0', '1', '1'},
            { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' , '0', '0', '0', '0', '0', '0', '0', '0', '1', '1'}

        };


        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "GEM - Generic platform game?";
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

            //IsMouseVisible = true;

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

            groundTexture = Content.Load<Texture2D>("groundTexture");
            rock = Content.Load<Texture2D>("rock");

            man = Content.Load<Texture2D>("man");
            croshair = Content.Load<Texture2D>("croshair");

            player = new Player(man, manPos);



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

            MouseState Mstate = Mouse.GetState();
            cursorPos = new Vector2(Mstate.X, Mstate.Y);

            cursorPos = Mouse.GetState().Position.ToVector2();



            // TODO: Add your update logic here

            base.Update(gameTime);
            player.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // TODO: Add your drawing code here.

            spriteBatch.Begin();

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == '1')
                    {
                        spriteBatch.Draw(groundTexture, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE), Color.White);
                    }
                }
            }

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == '2')
                    {
                        spriteBatch.Draw(groundTexture, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE), Color.White);
                        spriteBatch.Draw(rock, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE), Color.White);
                    }
                }
            }

            player.Draw(spriteBatch);

            spriteBatch.Draw(croshair, new Rectangle((int)cursorPos.X - 50, (int)cursorPos.Y - 50, 100, 100), Color.Purple);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}