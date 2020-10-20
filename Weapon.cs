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
    class Weapon : BaseClass
    {
        List<int> bullets;

        public Weapon(Texture2D texture, Vector2 texturePos, List<int> bullets) : base(texture, texturePos)
        {
            this.bullets = bullets;
        }

        public override void Update() {
            
        }

        void Shoot()
        {

        }

        public override void Draw(SpriteBatch spriteBatch) { }
    }
}
