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

        public EnemySpawner()
        {

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
                    x = rnd.Next(0, 800);
                    y = rnd.Next(0, 480);
                } while (true);
            }




            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
