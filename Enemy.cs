using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Template
{
    class Enemy : BaseClass
    {
        private WeaponHandler weaponHandler;

        private Random rnd = new Random();

        public Enemy(Texture2D texture, Vector2 texturePos, float angle, WeaponHandler weaponHandler) : base(texture, texturePos, angle)
        {
            this.weaponHandler = weaponHandler;
            hitBox.Size = new Point(40, 40);
        }

        public override void Update()
        {
            angle = (float)Math.Atan2(texturePos.Y - Player.CurrentPlayerPos.Y, texturePos.X - Player.CurrentPlayerPos.X) + (float)(Math.PI);


            if (rnd.Next(0, 100) <= 1)
            {
                weaponHandler.Shoot(texture, texturePos + new Vector2(0, 8), angle, new Vector2(1, 1), new Point((int)texturePos.X + 10 / 2, (int)texturePos.Y + 10 / 2), Player.CurrentPlayerPos, DamageOrigin.enemy);
            }

            hitBox.Location = texturePos.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)texturePos.X, (int)texturePos.Y, 40, 40), null, Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0);
        }

    }
}
