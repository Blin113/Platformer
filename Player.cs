using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Player : BaseClass
    {
        public WeaponHandler weaponHandler;

        //var properties = new Properties();
        //properties.Health = 100;

        //Properties instance = new Properties(health, healthBar);

        public Player(Texture2D texture, Vector2 texturePos, float angle, Vector2 mousePos) : base(texture, texturePos, angle, mousePos)
        {

        }

        public override void Update()
        {
            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
            {
                texturePos.Y -= 3;
            }
            if (kstate.IsKeyDown(Keys.A))
            {
                texturePos.X -= 3;
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                texturePos.Y += 3;
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                texturePos.X += 3;
            }

            mousePos = Mouse.GetState().Position.ToVector2();
            angle = (float)Math.Atan2(texturePos.Y - mousePos.Y, texturePos.X - mousePos.X) + (float)(Math.PI);

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                weaponHandler.Shoot(texturePos, angle);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)texturePos.X, (int)texturePos.Y, 40, 40), null, Color.White, angle, new Vector2(/*entityPos.X +*/ texture.Width / 2,/* entityPos.Y +*/ texture.Height / 2), SpriteEffects.None, 0);
        }
    }
}