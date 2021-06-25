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
            box.z = 1;
            AddEntity("box", box);

            anim = new AnimatedSprite("testanimation", 3, 250);
            anim.SetPosition(new Vector2(500, 500));
            anim.z = 4;
            AddEntity("testanimation", anim);

            titleText = new TextBox("rainy", "Hello World", Color.Black);
            titleText.z = 3;
            titleText.SetParent(box);
            titleText.SetPosition(new Vector2(10, 50));
            AddEntity("titletext", titleText);

        }


        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                box.SetPosition(box.GetPosition() + new Vector2(0, -5));
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                box.SetPosition(box.GetPosition() + new Vector2(0, 5));
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                box.SetPosition(box.GetPosition() + new Vector2(-5, 0));
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                box.SetPosition(box.GetPosition() + new Vector2(5, 0));
        }
    }
}
