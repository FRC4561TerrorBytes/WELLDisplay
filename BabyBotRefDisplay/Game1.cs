using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace BabyBotRefDisplay
{
    // 1543 lines
    // 37 assets

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        // Limit: ~11 chars each    
        String titleTextTop = "BABYBLOX";
        String titleTextBottom = "WELL 2017";

        // OR

        // Limit: 5 chars
        String titleTextBig = "";

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Timer timer;
        Texture2D shadowMap;
        RenderTarget2D renderTarget;
        KeyboardState keyboardState;
        OverallScoreCounter scoreCounter;
        SpriteFont titleFont;
        SpriteFont bigTitleFont;
        SoundEffects soundEffects;
        Texture2D bgClouds;

        RedGreenBlock rgblock;
        RedSilverBlock rsblock;
        RedYellowBlock ryblock;
        RedOrangeBlock roblock;
        RedRGBBlock rrgbblock;
        RedEndgame rendgame;
        RedAuto rauto;

        BlueGreenBlock bgblock;
        BlueSilverBlock bsblock;
        BlueYellowBlock byblock;
        BlueOrangeBlock boblock;
        BlueRGBBlock brgbblock;
        BlueEndgame bendgame;
        BlueAuto bauto;

        bool qWasDown = false;
        bool aWasDown = false;
        bool zWasDown = false;
        bool wWasDown = false;
        bool sWasDown = false;
        bool eWasDown = false;
        bool dWasDown = false;
        bool yWasDown = false;
        bool hWasDown = false;
        bool nWasDown = false;
        bool uWasDown = false;
        bool jWasDown = false;
        bool iWasDown = false;
        bool kWasDown = false;
        bool tWasDown = false;
        bool rWasDown = false;
        bool vWasDown = false;
        bool bWasDown = false;
        bool fWasDown = false;
        bool lWasDown = false;

        bool controlIsDown = false;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            timer = new Timer();
            scoreCounter = new OverallScoreCounter();
            renderTarget = new RenderTarget2D(this.GraphicsDevice, 3840, 2160);
            soundEffects = new SoundEffects();
            rgblock = new RedGreenBlock();
            rsblock = new RedSilverBlock();
            ryblock = new RedYellowBlock();
            roblock = new RedOrangeBlock();
            rrgbblock = new RedRGBBlock();
            rendgame = new RedEndgame();
            rauto = new RedAuto();
            bgblock = new BlueGreenBlock();
            bsblock = new BlueSilverBlock();
            byblock = new BlueYellowBlock();
            boblock = new BlueOrangeBlock();
            brgbblock = new BlueRGBBlock();
            bendgame = new BlueEndgame();
            bauto = new BlueAuto();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Timer.Load(Content);
            OverallScoreCounter.Load(Content);
            SoundEffects.Load(Content);
            SubScoreCounter.Load(Content);
            RedGreenBlock.Load(Content);
            RedSilverBlock.Load(Content);
            RedYellowBlock.Load(Content);
            RedOrangeBlock.Load(Content);
            RedRGBBlock.Load(Content);
            RedAuto.Load(Content);
            RedEndgame.Load(Content);
            BlueGreenBlock.Load(Content);
            BlueSilverBlock.Load(Content);
            BlueYellowBlock.Load(Content);
            BlueOrangeBlock.Load(Content);
            BlueRGBBlock.Load(Content);
            BlueAuto.Load(Content);
            BlueEndgame.Load(Content);
            titleFont = Content.Load<SpriteFont>("titlefont");
            bigTitleFont = Content.Load<SpriteFont>("titlefontsuper");
            bgClouds = Content.Load<Texture2D>("clouds");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            keyboardState = Keyboard.GetState();
            if ((keyboardState.IsKeyDown(Keys.R) && keyboardState.IsKeyDown(Keys.T)) && (!rWasDown || !tWasDown))
            {
                rgblock.Reset();
                rsblock.Reset();
                ryblock.Reset();
                roblock.Reset();
                rrgbblock.Reset();
                rauto.Reset();
                rendgame.Reset();
                bgblock.Reset();
                bsblock.Reset();
                byblock.Reset();
                boblock.Reset();
                brgbblock.Reset();
                bauto.Reset();
                bendgame.Reset();
                timer.ResetClean();
                timer.StartMatch(gameTime);
            }
            if (keyboardState.IsKeyUp(Keys.R))
            {
                rWasDown = false;
            } else
            {
                rWasDown = true;
            }

            if (keyboardState.IsKeyUp(Keys.T))
            {
                tWasDown = false;
            }
            else
            {
                tWasDown = true;
            }
            if ((keyboardState.IsKeyDown(Keys.V) && keyboardState.IsKeyDown(Keys.B)) && (!vWasDown || !bWasDown))
            {
                rgblock.Reset();
                rsblock.Reset();
                ryblock.Reset();
                roblock.Reset();
                rrgbblock.Reset();
                rauto.Reset();
                rendgame.Reset();
                bgblock.Reset();
                bsblock.Reset();
                byblock.Reset();
                boblock.Reset();
                brgbblock.Reset();
                bauto.Reset();
                bendgame.Reset();
                timer.Reset(soundEffects);
            }
            if (keyboardState.IsKeyDown(Keys.V))
            {
                vWasDown = true;
            } else
            {
                vWasDown = false;
            }

            if (keyboardState.IsKeyDown(Keys.B))
            {
                bWasDown = true;
            }
            else
            {
                bWasDown = false;
            }

            if (keyboardState.IsKeyDown(Keys.Q) && !qWasDown && keyboardState.IsKeyUp(Keys.LeftShift))
            {
                qWasDown = true;
                rgblock.Increment();
            }
            if (keyboardState.IsKeyDown(Keys.A) && !aWasDown && keyboardState.IsKeyUp(Keys.LeftShift))
            {
                aWasDown = true;
                rsblock.Increment();
            }
            if (keyboardState.IsKeyDown(Keys.Z) && !zWasDown && keyboardState.IsKeyUp(Keys.LeftShift))
            {
                zWasDown = true;
                ryblock.Increment();
            }
            if (keyboardState.IsKeyDown(Keys.W) && !wWasDown && keyboardState.IsKeyUp(Keys.LeftShift))
            {
                wWasDown = true;
                roblock.Increment();
            }
            if (keyboardState.IsKeyDown(Keys.S) && !sWasDown && keyboardState.IsKeyUp(Keys.LeftShift))
            {
                sWasDown = true;
                rrgbblock.Increment();
            }
            if (keyboardState.IsKeyDown(Keys.E) && !eWasDown && keyboardState.IsKeyUp(Keys.LeftShift))
            {
                eWasDown = true;
                rauto.Increment();
            }
            if (keyboardState.IsKeyDown(Keys.F) && !fWasDown && keyboardState.IsKeyUp(Keys.LeftShift))
            {
                fWasDown = true;
                rauto.SmallIncrement();
            }
            if (keyboardState.IsKeyDown(Keys.D) && !dWasDown && keyboardState.IsKeyUp(Keys.LeftShift))
            {
                dWasDown = true;
                rendgame.Increment();
            }

            if (keyboardState.IsKeyDown(Keys.Q) && !qWasDown && keyboardState.IsKeyDown(Keys.LeftShift))
            {
                qWasDown = true;
                rgblock.Deincrement();
            }
            if (keyboardState.IsKeyDown(Keys.A) && !aWasDown && keyboardState.IsKeyDown(Keys.LeftShift))
            {
                aWasDown = true;
                rsblock.Deincrement();
            }
            if (keyboardState.IsKeyDown(Keys.Z) && !zWasDown && keyboardState.IsKeyDown(Keys.LeftShift))
            {
                zWasDown = true;
                ryblock.Deincrement();
            }
            if (keyboardState.IsKeyDown(Keys.W) && !wWasDown && keyboardState.IsKeyDown(Keys.LeftShift))
            {
                wWasDown = true;
                roblock.Deincrement();
            }
            if (keyboardState.IsKeyDown(Keys.S) && !sWasDown && keyboardState.IsKeyDown(Keys.LeftShift))
            {
                sWasDown = true;
                rrgbblock.Deincrement();
            }
            if (keyboardState.IsKeyDown(Keys.E) && !eWasDown && keyboardState.IsKeyDown(Keys.LeftShift))
            {
                eWasDown = true;
                rauto.Deincrement();
            }
            if (keyboardState.IsKeyDown(Keys.F) && !fWasDown && keyboardState.IsKeyDown(Keys.LeftShift))
            {
                fWasDown = true;
                rauto.SmallDeincrement();
            }
            if (keyboardState.IsKeyDown(Keys.D) && !dWasDown && keyboardState.IsKeyDown(Keys.LeftShift))
            {
                dWasDown = true;
                rendgame.Deincrement();
            }


            if (keyboardState.IsKeyUp(Keys.Q))
            {
                qWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.A))
            {
                aWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.Z))
            {
                zWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.W))
            {
                wWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.S))
            {
                sWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.E))
            {
                eWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.F))
            {
                fWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.D))
            {
                dWasDown = false;
            }


            if (keyboardState.IsKeyDown(Keys.Y) && !yWasDown && keyboardState.IsKeyUp(Keys.RightShift))
            {
                yWasDown = true;
                bgblock.Increment();
            }
            if (keyboardState.IsKeyDown(Keys.H) && !hWasDown && keyboardState.IsKeyUp(Keys.RightShift))
            {
                hWasDown = true;
                bsblock.Increment();
            }
            if (keyboardState.IsKeyDown(Keys.N) && !nWasDown && keyboardState.IsKeyUp(Keys.RightShift))
            {
                nWasDown = true;
                byblock.Increment();
            }
            if (keyboardState.IsKeyDown(Keys.U) && !uWasDown && keyboardState.IsKeyUp(Keys.RightShift))
            {
                uWasDown = true;
                boblock.Increment();
            }
            if (keyboardState.IsKeyDown(Keys.J) && !jWasDown && keyboardState.IsKeyUp(Keys.RightShift))
            {
                jWasDown = true;
                brgbblock.Increment();
            }
            if (keyboardState.IsKeyDown(Keys.I) && !iWasDown && keyboardState.IsKeyUp(Keys.RightShift))
            {
                iWasDown = true;
                bauto.Increment();
            }
            if (keyboardState.IsKeyDown(Keys.L) && !lWasDown && keyboardState.IsKeyUp(Keys.RightShift))
            {
                lWasDown = true;
                bauto.SmallIncrement();
            }
            if (keyboardState.IsKeyDown(Keys.K) && !kWasDown && keyboardState.IsKeyUp(Keys.RightShift))
            {
                kWasDown = true;
                bendgame.Increment();
            }

            if (keyboardState.IsKeyDown(Keys.Y) && !yWasDown && keyboardState.IsKeyDown(Keys.RightShift))
            {
                yWasDown = true;
                bgblock.Deincrement();
            }
            if (keyboardState.IsKeyDown(Keys.H) && !hWasDown && keyboardState.IsKeyDown(Keys.RightShift))
            {
                hWasDown = true;
                bsblock.Deincrement();
            }
            if (keyboardState.IsKeyDown(Keys.N) && !nWasDown && keyboardState.IsKeyDown(Keys.RightShift))
            {
                nWasDown = true;
                byblock.Deincrement();
            }
            if (keyboardState.IsKeyDown(Keys.U) && !uWasDown && keyboardState.IsKeyDown(Keys.RightShift))
            {
                uWasDown = true;
                boblock.Deincrement();
            }
            if (keyboardState.IsKeyDown(Keys.J) && !jWasDown && keyboardState.IsKeyDown(Keys.RightShift))
            {
                jWasDown = true;
                brgbblock.Deincrement();
            }
            if (keyboardState.IsKeyDown(Keys.I) && !iWasDown && keyboardState.IsKeyDown(Keys.RightShift))
            {
                iWasDown = true;
                bauto.Deincrement();
            }
            if (keyboardState.IsKeyDown(Keys.L) && !lWasDown && keyboardState.IsKeyDown(Keys.RightShift))
            {
                lWasDown = true;
                bauto.SmallDeincrement();
            }
            if (keyboardState.IsKeyDown(Keys.K) && !kWasDown && keyboardState.IsKeyDown(Keys.RightShift))
            {
                kWasDown = true;
                bendgame.Deincrement();
            }


            if (keyboardState.IsKeyUp(Keys.Y))
            {
                yWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.H))
            {
                hWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.N))
            {
                nWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.U))
            {
                uWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.J))
            {
                jWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.I))
            {
                iWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.L))
            {
                lWasDown = false;
            }
            if (keyboardState.IsKeyUp(Keys.K))
            {
                kWasDown = false;
            }


            if (keyboardState.IsKeyDown(Keys.LeftControl) || keyboardState.IsKeyDown(Keys.RightControl))
            {
                controlIsDown = true;
            } else
            {
                controlIsDown = false;
            }
            timer.Update(gameTime, soundEffects);
            rgblock.Update(gameTime);
            rsblock.Update(gameTime);
            ryblock.Update(gameTime);
            roblock.Update(gameTime);
            rrgbblock.Update(gameTime);
            rauto.Update(gameTime);
            rendgame.Update(gameTime);
            bgblock.Update(gameTime);
            bsblock.Update(gameTime);
            byblock.Update(gameTime);
            boblock.Update(gameTime);
            brgbblock.Update(gameTime);
            bauto.Update(gameTime);
            bendgame.Update(gameTime);
            scoreCounter.Update(rauto.Score, rgblock.Score, rsblock.Score, ryblock.Score, roblock.Score,
                rrgbblock.Score, rendgame.Score, bauto.Score, bgblock.Score, bsblock.Score, byblock.Score,
                boblock.Score, brgbblock.Score, bendgame.Score);
            soundEffects.Play();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(new Color(0, 170, 255));
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            int cloudScroll = (int)(gameTime.TotalGameTime.TotalMilliseconds * 0.1f);
            spriteBatch.Draw(bgClouds, Vector2.Zero, new Rectangle(-cloudScroll, 0, bgClouds.Width, bgClouds.Height), Color.White);
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);
            timer.Draw(spriteBatch);
            rgblock.Draw(spriteBatch);
            rsblock.Draw(spriteBatch);
            ryblock.Draw(spriteBatch);
            roblock.Draw(spriteBatch);
            rrgbblock.Draw(spriteBatch);
            rauto.Draw(spriteBatch);
            rendgame.Draw(spriteBatch);
            rgblock.DrawText(spriteBatch);
            rsblock.DrawText(spriteBatch);
            ryblock.DrawText(spriteBatch);
            roblock.DrawText(spriteBatch);
            rrgbblock.DrawText(spriteBatch);
            rauto.DrawText(spriteBatch);
            rendgame.DrawText(spriteBatch);
            bgblock.Draw(spriteBatch);
            bsblock.Draw(spriteBatch);
            byblock.Draw(spriteBatch);
            boblock.Draw(spriteBatch);
            brgbblock.Draw(spriteBatch);
            bauto.Draw(spriteBatch);
            bendgame.Draw(spriteBatch);
            bgblock.DrawText(spriteBatch);
            bsblock.DrawText(spriteBatch);
            byblock.DrawText(spriteBatch);
            boblock.DrawText(spriteBatch);
            brgbblock.DrawText(spriteBatch);
            bauto.DrawText(spriteBatch);
            bendgame.DrawText(spriteBatch);
            if (controlIsDown)
            {
                rgblock.DrawRedControl(spriteBatch);
                rsblock.DrawRedControl(spriteBatch);
                ryblock.DrawRedControl(spriteBatch);
                roblock.DrawRedControl(spriteBatch);
                rrgbblock.DrawRedControl(spriteBatch);
                rauto.DrawRedControl(spriteBatch);
                rendgame.DrawRedControl(spriteBatch);
                bgblock.DrawBlueControl(spriteBatch);
                bsblock.DrawBlueControl(spriteBatch);
                byblock.DrawBlueControl(spriteBatch);
                boblock.DrawBlueControl(spriteBatch);
                brgbblock.DrawBlueControl(spriteBatch);
                bauto.DrawBlueControl(spriteBatch);
                bendgame.DrawBlueControl(spriteBatch);
                rgblock.DrawTimerControl(spriteBatch);
            }
            scoreCounter.Draw(spriteBatch);
            scoreCounter.DrawText(spriteBatch);
            if(titleTextTop != "" || titleTextBottom != "")
            {
                DrawTitleTextSmall(titleTextTop, titleTextBottom);
            }
            else if(titleTextBig != "")
            {
                DrawTitleTextBig(titleTextBig);
            }
            shadowMap = (Texture2D)renderTarget;
            spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);
            shadowMap = (Texture2D)renderTarget;
            spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null, null);
            GraphicsDevice.Clear(Color.Green);
            if (GraphicsDevice.Adapter.CurrentDisplayMode.AspectRatio > 3840 / 2160)
            {
                spriteBatch.Draw(shadowMap, Vector2.Zero, null, Color.White, 0,
                    Vector2.Zero,
                    new Vector2(0.21f, 0.227f), SpriteEffects.None, 1);
            }
            else
            {
                spriteBatch.Draw(shadowMap, Vector2.Zero, null, Color.White, 0,
                    Vector2.Zero,
                    (float)GraphicsDevice.Adapter.CurrentDisplayMode.Width / 3840f, SpriteEffects.None, 1);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void DrawTitleTextSmall(String top, String bottom)
        {
            Vector2 textPosTop = new Vector2((3840 * 0.5f)
                - (titleFont.MeasureString(top).X * 0.5f),
                200
                - (titleFont.MeasureString(top).Y * 0.5f));
            spriteBatch.DrawString(titleFont, top, textPosTop, Color.Black);
            Vector2 textPosBot = new Vector2((3840 * 0.5f)
                - (titleFont.MeasureString(bottom).X * 0.5f),
                400
                - (titleFont.MeasureString(bottom).Y * 0.5f));
            spriteBatch.DrawString(titleFont, bottom, textPosBot, Color.Black);
        }

        public void DrawTitleTextBig(String text)
        {
            Vector2 textPos = new Vector2((3840 * 0.5f)
                - (bigTitleFont.MeasureString(text).X * 0.5f),
                300
                - (bigTitleFont.MeasureString(text).Y * 0.5f));
            spriteBatch.DrawString(bigTitleFont, text, textPos, Color.Black);
        }


    }
}

