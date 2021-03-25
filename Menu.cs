using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    //menu
    enum CurrentMenu
    {
        StartMenu,
        ColorMenu,
        PauseMenu,
        DeathMenu,
        None
    }

    class Menu
    {
        public CurrentMenu CurrentMenu { get { return currentMenu; } }

        CurrentMenu currentMenu = CurrentMenu.StartMenu;

        public Menu()
        {

        }

        public void Update()
        {
            switch (currentMenu)
            {
                case CurrentMenu.StartMenu:
                    StartMenu();
                    break;

                case CurrentMenu.ColorMenu:
                    ColorMenu();
                    break;

                case CurrentMenu.PauseMenu:
                    PauseMenu();
                    break;

                case CurrentMenu.DeathMenu:
                    DeathMenu();
                    break;

                case CurrentMenu.None:
                    if(Keyboard.GetState().IsKeyDown(Keys.P))
                        currentMenu = CurrentMenu.PauseMenu;
                    break;

                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (currentMenu)
            {
                case CurrentMenu.StartMenu:
                    spriteBatch.DrawString(Assets.MenuFont, "Press space to continue", new Vector2(250, 300), Color.Purple);
                    break;

                case CurrentMenu.ColorMenu:
                    spriteBatch.DrawString(Assets.MenuFont, "Press space to continue", new Vector2(250, 300), Color.Purple);
                    break;

                case CurrentMenu.PauseMenu:
                    spriteBatch.Draw(Assets.PauseScreen, new Rectangle(0, 0, 800, 480), new Color(Color.White, 1));
                    spriteBatch.DrawString(Assets.MenuFont, "Press space to continue", new Vector2(250, 300), Color.Purple);
                    break;

                case CurrentMenu.DeathMenu:
                    spriteBatch.DrawString(Assets.MenuFont, "Press SPACE to restartn\n Press ESCAPE to exit", new Vector2(250, 300), Color.Purple);
                    break;

                case CurrentMenu.None:
                    break;

                default:
                    break;
            }
        }

        public void StartMenu()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                currentMenu = CurrentMenu.None;
        }

        public void ColorMenu()
        {
            //if (Keyboard.GetState().IsKeyDown(Keys.Space))
                currentMenu = CurrentMenu.None;
        }
        public void PauseMenu()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                currentMenu = CurrentMenu.None;

            //if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                //Exit
        }

        public void DeathMenu()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                currentMenu = CurrentMenu.ColorMenu;

            //if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                //Exit
        }

    }
}
