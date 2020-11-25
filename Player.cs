using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Player : BaseClass
    {
        WeaponHandler weaponHandler;

        MouseState old;
        MouseState current;

        //int hp;

        //Properties properties = new Properties(hp);
        

        public Player(Texture2D texture, Vector2 texturePos, float angle, Vector2 mousePos) : base(texture, texturePos, angle, mousePos)
        {

        }

        public override void Update()
        {
            KeyboardState kstate = Keyboard.GetState();


            //player movement
            if (kstate.IsKeyDown(Keys.W))
            {
                texturePos.Y -= 2;
            }
            if (kstate.IsKeyDown(Keys.A))
            {
                texturePos.X -= 2;
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                texturePos.Y += 2;
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                texturePos.X += 2;
            }


            //border
            if (texturePos.X <= 20)
            {
                texturePos.X = 20;
            }
            if (texturePos.X >= 780)
            {
                texturePos.X = 780;
            }
            if (texturePos.Y <= 20)
            {
                texturePos.Y = 20;
            }
            if (texturePos.Y >= 460)
            {
                texturePos.Y = 460;
            }


            //shooting and rotation
            mousePos = Mouse.GetState().Position.ToVector2();
            angle = (float)Math.Atan2(texturePos.Y - mousePos.Y, texturePos.X - mousePos.X) + (float)(Math.PI);

            old = current;
            current = Mouse.GetState();

            if (current.LeftButton == ButtonState.Pressed && old.LeftButton == ButtonState.Released)
            {
                weaponHandler.Shoot(texture, texturePos + new Vector2(0,8), angle, new Vector2(1,1), new Point((int)texturePos.X + 10 / 2, (int)texturePos.Y + 10 / 2), mousePos);
            }

            old = Mouse.GetState();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)texturePos.X + 9, (int)texturePos.Y, 40, 40), null, Color.White, angle, new Vector2(/*entityPos.X +*/ texture.Width / 2,/* entityPos.Y +*/ texture.Height / 2), SpriteEffects.None, 0);
        }

        public void SetWeaponHandler(WeaponHandler wH)
        {
            weaponHandler = wH;
        }
    }
}