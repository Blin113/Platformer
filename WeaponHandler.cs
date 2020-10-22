using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Template
{
    class WeaponHandler
    {
        Bullet bullet;

        List<Bullet> bullets;
        Texture2D bulletTexture;

        public WeaponHandler(Texture2D bulletTexture, Vector2 speed, Point size)
        {
            this.bulletTexture = bulletTexture;
            bullet.speed = speed;
            bullet.size = size;
        }

        public void Update()
        {
            foreach (Bullet item in bullets)
            {
                item.Update();
            }
        }

        public void Shoot(Vector2 playerPos, float angle, Vector2 speed, Point size, Vector2 mousePos)
        {
            bullets.Add(new Bullet(bulletTexture, playerPos, speed, angle, size, mousePos));
        }
    }
}