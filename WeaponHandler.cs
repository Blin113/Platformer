using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Template
{
    class WeaponHandler
    {
        Bullet bullet;
        Vector2 speed;
        Point size;

        List<Bullet> bullets = new List<Bullet>();
        Texture2D bulletTexture;

        public WeaponHandler(Texture2D bulletTexture)
        {
            this.bulletTexture = bulletTexture;

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
