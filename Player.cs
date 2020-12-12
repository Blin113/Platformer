using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Player : BaseClass
    {
        private WeaponHandler weaponHandler;

        private MouseState old;
        private MouseState current;

        private Properties properties;

        public static Vector2 CurrentPlayerPos;

        public Player(Texture2D texture, Vector2 texturePos, float angle, Vector2 mousePos) : base(texture, texturePos, angle, mousePos)
        {
            hitBox.Size = new Point(40,40);

            
            //properties.Health = 100;
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
                weaponHandler.Shoot(texture, texturePos + new Vector2(0,8), angle, new Vector2(1,1), new Point(), mousePos, DamageOrigin.player);
            }

            old = Mouse.GetState();


            CurrentPlayerPos = new Vector2(texturePos.X, texturePos.Y);

            hitBox.Location = texturePos.ToPoint();

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)texturePos.X + 9, (int)texturePos.Y, 40, 40), null, Color.White, angle, new Vector2(/*entityPos.X +*/ texture.Width / 2,/* entityPos.Y +*/ texture.Height / 2), SpriteEffects.None, 0);
        }

        public void SetWeaponHandler(WeaponHandler wH)
        {
            weaponHandler = wH;
        }
        /*
        public void SetProperties(Properties prop)
        {
            properties = prop;
        }
        */
    }
}