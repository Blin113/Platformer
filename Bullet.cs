using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class Bullet : BaseClass
    {
        public Vector2 speed;
        public Point size = new Point(5, 5);

        public Bullet(Texture2D texture, Vector2 texturePos, Vector2 speed, float angle, Point size, Vector2 mousePos) : base(texture, texturePos, angle, mousePos)
        {
            this.speed = speed;
        }

        public override void Update()
        {
            texturePos += new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 5;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)texturePos.X, (int)texturePos.Y, size.X, size.Y), null, Color.White, angle, new Vector2(texturePos.X + texture.Width / 2, texturePos.Y + texture.Height / 2), SpriteEffects.None, 0);
        }
    }
}