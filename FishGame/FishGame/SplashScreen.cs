using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FishGame
{
    public class SplashScreen : Screen
    {

        Sprite image;
        string _fileName;

        protected float time = 0;
   
        public SplashScreen(Game1 game, Color t_color, string fileName) : base(game)
        {
            _fileName = fileName;
            color = t_color;
        }

        public override void LoadContent()
        {
            image = new Sprite(this, _fileName);
            image.scale = .5f;
            image.position = new Vector2(screenwidth / 2, screenheight / 2);
            base.LoadContent();
        }

       

        public override void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(time >= 5)
            {
               UnloadContent();
            }
        }
       
        public override void Draw()
        {
            _game.GraphicsDevice.Clear(color);
            image.Draw();
        }
    }
}
