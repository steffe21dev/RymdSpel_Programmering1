using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace RymdSpel
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, ship, fire, meteor;
        List<Bullet> bullets;
        List<Meteor> meteors;
        Player player;
        Random random;
        bool isShooting;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 768;

            player = new Player(new Vector2((1280 / 2), 700), new Rectangle((1280 / 2), 700, 64, 64),100);
            bullets = new List<Bullet>();
            meteors = new List<Meteor>();
            random = new Random();
            isShooting = false;

            Content.RootDirectory = "Content";
        }

     
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("background");
            ship = Content.Load<Texture2D>("player");
            fire = Content.Load<Texture2D>("fire");
            meteor = Content.Load<Texture2D>("meteor");



        }


        protected override void UnloadContent()
        {
        }


        private void Input_Listen()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                player.pos = new Vector2(player.pos.X + 10, player.pos.Y);
                player.UpdateRectangle();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                player.pos = new Vector2(player.pos.X - 10, player.pos.Y);
                player.UpdateRectangle();

            }


            if (Keyboard.GetState().IsKeyDown(Keys.Space) && isShooting == false)
            {
                bullets.Add(new Bullet(player.pos, new Rectangle((int)player.pos.X, (int)player.pos.Y, 16, 40)));
                isShooting = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                isShooting = false;
            }
        }

        private void Spawn_Meteors()
        {
            while (meteors.Count < 3)
            {
                int ran_x = random.Next(50, 1280);
                int ran_y = random.Next(-300, 0);
                meteors.Add(new Meteor(new Vector2(ran_x, ran_y), new Rectangle(ran_x, ran_y, 128, 128)));
            }
        }

        private void Check_Boundaries()
        {
            if(player.pos.X > 1300)
            {
                player.pos = new Vector2(-20, player.pos.Y);
            }

            if (player.pos.X < -22)
            {
                player.pos = new Vector2(1290, player.pos.Y);
            }

        }
        
        protected override void Update(GameTime gameTime)
        {
            Input_Listen();

            Spawn_Meteors();

            Check_Boundaries();



            



            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].pos = new Vector2(bullets[i].pos.X, bullets[i].pos.Y - 20);
                bullets[i].UpdateRectangle();
            }

            for (int i = 0; i < meteors.Count; i++)
            {
                meteors[i].pos = new Vector2(meteors[i].pos.X, meteors[i].pos.Y + 3);
                meteors[i].UpdateRectangle();
            }

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);



            spriteBatch.Begin();
            //Ritar ut bakgrunden, i och med den låga upplösningen av texturen så fyller vi ut spelytan med flera småbilder tills hela skärmen är täckt.
            for (int y = 0; y < 768; y += background.Width)
            {
                for (int x = 0; x < 1280; x += background.Width)
                {
                    spriteBatch.Draw(background, new Vector2(x, y), Color.White);
                }
            }



            for(int i = 0; i < bullets.Count; i++)
            {
                spriteBatch.Draw(fire, bullets[i].rec, Color.White);
            }


            for (int i = 0; i < meteors.Count; i++)
            {
                spriteBatch.Draw(meteor, meteors[i].rec, Color.White);
            }


            //ritar ut spelaren
            spriteBatch.Draw(ship, player.rec, Color.White);


            spriteBatch.End();




            base.Draw(gameTime);
        }
    }
}
