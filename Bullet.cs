using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class Bullet : BaseClass
    {
        Vector2 speed;
        Point size;
        float angle = 0;

        public Bullet(Texture2D texture, Vector2 texturePos, Vector2 speed, float angle) : base(texture, texturePos)
        {
            this.speed = speed;
            this.angle = angle;
        }

        public override void Update()
        {
            texturePos += speed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)texturePos.X, (int)texturePos.Y, size.X, size.Y), null, Color.White, angle, new Vector2(/*entityPos.X +*/ texture.Width / 2,/* entityPos.Y +*/ texture.Height / 2), SpriteEffects.None, 0);
        }
    }
}
