using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        //enemy, bullet
        Texture2D eTexture;
        Vector2 eTexturePos;
        float eAngle;
        List<Bullet> eBullets = new List<Bullet>();

        //classes
        Player player;
        WeaponHandler weaponHandler;
        Bullet bullet;
        Enemy enemy;

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
            Window.Title = "GEM - Generic game?";
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

            eTexture = Content.Load<Texture2D>("enemy");


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


            //ladda in variabler och texturer

            //player, player bullets
            player = new Player(texture, texturePos, angle, mousePos);
            weaponHandler = new WeaponHandler(bullets1);
            player.SetWeaponHandler(weaponHandler);

            //bullet
            bullet = new Bullet(bulletTexture, texturePos, speed, angle, size, mousePos);

            //enemy, enemy bullets
            enemy = new Enemy(eTexture, eTexturePos, eAngle);
            //weaponHandler = new WeaponHandler(eBullets);
            //enemy.SetWeaponHandler(weaponHandler);

        }

        protected override void UnloadContent()
        {

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

                                                                                        //gränser för spelarens rörelse så den inte rör sig ut ur ettorna i char map
            int x = (int)player.Position.X/BLOCK_SIZE;
            int y = (int)player.Position.Y/BLOCK_SIZE;
            int a = ((int)player.Position.X / BLOCK_SIZE)+1;

            if (map[y, x + 1] == '0' || map[y, x + 1] == '2')
            {
                player.Position = new Vector2(x * BLOCK_SIZE, player.Position.Y);
            }
            else if( map[y, a - 1] == '0' || map[y, a - 1] == '2')
            {
                player.Position = new Vector2(a * BLOCK_SIZE, player.Position.Y);
            }

           
            int b = ((int)player.Position.Y / BLOCK_SIZE)+1;

            if (map[y + 1, a] == '0' || map[y + 1, a] == '2')
            {
                player.Position = new Vector2(player.Position.X, y * BLOCK_SIZE);
            }
            else if ( map[b - 1, x] == '0' || map[b - 1, x] == '2')
            {
                player.Position = new Vector2(player.Position.X, b * BLOCK_SIZE);
            }

            base.Update(gameTime);      //kalla Update() metoder från klasserna
            weaponHandler.Update();
            bullet.Update();
            player.Update();
            //enemy.Update();
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.NonPremultiplied);

            for (int y = 0; y < map.GetLength(0); y++)      //draw map
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == '1')
                    {
                        spriteBatch.Draw(groundTexture, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE), Color.White);
                    }
                }
            }

            for (int y = 0; y < map.GetLength(0); y++)      //draw map
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

            player.Draw(spriteBatch);       //draw player

            spriteBatch.Draw(croshair, new Rectangle((int)cursorPos.X - 50, (int)cursorPos.Y - 50, 100, 100), Color.Purple);        //draw mouse

            foreach(Bullet item in bullets1)        //draw bullets
            {
                item.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}