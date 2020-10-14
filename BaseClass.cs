using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    abstract class BaseClass
    {
        protected Texture2D entityTexture;
        protected Vector2 entityPos;

        public BaseClass(Texture2D entityTexture, Vector2 entityPos)
        {
            this.entityTexture = entityTexture;
            this.entityPos = entityPos;
        }

        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
