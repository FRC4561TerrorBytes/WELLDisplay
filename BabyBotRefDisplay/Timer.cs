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
    class Timer
    {
        private static Texture2D image;
        private Vector2 position;
        private float timeMatchStarted;
        private bool inMatch = false;
        public bool InMatch
        {
            get { return inMatch; }
        }
        bool auto = false;
        bool teleop = false;
        bool endgame = false;
        static SpriteFont coolFont;
        String timeStr = "0:00";
        GameTime gameTime;

        public static void Load(ContentManager content)
        {
            coolFont = content.Load<SpriteFont>("anothercoolfont");
            image = content.Load<Texture2D>("CountdownBackground");
        }

        public void Update(GameTime gameTime, SoundEffects soundEffects)
        {
            this.gameTime = gameTime;
            if(inMatch)
            {
                // currently in true seconds since match start counting up
                float secondsToDisplay = (float)gameTime.TotalGameTime.TotalSeconds - timeMatchStarted;
                if(secondsToDisplay <= 15)
                {
                    if(!auto)
                    {
                        soundEffects.addToQueue("autoStart");
                    }
                    // auto
                    auto = true;
                    teleop = false;
                    endgame = false;
                    secondsToDisplay = 15 - secondsToDisplay;
                } else if(secondsToDisplay <= 130)
                {
                    if(!teleop)
                    {
                        soundEffects.addToQueue("teleopStart");
                    }
                    // teleop
                    auto = false;
                    teleop = true;
                    endgame = false;
                    secondsToDisplay -= 15;
                    secondsToDisplay = 135 - secondsToDisplay;
                } else if(secondsToDisplay <= 150)
                {
                    // endgame
                    if(!endgame)
                    {
                        soundEffects.addToQueue("endgameStart");
                    }
                    auto = false;
                    teleop = false;
                    endgame = true;
                    secondsToDisplay -= 15;
                    secondsToDisplay = 135 - secondsToDisplay;
                } else if(secondsToDisplay > 150)
                {
                    if(endgame)
                    {
                        soundEffects.addToQueue("matchEnd");
                    }
                    // match over
                    auto = false;
                    teleop = false;
                    endgame = false;
                    secondsToDisplay = 0;
                    inMatch = false;
                }
                timeStr = secondsToTime((int)secondsToDisplay);
            } else
            {
                timeStr = secondsToTime(0);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Vector2 origin = new Vector2(image.Width * 0.5f, image.Height * 0.5f);
            position = new Vector2((3840 * 0.5f) - (image.Width * 0.5f),
                (2160 * 0.5f) - (image.Height * 0.5f));
            spriteBatch.Draw(image, position, null, Color.White, 0,
                                Vector2.Zero,
                                1, SpriteEffects.None, 0);
            Vector2 timePos = new Vector2((3840 * 0.5f)
                - (coolFont.MeasureString(timeStr).X * 0.5f),
                (2160 * 0.5f)
                - (coolFont.MeasureString(timeStr).Y * 0.5f));
            if(!auto && !teleop && !endgame)
            {
                if(gameTime.TotalGameTime.TotalMilliseconds % 500 < 250)
                {
                    spriteBatch.DrawString(coolFont, timeStr, timePos, Color.Black);
                }
            } else {
                spriteBatch.DrawString(coolFont, timeStr, timePos, Color.Black);
            }
        }

        public void Reset(SoundEffects soundEffects)
        {
            inMatch = false;
            soundEffects.addToQueue("faultSound");
        }

        public void ResetClean()
        {
            inMatch = false;
            auto = false;
            teleop = false;
            endgame = false;
        }

        public void StartMatch(GameTime gameTime)
        {
            timeMatchStarted = (float)gameTime.TotalGameTime.TotalSeconds;
            inMatch = true;
        }

        private string secondsToTime(int seconds)
        {
            int minutes = seconds / 60;
            seconds -= minutes * 60;
            return minutes.ToString() + ":" + seconds.ToString().PadLeft(2, '0');
        }
    }


}
