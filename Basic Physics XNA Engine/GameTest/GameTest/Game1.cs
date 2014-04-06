using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameTest
{
    using System.ComponentModel;
    using Basic_Physics_XNA_Engine;
    using Basic_Physics_XNA_Engine.Interfaces;
    using PrimitivesSample;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        private ColliderManager colliderManager;
        private Cube testCube;
        private Floor floorTest;
        private Floor firstPlatform;
        private Gravity worldGravity;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 800,
                PreferredBackBufferHeight = 600,
                IsFullScreen = false
            };

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.Services.AddService(typeof(SpriteBatch), this.spriteBatch);
            this.worldGravity = new Gravity(Gravity.Forces.Earth);
            this.testCube = new Cube(this)
            {
                Position = new Vector2(400, 50),
                WorldGravity = worldGravity,
                Size = new Vector2(32,32),
                Mass = 50
            };

            this.floorTest = new Floor(this)
            {
                Position = new Vector2(0, 570),
                Size = new Vector2(this.graphics.PreferredBackBufferWidth, 30)
            };

            this.firstPlatform = new Floor(this)
            {
                Position = new Vector2(0, 400),
                Size = new Vector2(150, 30)
            };

            this.colliderManager = new ColliderManager(this);

            foreach (var component in this.Components)
            {
                if (component is ICollidable)
                {
                    this.colliderManager.AddCollidable(component as ICollidable);
                }
                component.Initialize();
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            this.DrawGrid(20);
            base.Draw(gameTime);
            spriteBatch.End();
        }

        private void DrawGrid(float gridSize)
        {
            // where can we put the stars? 
            int screenWidth = graphics.GraphicsDevice.Viewport.Width;
            int screenHeight = graphics.GraphicsDevice.Viewport.Height;

            PrimitiveBatch primitiveBatch = new PrimitiveBatch(this.GraphicsDevice);
            primitiveBatch.Begin(PrimitiveType.LineList);

            for (float i = gridSize; i < screenWidth; i += gridSize)
            {
                //draw line verticaly            
                primitiveBatch.AddVertex(new Vector2(i, 0), Color.White);
                primitiveBatch.AddVertex(new Vector2(i, screenHeight), Color.White);
            }

            for (float i = gridSize; i < screenHeight; i += gridSize)
            {
                //draw line verticaly            
                primitiveBatch.AddVertex(new Vector2(0, i), Color.White);
                primitiveBatch.AddVertex(new Vector2(screenWidth, i), Color.White);
            }

            primitiveBatch.End();
        }

    }
}
