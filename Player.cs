using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Player : BaseClass
    {
        Vector2 mousePos;
        float angle = 0;

        //var properties = new Properties();
        //properties.Health = 100;

        Properties instance = new Properties(health:, healthBar);

        public Player(Texture2D texture, Vector2 texturePos) : base(texture, texturePos)
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

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                weapon.Shoot();
            }

            mousePos = Mouse.GetState().Position.ToVector2();
            angle = (float)Math.Atan2(texturePos.Y - mousePos.Y, texturePos.X - mousePos.X) + (float)(Math.PI);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)texturePos.X, (int)texturePos.Y, 40, 40), null, Color.White, angle, new Vector2(/*entityPos.X +*/ texture.Width / 2,/* entityPos.Y +*/ texture.Height / 2), SpriteEffects.None, 0);
        }
    }
}