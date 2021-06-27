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
        const float titleTextY = 100;
        public override void Initialize()
        {
            fade = new Sprite("fademask");
            fade.SetPosition(cameraPosition);
            fade.SetZ(100);
            AddEntity("fademask", fade);

            titleText = new TextBox("rainy", "Little Necromancy", Color.Black);
            titleText.SetPosition(new Vector2(500, titleTextY));
            AddEntity("title", titleText);

            buttons = new List<TextBox>();
            buttonsBox = new Entity();
            buttonsBox.SetPosition(new Vector2(100, 300));
            AddEntity("buttonsBox", buttonsBox);

            playButton = new TextBox("rainy", "Play", Color.Yellow);
            playButton.SetParent(buttonsBox);
            playButton.SetPosition(new Vector2(0, 0));
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
        }
        
        public override void Update(GameTime gameTime)
        {
            float currentTime = (float)gameTime.TotalGameTime.TotalSeconds;            
            if (fade.GetAlpha() > 0)
                fade.SetAlpha(1 - (float)currentTime*currentTime);
        }

        private void moveCursor(bool down)
        {
            buttons[cursorPosition].SetColor(Color.Black);
            int i = down ? 1 : -1;
            cursorPosition = ((cursorPosition + i) % 3);
            if (cursorPosition < 0) cursorPosition += 3;
            buttons[cursorPosition].SetColor(Color.Yellow);
        }

        private void enterHandler(int cursorPosition)
        {
            switch (cursorPosition)
            {
                case 0:
                    LittleNecromancy.Stack.Push(new ERDebugState(GetEntities()));
                    break;
                case 2:
                    LittleNecromancy.Exit = true;
                    break;
            }
        }
    }
}
