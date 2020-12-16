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
        private Texture2D groundTexture;
        private Texture2D rock;

        //mouse
        private Texture2D croshair;
        private Vector2 cursorPos;
        private Vector2 mousePos;

        //player, bullet
        private Texture2D texture;
        private float angle;
        private Vector2 texturePos = new Vector2(40, 200);
        private Point size;
        private Vector2 speed;
        private List<Bullet> bullets1 = new List<Bullet>();


        //Enemy, enmey bullet
        private List<Enemy> enemies1 = new List<Enemy>();

        //classes
        private Player player;
        private WeaponHandler weaponHandler;
        private Properties properties;
        private EnemySpawner enemySpawner;

        const int BLOCK_SIZE = 40;

        static char[,] map = new char[,] {
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

        public static char[,] Map
        {
            get => map;
        }

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
            enemySpawner = new EnemySpawner(enemies1, bullets1);
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

            Assets.LoadAssets(Content);

            groundTexture = Content.Load<Texture2D>("groundTexture");
            rock = Content.Load<Texture2D>("rock");

            texture = Content.Load<Texture2D>("man");
            croshair = Content.Load<Texture2D>("croshair");

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
            //player.SetProperties(properties);
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

            base.Update(gameTime);
            weaponHandler.Update();
            player.Update();
            foreach (Enemy item in enemies1)
            {
                item.Update();
            }
            enemySpawner.Update(gameTime);

            Collision();
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // TODO: Add your drawing code here.

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);

            for (int y = 0; y < map.GetLength(0); y++)      //rita ut marken
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == '1')
                    {
                        spriteBatch.Draw(groundTexture, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE), Color.White);
                    }
                }
            }

            for (int y = 0; y < map.GetLength(0); y++)      //rita ut stenar
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

            foreach (Bullet item in bullets1)   //rita ut bullets
            {
                item.Draw(spriteBatch);
            }

            foreach (Enemy item in enemies1)        //rita ut fiender
            {
                item.Draw(spriteBatch);
            }

            player.Draw(spriteBatch);       //rita ut spelaren

            spriteBatch.Draw(croshair, new Rectangle((int)cursorPos.X - 50, (int)cursorPos.Y - 50, 100, 100), Color.Purple); 

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Collision()
        {
            for(int i = 0; i < bullets1.Count; i++)
            {
                for (int j = 0; j < enemies1.Count; j++)
                {
                    if (bullets1[i].GetDamageOrigin == DamageOrigin.player && enemies1[j].HitBox.Intersects(bullets1[i].HitBox))
                    {
                        enemies1.RemoveAt(j);
                        bullets1.RemoveAt(i);

                        i--;
                        break;
                    }
                }
            }

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    for (int i = 0; i < bullets1.Count; i++)
                    {
                        if (map[y, x] == '2' && new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE).Intersects(bullets1[i].HitBox))
                        {
                            bullets1.RemoveAt(i);

                            i--;
                        }
                    }
                }
            }

            for (int i = 0; i < bullets1.Count; i++)
            {
                if (bullets1[i].GetDamageOrigin == DamageOrigin.enemy && player.HitBox.Intersects(bullets1[i].HitBox))
                {   
                    bullets1.RemoveAt(i);

                    i--;
                    
                    Exit();
                }
            }
        }

    }
}