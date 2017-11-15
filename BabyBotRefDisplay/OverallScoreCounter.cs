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
    class OverallScoreCounter
    {

        private static Texture2D image;

        int redScore;
        int blueScore;

        static SpriteFont font;

        Vector2 position;

        public static void Load(ContentManager content)
        {
            image = content.Load<Texture2D>("overallscorecounter");
            font = content.Load<SpriteFont>("scorecounterfont");
        }

        public void Update(int ras, int rgs, int rss, int rys, int ros, int rrgbs, int res,
        int bas, int bgs, int bss, int bys, int bos, int brgbs, int bes)
        {
            redScore = 0;
            redScore += ras;
            redScore += rgs;
            redScore += 2 * rss;
            redScore += 4 * rys;
            redScore += 8 * ros;
            redScore += 16 * rrgbs;
            redScore += res;

            blueScore = 0;
            blueScore += bas;
            blueScore += bgs;
            blueScore += 2 * bss;
            blueScore += 4 * bys;
            blueScore += 8 * bos;
            blueScore += 16 * brgbs;
            blueScore += bes;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            position = new Vector2((3840 * 0.5f) - (image.Width * 0.5f),
                2160 - image.Height);
            spriteBatch.Draw(image, position, null, Color.White, 0,
                                Vector2.Zero,
                                1, SpriteEffects.None, 0);
        }

        public void DrawText(SpriteBatch spriteBatch)
        {
            Vector2 redScorePos = new Vector2((3840 * 0.5f)
                - (font.MeasureString(redScore.ToString()).X * 0.5f)
                - 475,
                2160 - 300
                - (font.MeasureString(redScore.ToString()).Y * 0.5f));
            spriteBatch.DrawString(font, redScore.ToString(), redScorePos, Color.White);

            Vector2 blueScorePos = new Vector2((3840 * 0.5f)
                - (font.MeasureString(blueScore.ToString()).X * 0.5f)
                + 475,
                2160 - 300
                - (font.MeasureString(blueScore.ToString()).Y * 0.5f));
            spriteBatch.DrawString(font, blueScore.ToString(), blueScorePos, Color.White);

        }
    }
}
