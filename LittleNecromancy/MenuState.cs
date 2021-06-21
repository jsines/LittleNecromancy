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
            titleText = new TextBox("rainy", "Hello World", Color.Black);
            titleText.position = new Vector2(0, 500);
            titleText.z = 1;
            AddEntity("titletext", titleText);
            System.Diagnostics.Debug.WriteLine("Added textbox");

            anim = new AnimatedSprite("testanimation", 3, 250);
            anim.position = new Vector2(500, 500);
            anim.z = 4;
            AddEntity("testanimation", anim);
            System.Diagnostics.Debug.WriteLine("Added anim");

            box = new Sprite("titleText");
            box.position = new Vector2(250, 0);
            box.z = 3;
            AddEntity("box", box);
            System.Diagnostics.Debug.WriteLine("Added box");
        }

        int x, y = 0;
        bool reversex, reversey = false;
        public override void UpdateState()
        {
            titleText.position = new Vector2(x, y);
            if (x > 1280) reversex = true; 
            if (x < 0) reversex = false;
            if (!reversex) x++;
            if (reversex) x--;
            if (y > 720) reversey = true;
            if (y < 0) reversey = false;
            if (!reversey) y++;
            if (reversey) y--;
        }
    }
}
