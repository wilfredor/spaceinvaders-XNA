﻿#region Using Statements

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Particles;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System;

#endregion

namespace SpaceInvaders
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class SpaceInvaders : Game
	{

        GraphicsDeviceManager graphics;

		int enemySize = 100;
		private static bool gameOver;
		public Nave nave;   

        private Random rnd;

        public int level;
        public int score;
        public SpaceInvaders()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = Constant.rootContentDirectory;	            
			graphics.IsFullScreen = false;

            // Create new renderer and set its graphics devide to "this" device                     
        }

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here
			// Nave image.
			gameOver = false;
            //level map
            Components.Add(new Map(this));
            level = 1;
            score = 0;

            //Add a enemie 
            Components.Add (new Enemie (this, 10, 10));

            //Add ship
			Components.Add (new Nave(this));

            //Label info 
			Components.Add (new Display(this));

            

            base.Initialize ();

            rnd = new Random();

        }

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch (GraphicsDevice);

            //TODO: use this.Content to load your game content here 

        }

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS

            //Next Level
            if (Components.OfType<Enemie>().Count().Equals(0))
            {
                level++;
                for (int i = 0; i <= level; i++)
                {
                    Components.Add(new Enemie(this, rnd.Next(1, 600), rnd.Next(1, 300)));
                }
            }

            Components.OfType<BulletPackage>().ToList().RemoveAll(x => x.Delete);
            Components.OfType<LivePackage>().ToList().RemoveAll(x => x.Delete);

            //win bullets
            if ((Components.OfType<Nave>().Count() > 0) && (Components.OfType<BulletPackage>().Count()==0))
            {
                nave = Components.OfType<Nave>().First();

                if (nave.numShotsFromCurrentMagazine==0)
                {
                    Components.Add(new BulletPackage(this, rnd.Next(50, 600), rnd.Next(50, 300)));
                }
            }


            //win a live
            if ((Components.OfType<Nave>().Count() > 0) && (Components.OfType<LivePackage>().Count() == 0))
            {
                nave = Components.OfType<Nave>().First();

                if (nave.lives == 1)
                {
                    Components.Add(new LivePackage(this, rnd.Next(200, 600), rnd.Next(200, 300)));
                }
            }

            //gameover
            if (Components.OfType<Nave>().Count() == 0)
            {
                Components.Add(new GameOver(this));
            }

            #if !__IOS__
            if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState ().IsKeyDown (Keys.Escape)) {
				Exit ();
			}
			#endif

			//this.nave.Move (aCurrentKeyboardState);
			//this.bullet.CheckFired (gameTime, aCurrentKeyboardState);
			//this.bullet.Move (this);
			/*
			if (aCurrentKeyboardState.IsKeyDown (Keys.LeftControl)) {
				Bullet bullet = new Bullet (nave.position,graphics);
				bullet.fired = true;

			}
			*/

			// TODO: Add your update logic here			
			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{

			graphics.GraphicsDevice.Clear (Color.Black);

			//this.nave.Draw (spriteBatch);
			//this.bullet.Draw (spriteBatch);
		
			//TODO: Add your drawing code here
            
			base.Draw (gameTime);

		}
	}
}

