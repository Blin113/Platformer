using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Template
{
    class Assets
    {
        public static Texture2D Enemy
        {
            get;
            private set;
        }

        public static Texture2D bulletTexture
        {
            get;
            private set;
        }

        public static void LoadAssets(ContentManager contentManager)
        {
            Enemy = contentManager.Load<Texture2D>("enemy");

            bulletTexture = contentManager.Load<Texture2D>("bullet");
        }
    }
}
