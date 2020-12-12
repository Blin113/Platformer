using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Template
{
    class WeaponHandler
    {
        List<Bullet> bullets = new List<Bullet>();

        public WeaponHandler(List<Bullet> bullets1)
        {
            bullets = bullets1;
        }

        public void Update()
        {
            foreach (Bullet item in bullets)
            {
                item.Update();
            }
        }

        public void Shoot(Texture2D bulletTexture, Vector2 playerPos, float angle, Vector2 speed, Point size, Vector2 mousePos, DamageOrigin damageOrigin)
        {
            bullets.Add(new Bullet(bulletTexture, playerPos, speed, angle, size, mousePos, damageOrigin));
        }
    }
}
