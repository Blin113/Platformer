using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Player : BaseClass
    {
        Vector2 mousePos;
        float angle = 0;

        public Player(Texture2D entityTexture, Vector2 entityPos) : base(entityTexture, entityPos)
        {
            
        }

        public override void Update()
        {
            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
            {
                entityPos.Y -= 3;
            }
            if (kstate.IsKeyDown(Keys.A))
            {
                entityPos.X -= 3;
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                entityPos.Y += 3;
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                entityPos.X += 3;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                //shooting?
            }

            mousePos = Mouse.GetState().Position.ToVector2();
            angle = (float)Math.Atan2(entityPos.Y - mousePos.Y, entityPos.X - mousePos.X) + (float)(Math.PI);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(entityTexture, new Rectangle((int)entityPos.X, (int)entityPos.Y, 40, 40), null, Color.White, angle, new Vector2(entityTexture.Width / 2, entityTexture.Height / 2), SpriteEffects.None, 0);
        }
    }
}
