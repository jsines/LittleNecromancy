using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LittleNecromancy
{
    class AnimatedSprite : Entity
    {
        public AnimationComponent animation;
        public Texture2D spriteSheet;
        public Rectangle srcRec;
        int frameCount = 3;

        public AnimatedSprite(string spriteSheetFile, int frames, int msBetweenFrames)
        {
            spriteSheet = LittleNecromancy.Resource.GetTexture(spriteSheetFile);
            animation = new AnimationComponent(spriteSheet.Width, spriteSheet.Height / frames, frames, msBetweenFrames);
            srcRec = animation.GetFrameRec();
        }
        public virtual void Initialize()
        {
        }

        public override void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            srcRec = animation.GetFrameRec();
        }
    }
}
