﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GP_Midterm_BubblePuzzle.Screen {
	class MenuScreen :_GameScreen {
		private Color _Color;
		private Texture2D BG, Black;

		private bool fadeFinish;

		private float _timer, timerPerUpdate;
		private int alpha;

		public MenuScreen() {
			alpha = 255;
			timerPerUpdate = 0.03f;
			fadeFinish = false;
			_Color = new Color(250,250,250,alpha);
		}
		public override void LoadContent() {
			base.LoadContent();
			BG = content.Load<Texture2D>("MenuScreen/BG");
			Black = content.Load<Texture2D>("SplashScreen/Black");
		}
		public override void UnloadContent() {
			base.UnloadContent();
		}
		public override void Update(GameTime gameTime) {
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
			// Menu click


			base.Update(gameTime);
		}
		public override void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(BG, Vector2.Zero, Color.White);



			if (!fadeFinish) {
				spriteBatch.Draw(Black, Vector2.Zero, _Color);
			}
		}
	}
}
