using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    abstract class BaseClass
    {
        protected Texture2D texture;
        protected Vector2 texturePos;
        protected float angle = 0;
        protected Vector2 mousePos;

        public Vector2 Position
        {
            get => texturePos;
            set => texturePos = value;
        }

        public BaseClass(Texture2D texture, Vector2 texturePos, float angle)
        {
            this.texture = texture;
            this.texturePos = texturePos;
            this.angle = angle;
            this.mousePos = Vector2.Zero;
        }

        public BaseClass(Texture2D texture, Vector2 texturePos, float angle, Vector2 mousePos)
        {
            this.texture = texture;
            this.texturePos = texturePos;
            this.angle = angle;
            this.mousePos = mousePos;
        }

        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}