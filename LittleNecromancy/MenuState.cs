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
        Entity titleText;
        Entity anim;
        Entity box2;
        Entity box3;

        public override void Initialize()
        {
            titleText = new TextBox();
            titleText.position = new Vector2(0, 100);

            AddEntity("titletext", titleText);
            System.Diagnostics.Debug.WriteLine("Added box");

            anim = new AnimatedSprite();
            AddEntity("testanimation", anim);
            System.Diagnostics.Debug.WriteLine("Added anim");

            box2 = new TextBox();
            box2.position = new Vector2(123, 456);
            AddEntity("box2", box2);

            box3 = new TextBox();
            box3.position = new Vector2(789, 12);
            AddEntity("box3", box3);
        }

        public void Update()
        {
            
        }
    }
}
