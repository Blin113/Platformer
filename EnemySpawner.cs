using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class EnemySpawner
    {
        List<Enemy> enemies = new List<Enemy>();
        float time = 5;
        float timer = 0;
        Random rnd = new Random();

        public EnemySpawner(List<Enemy> enemies)
        {
            this.enemies = enemies;
        }

        public void Update(GameTime gameTime)
        {
            if(timer >= time)
            {
                timer -= time;
                int x;
                int y;
                do
                {
                    x = rnd.Next(0, 800/40);
                    y = rnd.Next(0, 480/40);
                } while (Game1.Map[y,x] != 1);
            }



            /*for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == '1')
                    {
                        
                    }
                }
            }
               */ 
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
