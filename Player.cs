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
    class Player
    {
        Texture2D man;
        Vector2 manPos = new Vector2(40, 200);
        Vector2 mousePos;
        float angle = 0;


        public Player(Texture2D man, Vector2 manPos)
        {
            this.man = man;
            this.manPos = manPos;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
            {
                manPos.Y -= 3;
            }
            if (kstate.IsKeyDown(Keys.A))
            {
                manPos.X -= 3;
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                manPos.Y += 3;
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                manPos.X += 3;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                //shooting?
            }

            mousePos = Mouse.GetState().Position.ToVector2();
            angle = (float)Math.Atan2(manPos.Y - mousePos.Y, manPos.X - mousePos.X) + (float)(Math.PI);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(man, new Rectangle((int)manPos.X, (int)manPos.Y, 40, 40), null, Color.White, angle, new Vector2(man.Width / 2, man.Height / 2), SpriteEffects.None, 0);
        }
    }
}