using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class WeaponHandler
    {
        List<Bullet> bullets;
        Texture2D bulletTexture;

        Vector2 speed;

        public void Update()
        {
            foreach (Bullet item in bullets)
            {
                item.Update();
            }

        }

        public void Shoot(Vector2 playerPos, float angle)
        {
            bullets.Add(new Bullet(bulletTexture, playerPos, speed, angle));
        }
    }
}
