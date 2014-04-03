using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace FishGame
{
    // This describes the screen transition state


    public abstract class Screen
    {
      

        protected GameStateManager gameStateManager;
        protected InputManager _inputManager;
        protected Viewport viewPort;
        protected Game1 _game;
        protected Color color;      // Temporary for testing purposes
        protected int screenwidth;
        protected int screenheight;

        public ContentManager content;
        public SpriteBatch spriteBatch;
       

        public Screen(Game1 game)
        {
            viewPort = new Viewport();
            content = game.Content;
            
            screenheight = 
                game.graphics.PreferredBackBufferHeight = 600;
            screenwidth = 
                game.graphics.PreferredBackBufferWidth = 1080;
            game.graphics.ApplyChanges();
            _game = game;
        }

        public virtual void LoadContent()
        {
            spriteBatch = _game.spriteBatch;
        }
        public void UnloadContent()
        {
            GameStateManager.Instance.DeleteScreen();
        }
        
        public virtual void Draw()
        {
          
        }

        public virtual void Update(GameTime gameTime)
        {
            _inputManager.Update(gameTime);
        }    

    }
}
