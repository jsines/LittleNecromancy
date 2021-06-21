using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleNecromancy
{
    class AnimationComponent
    {
        int sizex, sizey, frames, timeBetween;
        float timer = 0;
        int currentFrame = 0;
        Rectangle[] sourceRecs;

        public AnimationComponent(int sizex, int sizey, int frames, int timeBetween)
        {
            this.sizex = sizex;
            this.sizey = sizey;
            this.frames = frames;
            this.timeBetween = timeBetween;
            sourceRecs = new Rectangle[frames];
            for(int i = 0; i<frames; i++)
            {
                sourceRecs[i] = new Rectangle(0, sizey * i, sizex, sizey);
            }
        }

        public void Update(GameTime gameTime)
        {
            if(timer > timeBetween)
            {
                currentFrame++;
                if (currentFrame == frames)
                    currentFrame = 0;
                timer = 0;
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
        public Rectangle GetFrameRec()
        {
            return sourceRecs[currentFrame];
        }
    }
}
