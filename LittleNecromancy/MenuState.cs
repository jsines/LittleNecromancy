using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LittleNecromancy
{
    class MenuState : GameState 
    {
        TextBox titleText;
        AnimatedSprite anim;
        Sprite box;

        public override void Initialize()
        {
            box = new Sprite("titleText");
            box.SetPosition(new Vector2(1, 0));
            box.SetZ(1);
            AddEntity("box", box);

            anim = new AnimatedSprite("testanimation", 3, 250);
            anim.SetPosition(new Vector2(500, 500));
            anim.SetZ(4);
            AddEntity("testanimation", anim);

            titleText = new TextBox("rainy", "Hello World", Color.Black);
            titleText.SetZ(4);
            titleText.SetParent(anim);
            titleText.SetPosition(new Vector2(10, 50));
            AddEntity("titletext", titleText);

            LittleNecromancy.Input.AddKeyPressHandler(Keys.W, delegate () { move(0, -20); });
            LittleNecromancy.Input.AddKeyPressHandler(Keys.S, delegate () { move(0, 20); });
            LittleNecromancy.Input.AddKeyPressHandler(Keys.A, delegate () { move(-20, 0); });
            LittleNecromancy.Input.AddKeyPressHandler(Keys.D, delegate () { move(20, 0); });
        }


        public override void Update(GameTime gameTime)
        {
            
        }
        private void move(int i, int j)
        {
            box.SetPosition(box.GetPosition() + new Vector2(i, j));
        }
    }
}
