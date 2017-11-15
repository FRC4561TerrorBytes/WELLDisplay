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
    class BlueGreenBlock : SubScoreCounter
    {
        private static Texture2D image;

        public BlueGreenBlock(): base(new Vector2(2900, 342))
        {
            control = "Y";
        }

        public static new void Load(ContentManager content)
        {
            image = content.Load<Texture2D>("blueblockscorecardgreen");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, null, Color.White, 0,
                                Vector2.Zero,
                                1, SpriteEffects.None, 0);
        }

    }
}
