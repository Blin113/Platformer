using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Player : BaseClass
    {
        public Player(Texture2D texture, Vector2 texturePos, float angle, Vector2 mousePos) : base(texture, texturePos, angle, mousePos)
        {
            hitBox.Size = new Point(20, 20);
        }

        public override void Update()
        {
            KeyboardState kstate = Keyboard.GetState();


            //player movement
            if (kstate.IsKeyDown(Keys.W))
            {
                texturePos.Y -= 20;
            }
            if (kstate.IsKeyDown(Keys.A))
            {
                texturePos.X -= 20;
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                texturePos.Y += 20;
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                texturePos.X += 20;
            }

            //border
            if (texturePos.X <= 0)
            {
                texturePos.X = 0;
            }
            if (texturePos.X >= 2000)
            {
                texturePos.X = 2000;
            }
            if (texturePos.Y <= 0)
            {
                texturePos.Y = 0;
            }
            if (texturePos.Y >= 2000)
            {
                texturePos.Y = 2000;
            }

            //shooting and rotation
            mousePos = Mouse.GetState().Position.ToVector2();
            angle = (float)Math.Atan2(texturePos.Y - mousePos.Y, texturePos.X - mousePos.X) + (float)(Math.PI);
            hitBox.Location = texturePos.ToPoint();

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.Player, new Rectangle((int)texturePos.X, (int)texturePos.Y, 20, 20), null, Color.White, angle, new Vector2(Assets.Player.Width / 2,Assets.Player.Height / 2), SpriteEffects.None, 0);
        }
    }
}
