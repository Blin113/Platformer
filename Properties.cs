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
    class Properties
    {
        protected int health;
        protected Texture2D healthBar;

        public Properties(int health, Texture2D healthBar)
        {
            this.health = health;
            this.healthBar = healthBar;
        }

        public int Health{
            get{ return health; }
            set
            {
                if(value < 0)
                {
                    Console.WriteLine("Negative health!");
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        void Update() { }

        void Draw(SpriteBatch spriteBatch) { }
    }
}
