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
        Sprite fade;
        TextBox titleText;
        Entity buttonsBox;
        TextBox playButton;
        TextBox optionsButton;
        TextBox exitButton;
        List<TextBox> buttons;
        public int cursorPosition = 0;
        Sprite box;

        public override void Initialize()
        {
            box = new Sprite("titletext");
            box.SetPosition(Vector2.Zero);
            AddEntity("box", box);

            fade = new Sprite("fademask");
            fade.SetPosition(cameraPosition);
            fade.SetZ(100);
            AddEntity("fademask", fade);

            titleText = new TextBox("rainy", "Little Necromancy", Color.Black);
            titleText.SetPosition(new Vector2(500, 100));
            AddEntity("title", titleText);

            buttons = new List<TextBox>();
            buttonsBox = new Entity();
            buttonsBox.SetPosition(new Vector2(100, 300));
            AddEntity("buttonsBox", buttonsBox);

            playButton = new TextBox("rainy", "Play", Color.Yellow);
            playButton.SetParent(buttonsBox);
            playButton.SetPosition(new Vector2(10, 0));
            buttons.Add(playButton);
            AddEntity("playButton", playButton);

            optionsButton = new TextBox("rainy", "Options", Color.Black);
            optionsButton.SetParent(buttonsBox);
            optionsButton.SetPosition(new Vector2(0, 50));
            buttons.Add(optionsButton);
            AddEntity("optionsButton", optionsButton);

            exitButton = new TextBox("rainy", "Exit", Color.Black);
            exitButton.SetParent(buttonsBox);
            exitButton.SetPosition(new Vector2(0, 100));
            buttons.Add(exitButton);
            AddEntity("exitButton", exitButton);

            InputSetup();
            Timer.AddExpirableHandler(2000, delegate (double msSince, double dt)
            {
                double t = msSince / 2000;
                fade.SetAlpha((float) (1 - Math.Pow(t, 4)));
            });
        }
        
        
        public override void Update(GameTime gameTime)
        {
            

        }
        private void InputSetup()
        {
            Input.AddKeyPressHandler(Keys.W, delegate () {
                moveCursor(false);
            });
            Input.AddKeyPressHandler(Keys.S, delegate () {
                moveCursor(true);
            });
            Input.AddKeyPressHandler(Keys.Enter, delegate ()
            {
                enterHandler(cursorPosition);
            });
            Input.AddKeyPressHandler(Keys.J, delegate ()
            {
                moveBox(0);
            });
            Input.AddKeyPressHandler(Keys.K, delegate ()
            {
                moveBox(1);
            });
            Input.AddKeyPressHandler(Keys.L, delegate ()
            {
                moveBox(2);
            });
        }
        private void moveBox(int i)
        {
            box.SetX(0);
            Func<double, double> f;
            switch (i)
            {
                case 0:
                    f = Timer.Util.SmoothStepN(100);
                    break;
                case 1:
                    f = Timer.Util.SmoothStepN2(100);
                    break;
                case 2:
                    f = Timer.Util.SmootherStep();
                    break;
                default:
                    f = Timer.Util.SmootherStep();
                    break;
            }
            Timer.AddExpirableHandler(2000, delegate (double msSince, double dt)
            {
                double t = msSince / 2000;
                box.SetX((1280-200) * (float)f(t));
            });
        }
        private void moveCursor(bool down)
        {
            TextBox oldtb = buttons[cursorPosition];
            oldtb.SetColor(Color.Black);
            Timer.AddExpirableHandler(500, delegate (double msSince, double dt)
            {
                double t = msSince / 500;
                oldtb.SetX((float)(10 - 10 * Timer.Util.SmoothStopN(2)(t)));
            });
            int i = down ? 1 : -1;
            cursorPosition = ((cursorPosition + i) % 3);
            if (cursorPosition < 0) cursorPosition += 3;
            TextBox newtb = buttons[cursorPosition];
            newtb.SetColor(Color.Yellow);
            Timer.AddExpirableHandler(500, delegate (double msSince, double dt)
            {
                double t = msSince / 500;
                newtb.SetX((float)(10 * Timer.Util.SmoothStopN(2)(t)));
            });
        }

        private void enterHandler(int cursorPosition)
        {
            switch (cursorPosition)
            {
                case 0:
                    Timer.AddExpirableHandler(2000, delegate (double msSince, double dt)
                    {
                        double t = msSince / 2000; // 0 to 1
                        fade.SetAlpha((float)Timer.Util.SmoothStopN(3)(t));
                    }, delegate ()
                    {
                        var x = GetEntities();
                        LittleNecromancy.Stack.Pop();
                        LittleNecromancy.Stack.Push(new ERDebugState(x));
                    });
                    break;
                case 2:
                    Timer.AddExpirableHandler(1000, delegate (double msSince, double dt)
                    {
                        double t = msSince / 1000; // 0 to 1
                        fade.SetAlpha((float)Timer.Util.SmoothStopN(3)(t));
                    }, delegate ()
                    {
                        LittleNecromancy.Exit = true;
                    });
                    break;
            }
        }
    }
}
