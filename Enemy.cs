﻿using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Template
{
    class Enemy : BaseClass
    {
        Player player;

        public Enemy(Texture2D texture, Vector2 texturePos, float angle) : base(texture, texturePos, angle)
        {

        }

        public override void Update()
        {
            angle = (float)Math.Atan2(texturePos.Y - player.Position.Y, texturePos.X - player.Position.X) + (float)(Math.PI);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)texturePos.X, (int)texturePos.Y, 40, 40), null, Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0);
        }
    }
}
