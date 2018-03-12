﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GP_Midterm_BubblePuzzle.Managers;
using System;
using Microsoft.Xna.Framework.Audio;

namespace GP_Midterm_BubblePuzzle.Screen {
	class MenuScreen : _GameScreen {
		private Color _Color = new Color(250, 250, 250, 0);
		private Texture2D BG, Black;
		private Texture2D StartH, AboutH, OptionH, RankingH, ExitH, checkBoxYes, checkBoxNo, apply, back, Arrow;
		private SpriteFont Arcanista, KM;
		private Vector2 fontSize;

		private SoundEffectInstance SoundClickUI, SoundEnterGameGame, SoundSelectUI;

		private bool fadeFinish = false;
		private bool showOption = false, showRanking = false, showAbout = false;
		private bool mhStart = false, mhOption = false, mhAbout = false, mhRanking = false, mhExit = false, mhBack = false, mhApply;
		private bool mainScreen = true;

		private float _timer = 0.0f;
		private float timerPerUpdate = 0.03f;
		private int alpha = 255;

		// Varible On Option Screen
		private bool FullScreen = Singleton.Instance.IsFullScreen;
		private bool ShowFPS = Singleton.Instance.cmdShowFPS;
		private int MasterBGM = Singleton.Instance.BGM_MasterVolume;
		private int MasterSFX = Convert.ToInt32(Singleton.Instance.SFX_MasterVolume * 100);

