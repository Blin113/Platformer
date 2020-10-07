using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Player
    {
        Texture2D man;
        Vector2 manPos = new Vector2(200, 20);

        public Player(Texture2D man)
        {
            this.man = man;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState kState = Keyboard.GetState();


        }

        public void Draw(GameTime gameTime)
        {
            SpriteBatch.Draw(man, new Rectangle((int)manPos.X, (int)manPos.Y, 20, 20), Color.White);
        }
    }
}
