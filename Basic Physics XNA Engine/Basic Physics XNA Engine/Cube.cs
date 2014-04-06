//-----------------------------------------------------------------------
// <copyright file="Cube.cs" company="RVS Game Company">
//     Copyright (c) RVS Game Company. All rights reserved.
// </copyright>
// <author>Ricardo da Verdade Silva</author>
// <create_date> 2014-04-05 </create_date>
// <project> 2D Basic Physics Engine </project>
//-----------------------------------------------------------------------
namespace Basic_Physics_XNA_Engine
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// This is a cube used to tests and to
    /// serve as base class. This is a <see cref="DrawableGameComponent"/>
    /// and implements <see cref="IApplyPhysics"/> and
    /// <see cref="ICollidable"/>.
    /// </summary>
    public class Cube : DrawableGameComponent, IApplyPhysics, ICollidable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cube"/> class.
        /// </summary>
        /// <param name="game">Reference to game.</param>
        public Cube(Game game)
            : base(game)
        {
            IsActive = true;
            IsPhysicsOn = true;
            this.Velocity = new Vector2(0,0);
            game.Components.Add(this);
        }

        /// <summary>
        /// Gets or sets a value to draw device.
        /// </summary>
        public SpriteBatch SpriteBatch { get; set; }

        /// <summary>
        /// Gets or sets a value that indicating
        /// bounds of object.
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int) this.Position.X,
                    (int) this.Position.Y,
                    (int) (this.Size.X),
                    (int) (this.Size.Y));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating position of object
        /// in game world.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether object
        /// is active in game world.Sometimes you may want 
        /// temporarily remove object from game, for this 
        /// just deactivate. While deactivated, object 
        /// should do nothing and cannot impact in game world.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// object will be affected by physics.
        /// </summary>
        public bool IsPhysicsOn { get; set; }

        /// <summary>
        /// Gets or sets the velocity of
        /// object.
        /// </summary>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// Gets or sets object acceleration.
        /// </summary>
        public Vector2 Acceleration { get; set; }

        /// <summary>
        /// Gets or sets representation
        /// of object mass in kilograms.
        /// </summary>
        public float Mass { get; set; }

        /// <summary>
        /// Gets or sets reference to world gravity.
        /// </summary>
        public Gravity WorldGravity { get; set; }

        /// <summary>
        /// Gets or sets object size.
        /// </summary>
        public Vector2 Size { get; set; }

        /// <summary>
        /// Apply force to this object.
        /// </summary>
        /// <param name="forceToApply">Force to apply.</param>
        public void ApplyForce(Vector2 forceToApply)
        {
            Vector2 thisForce = new Vector2
            {
                X = this.Mass*this.Acceleration.X,
                Y = this.Mass*this.Acceleration.Y
            };

            this.Acceleration = thisForce + forceToApply;
            this.Position += Acceleration;
        }

        private Texture2D CubeTexture2D
        {
            get { return this.Game.Content.Load<Texture2D>("GameThumbnail"); }
        }

        /// <summary>
        /// Method to be trigger when this object
        /// get involved in collision.
        /// </summary>
        /// <param name="collider">Other object participating
        /// in collision.</param>
        public void OnCollisionHappens(ICollidable collider)
        {
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Called when graphics resources need to be loaded. Override this method to load any component-specific graphics resources.
        /// </summary>
        protected override void LoadContent()
        {
            this.SpriteBatch = (SpriteBatch)this.Game.Services.GetService(typeof(SpriteBatch));
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (this.IsPhysicsOn)
            {
                ApplyGravity(gameTime);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Allows the game component to draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            this.SpriteBatch.Draw(this.CubeTexture2D, this.Bounds, Color.White);
            base.Draw(gameTime);
        }

        /// <summary>
        /// Apply gravity to object.
        /// </summary>
        /// <param name="gameTime">Reference to game time.</param>
        private void ApplyGravity(GameTime gameTime)
        {
            this.Acceleration = new Vector2
            {
                X = Acceleration.X,
                Y = this.WorldGravity.Force
            };

            this.Velocity += this.Acceleration * gameTime.ElapsedGameTime.Milliseconds/(this.WorldGravity.Force * 1000);
            this.Position += this.Velocity;
        }
    }
}
