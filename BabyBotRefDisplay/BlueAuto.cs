using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace BabyBotRefDisplay
{
    class BlueAuto : SubScoreCounter
    {

        private static Texture2D image;
        

        public BlueAuto(): base(new Vector2(2900, 50))
        {
            control = "I";
        }

        public new void Increment()
        {
            Score += 5;
        }

        public void SmallIncrement()
        {
            Score += 2;
        }

        public new void Deincrement()
        {
            Score -= 5;
        }

        public void SmallDeincrement()
        {
            Score -= 2;
        }

        public static new void Load(ContentManager content)
        {
            image = content.Load<Texture2D>("blueblockscorecardauto");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, null, Color.White, 0,
                                Vector2.Zero,
                                1, SpriteEffects.None, 0);
        }

    }
}
