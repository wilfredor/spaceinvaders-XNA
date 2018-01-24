﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;


namespace SpaceInvaders
{
    class Explosion : DrawableGameComponent
    {
        public Vector2 position = Vector2.Zero;
        Vector2 navePosition = Vector2.Zero;
        Vector2 velocity = Vector2.One;
        private Texture2D bullet;
        SpriteBatch spriteBatch;
        public Boolean delete;


        Texture2D rect; 

        Color[] data = new Color[80 * 30];

        Vector2 coor = new Vector2(10, 20);

        public Explosion(ref Game1 game, Vector2 positionNave) : base (game)
		{
            navePosition = positionNave;
            //should only ever be one player, all value defaults set in Initialize()
        }


        public override void Update(GameTime gameTime)
        {

            //this.delete = Collision.checkCollision(position, Game);


            //if (this.delete)
            //    Game.Components.Remove(this);

            //if (((position.Y >= -this.bullet.Height)))
            //    position.Y -= velocity.Y;
            //else
            //{


            //    this.delete = true;
            //    Game.Components.Remove(this);
            //    //this = null;
            //    //this.SetInitPosition (navePosition);

            //}
            base.Update(gameTime);
        }

        private void SetInitPosition(Vector2 newPosition)
        {
            position.Y = newPosition.Y;
            position.X = newPosition.X;
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }

        public override void Initialize()
        {
            base.Initialize();

            delete = false;
            //bullet = Game.Content.Load<Texture2D>("explosion");
           // velocity = new Vector2(10, 10);
            this.SetInitPosition(navePosition);

            rect = new Texture2D(Game.GraphicsDevice, 80, 30);
        }

        public override void Draw(GameTime gameTime)
        {

            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            rect.SetData(data);

            base.Draw(gameTime);
            spriteBatch.Begin();
            //spriteBatch.Draw(bullet, position, Color.White);
            spriteBatch.Draw(rect, position, Color.White);
            spriteBatch.End();
        }
    }
}