using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class EnemySpawner
    {
        private List<Enemy> enemies = new List<Enemy>();
        private List<Bullet> bullets = new List<Bullet>();
        private float time = 5;
        private float timer = 0;
        private Random rnd = new Random();

        public EnemySpawner(List<Enemy> enemies, List<Bullet> bullets1)
        {
            this.enemies = enemies;
            bullets = bullets1;
        }

        public void Update(GameTime gameTime)
        {
            if(timer >= time)       //intervall
            {
                timer -= time;
                int x;
                int y;
                do
                {
                    x = rnd.Next(0, 800/40);
                    y = rnd.Next(0, 480/40);
                } while (Game1.Map[y,x] != '1');        //om inte [y,x] positionen på mappen är 1 så kommer den inte skapa en fiende
                enemies.Add(new Enemy(Assets.Enemy, new Vector2(x * 40, y * 40), 0, new WeaponHandler(bullets)));
            }


            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
