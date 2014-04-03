using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FishGame
{
    public class MenuScreen : Screen
    {

        Sprite image;
        string _fileName;

        public MenuScreen(Game1 game, string fileName) : base(game)
        {
            _fileName = fileName;

        }

        public override void LoadContent()
        {
            image = new Sprite(this, _fileName);
            image.position = new Vector2(screenwidth / 2, screenheight / 2);
            _inputManager = new InputManager(this);
            AddInput();
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (_inputManager["Quit"].IsDown)
                this._game.Exit();

            if (_inputManager["Start"].IsDown)
                GameStateManager.Instance.GameScreenChange(1);

            base.Update(gameTime);
        }

        internal void AddInput()
        {
            //Event Name                    //Corresponding Key
           _inputManager.AddEvent("Quit");  _inputManager["Quit"].Add(Keys.Escape);
           _inputManager.AddEvent("Start"); _inputManager["Start"].Add(Keys.Enter);
           _inputManager.AddEvent("Option");  _inputManager["Option"].Add(Keys.O);        
        }

        public override void Draw()
        {
            image.Draw();
            _inputManager.Draw();
        }

    }
}