		public void Initial() {

		}
		public override void LoadContent() {
			base.LoadContent();
			BG = content.Load<Texture2D>("MenuScreen/BG");
			Black = content.Load<Texture2D>("SplashScreen/Black");
			StartH = content.Load<Texture2D>("MenuScreen/start");
			AboutH = content.Load<Texture2D>("MenuScreen/about");
			OptionH = content.Load<Texture2D>("MenuScreen/option");
			RankingH = content.Load<Texture2D>("MenuScreen/ranking");
			ExitH = content.Load<Texture2D>("MenuScreen/exit");
			checkBoxYes = content.Load<Texture2D>("MenuScreen/checkBox-yes");
			checkBoxNo = content.Load<Texture2D>("MenuScreen/checkBox-no");
			apply = content.Load<Texture2D>("MenuScreen/apply");
			back = content.Load<Texture2D>("MenuScreen/back");
			Arrow = content.Load<Texture2D>("MenuScreen/Arrow");
			Arcanista = content.Load<SpriteFont>("Fonts/Arcanista");
			KM = content.Load<SpriteFont>("Fonts/KH-Metropolis");
			SoundClickUI = content.Load<SoundEffect>("Audios/UI_SoundPack8_Error_v1").CreateInstance();
			SoundEnterGameGame = content.Load<SoundEffect>("Audios/transition t07 two-step 007").CreateInstance();
			SoundSelectUI = content.Load<SoundEffect>("Audios/UI_SoundPack11_Select_v14").CreateInstance();
			Initial();
		}
		public override void UnloadContent() {
			base.UnloadContent();
		}
		public override void Update(GameTime gameTime) {
			Singleton.Instance.MousePrevious = Singleton.Instance.MouseCurrent;
			Singleton.Instance.MouseCurrent = Mouse.GetState();
			if (mainScreen) {
				// Click start game
				if ((Singleton.Instance.MouseCurrent.X > 517 && Singleton.Instance.MouseCurrent.Y > 166) && (Singleton.Instance.MouseCurrent.X < 780 && Singleton.Instance.MouseCurrent.Y < 514)) {
					mhStart = true;
					if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
						ScreenManager.Instance.LoadScreen(ScreenManager.GameScreenName.PalyScreen);
					}
				} else {
					mhStart = false;
				}
				// Click option
				if ((Singleton.Instance.MouseCurrent.X > 93 && Singleton.Instance.MouseCurrent.Y > 161) && (Singleton.Instance.MouseCurrent.X < 256 && Singleton.Instance.MouseCurrent.Y < 674)) {
					mhOption = true;
					if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
						showOption = true;
						mainScreen = false;
					}
				} else {
					mhOption = false;
				}
				// Click About
				if ((Singleton.Instance.MouseCurrent.X > 1044 && Singleton.Instance.MouseCurrent.Y > 178) && (Singleton.Instance.MouseCurrent.X < 1218 && Singleton.Instance.MouseCurrent.Y < 694)) {
					mhAbout = true;
					if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
						showAbout = true;
						mainScreen = false;
					}
				} else {
					mhAbout = false;
				}
				// Click Ranking
				if ((Singleton.Instance.MouseCurrent.X > 978 && Singleton.Instance.MouseCurrent.Y > 30) && (Singleton.Instance.MouseCurrent.X < 1200 && Singleton.Instance.MouseCurrent.Y < 160)) {
					mhRanking = true;
					if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
						showRanking = true;
						mainScreen = false;
					}
				} else {
					mhRanking = false;
				}
				// Click Exit
				if ((Singleton.Instance.MouseCurrent.X > 420 && Singleton.Instance.MouseCurrent.Y > 580) && (Singleton.Instance.MouseCurrent.X < 831 && Singleton.Instance.MouseCurrent.Y < 692)) {
					mhExit = true;
					if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
						Singleton.Instance.cmdExit = true;
					}
				} else {
					mhExit = false;
				}
			} else {
				// Click Back
				if ((Singleton.Instance.MouseCurrent.X > (1230 - back.Width) && Singleton.Instance.MouseCurrent.Y > 50) && (Singleton.Instance.MouseCurrent.X < 1230 && Singleton.Instance.MouseCurrent.Y < (50 + back.Height))) {
					mhBack = true;
					if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
						mainScreen = true;
						showAbout = false;
						showOption = false;
						showRanking = false;
					}
				} else {
					mhBack = false;
				}
				if (showOption) {
					// Click change CheckBox FullScreen
					if ((Singleton.Instance.MouseCurrent.X > 800 && Singleton.Instance.MouseCurrent.Y > 425) && (Singleton.Instance.MouseCurrent.X < (800 + checkBoxNo.Width) && Singleton.Instance.MouseCurrent.Y < (425 + checkBoxNo.Height))) {
						if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
							FullScreen = !FullScreen;
						}
					}
					// Click change CheckBox ShowFPS
					if ((Singleton.Instance.MouseCurrent.X > 800 && Singleton.Instance.MouseCurrent.Y > 500) && (Singleton.Instance.MouseCurrent.X < (800 + checkBoxNo.Width) && Singleton.Instance.MouseCurrent.Y < (500 + checkBoxNo.Height))) {
						if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
							ShowFPS = !ShowFPS;
						}
					}

					// Click Arrow BGM
					if ((Singleton.Instance.MouseCurrent.X > 700 && Singleton.Instance.MouseCurrent.Y > 240) && (Singleton.Instance.MouseCurrent.X < (700 + Arrow.Width) && Singleton.Instance.MouseCurrent.Y < (240 + Arrow.Height))) {
						if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
							if (MasterBGM > 0) MasterBGM -= 5;
						}
					} else if ((Singleton.Instance.MouseCurrent.X > 900 && Singleton.Instance.MouseCurrent.Y > 240) && (Singleton.Instance.MouseCurrent.X < (900 + Arrow.Width) && Singleton.Instance.MouseCurrent.Y < (240 + Arrow.Height))) {
						if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
							if (MasterBGM < 100) MasterBGM += 5;
						}
					}
					// Click Arrow SFX
					if ((Singleton.Instance.MouseCurrent.X > 700 && Singleton.Instance.MouseCurrent.Y > 315) && (Singleton.Instance.MouseCurrent.X < (700 + Arrow.Width) && Singleton.Instance.MouseCurrent.Y < (315 + Arrow.Height))) {
						if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
							if (MasterSFX > 0) MasterSFX -= 5;
						}
					} else if ((Singleton.Instance.MouseCurrent.X > 900 && Singleton.Instance.MouseCurrent.Y > 315) && (Singleton.Instance.MouseCurrent.X < (900 + Arrow.Width) && Singleton.Instance.MouseCurrent.Y < (315 + Arrow.Height))) {
						if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
							if (MasterSFX < 100) MasterSFX += 5;
						}
					}
					// Apply Option to Game
					if ((Singleton.Instance.MouseCurrent.X > (1100 - apply.Width) && Singleton.Instance.MouseCurrent.Y > 625) && (Singleton.Instance.MouseCurrent.X < 1100 && Singleton.Instance.MouseCurrent.Y < (625 + back.Height))) {
						mhApply = true;
						if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
							if (Singleton.Instance.IsFullScreen != FullScreen) Singleton.Instance.cmdFullScreen = true;
							Singleton.Instance.cmdShowFPS = ShowFPS;
							Singleton.Instance.BGM_MasterVolume = MasterBGM;
							Singleton.Instance.SFX_MasterVolume = MasterSFX / 100f;
						}
					} else {
						mhApply = false;
					}
				}
				if (showAbout) {

				}
				if (showRanking) {

				}
			}

			// fade out
			if (!fadeFinish) {
				_timer += (float)gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
				if (_timer >= timerPerUpdate) {
					alpha -= 5;
					_timer -= timerPerUpdate;
					if (alpha <= 5) {
						fadeFinish = true;
					}
					_Color.A = (byte)alpha;
				}
			}
			base.Update(gameTime);
		}
		public override void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(BG, Vector2.Zero, Color.White);
			// Draw mouse onHover button
			if (mhAbout) {
				spriteBatch.Draw(AboutH, new Vector2(1047, 366), Color.White);
			}
			if (mhExit) {
				spriteBatch.Draw(ExitH, new Vector2(475, 574), Color.White);
			}
			if (mhOption) {
				spriteBatch.Draw(OptionH, new Vector2(98, 362), Color.White);
			}
			if (mhRanking) {
				spriteBatch.Draw(RankingH, new Vector2(986, 57), Color.White);
			}
			if (mhStart) {
				spriteBatch.Draw(StartH, new Vector2(551, 332), Color.White);
			}
			// Draw UI when is NOT MainMenu
			if (!mainScreen) {
				spriteBatch.Draw(Black, Vector2.Zero, new Color(255, 255, 255, 210));
				if (mhBack) {
					spriteBatch.Draw(back, new Vector2(1230 - back.Width, 50), Color.OrangeRed);
				} else {
					spriteBatch.Draw(back, new Vector2(1230 - back.Width, 50), Color.White);
				}
				// Draw Option Screen
				if (showOption) {
					fontSize = KM.MeasureString("Option");
					spriteBatch.DrawString(KM, "Option", new Vector2(Singleton.Instance.Diemensions.X / 2 - fontSize.X / 2, 125), Color.White);

					spriteBatch.DrawString(Arcanista, "BGM Volume", new Vector2(300, 250), Color.White);
					spriteBatch.Draw(Arrow, new Vector2(700, 240), null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
					spriteBatch.DrawString(Arcanista, MasterBGM.ToString(), new Vector2(800, 250), Color.White);
					spriteBatch.Draw(Arrow, new Vector2(900, 240), Color.White);

					spriteBatch.DrawString(Arcanista, "SFX Volume", new Vector2(300, 325), Color.White);
					spriteBatch.Draw(Arrow, new Vector2(700, 315), null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
					spriteBatch.DrawString(Arcanista, MasterSFX.ToString(), new Vector2(800, 325), Color.White);
					spriteBatch.Draw(Arrow, new Vector2(900, 315), Color.White);

					spriteBatch.DrawString(Arcanista, "Full Screen", new Vector2(300, 425), Color.White);
					if (!FullScreen) {
						spriteBatch.Draw(checkBoxNo, new Vector2(800, 425), Color.White);
					} else {
						spriteBatch.Draw(checkBoxYes, new Vector2(800, 425), Color.White);
					}

					spriteBatch.DrawString(Arcanista, "Show FPS", new Vector2(300, 500), Color.White);
					if (!ShowFPS) {
						spriteBatch.Draw(checkBoxNo, new Vector2(800, 500), Color.White);
					} else {
						spriteBatch.Draw(checkBoxYes, new Vector2(800, 500), Color.White);
					}

					if (mhApply) {
						spriteBatch.Draw(apply, new Vector2(1100 - back.Width, 625), Color.OrangeRed);
					} else {
						spriteBatch.Draw(apply, new Vector2(1100 - back.Width, 625), Color.White);
					}
				}
				// Draw About Screen
				if (showAbout) {

				}
				// Draw Leader board Screen
				if (showRanking) {

				}

			}
			

			// Draw fade out
			if (!fadeFinish) {
				spriteBatch.Draw(Black, Vector2.Zero, _Color);
			}
		}
	}
}
