using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //map
        Texture2D groundTexture;
        Texture2D rock;

        //mouse
        Texture2D croshair;
        Vector2 cursorPos;
        Vector2 mousePos;

        //player, bullet
        Texture2D texture, bulletTexture;
        float angle;
        Vector2 texturePos = new Vector2(40, 200);
        Point size;
        Vector2 speed;
        List<Bullet> bullets1 = new List<Bullet>();

        //classes
        Player player;
        WeaponHandler weaponHandler;
        Bullet bullet;

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

            texture = Content.Load<Texture2D>("man");
            croshair = Content.Load<Texture2D>("croshair");

            bulletTexture = Content.Load<Texture2D>("bullet");


            Color[] data = new Color[texture.Height * texture.Width];       //fixa png
            texture.GetData(data);
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].R >= 220)
                    data[i] = new Color(0,0,0,0);
            }
            texture.SetData(data);

            data = new Color[rock.Height * rock.Width];
            rock.GetData(data);
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].R >= 230)
                    data[i].A = 0;
            }
            rock.SetData(data);                                             //fixa png

            player = new Player(texture, texturePos, angle, mousePos);
            weaponHandler = new WeaponHandler(bullets1);
            player.SetWeaponHandler(weaponHandler);
            bullet = new Bullet(bulletTexture, texturePos, speed, angle, size, mousePos);

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

            // TODO: Add your update logic here
            int x = (int)player.Position.X/BLOCK_SIZE;
            int y = (int)player.Position.Y/BLOCK_SIZE;

            if (map[y, x+1] == '0')
            {
                player.Position = new Vector2(x * BLOCK_SIZE, player.Position.Y);
            }
            else if(map[y, x-1] == '0')
            {
                player.Position = new Vector2(x * BLOCK_SIZE, player.Position.Y);
            }

            base.Update(gameTime);
            weaponHandler.Update();
            //bullet.Update();
            player.Update();
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // TODO: Add your drawing code here.

            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.NonPremultiplied);

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

            foreach(Bullet item in bullets1)
            {
                item.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}