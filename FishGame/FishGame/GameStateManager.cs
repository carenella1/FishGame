using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FishGame
{
    public class GameStateManager
    {
         #region Variables

        // creating custom contentmanager
        

        Screen currentScreen;
        
        SplashScreen first, second;

        /*
         * These two screen types will have child classes such as
         * MenuScreen -> TitleScreen, PauseScreen, OptionScreen
         * GameScreen -> Level1, Level2, Level3
         * 
         * This is where we can add the extra stuff.
         */
        MenuScreen menu, pause;
        GameScreen Level1, Level2;
        

        // Screenmanager instance
        private static GameStateManager instance;

        // Screen stack
        List<Screen> screenList = new List<Screen>();       

        #endregion

        #region Properties

        public static GameStateManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameStateManager();
                return instance;
            }
        }
        #endregion

        private void ListScreens(Game1 game)
        {
            screenList.Add(first = new SplashScreen(game, Color.Black, "The League Logo"));
            screenList.Add(second = new SplashScreen(game, Color.Aquamarine, "The League Logo"));
            screenList.Add(menu = new MenuScreen(game, "Title Screen"));
            screenList.Add(pause = new MenuScreen(game, "The League Logo"));
        }

        public void Initialize(Game1 game)
        {
            ListScreens(game);
            currentScreen = screenList[0];
        }

        public void LoadContent()
        {
            foreach (Screen obj in screenList)
                obj.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }
        public void Draw()
        {
            currentScreen.Draw();
        }
        
        public void DeleteScreen()
        {
            screenList.RemoveAt(0);
            currentScreen = screenList[0];
        }  
    
        public void GameScreenChange(int screen)
        {
            currentScreen = screenList[screen];
        }
    }
}
