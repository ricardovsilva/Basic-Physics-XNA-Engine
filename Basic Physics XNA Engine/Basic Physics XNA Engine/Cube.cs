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
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Gets or sets a value that indicating
        /// bounds of object.
        /// </summary>
        public Rectangle Bounds { get; set; }

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
        /// Apply force to this object.
        /// </summary>
        /// <param name="forceToApply">Force to apply.</param>
        public void ApplyForce(Vector2 forceToApply)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Method to be trigger when this object
        /// get involved in collision.
        /// </summary>
        /// <param name="collider">Other object participating
        /// in collision.</param>
        public void OnCollisionHappens(ICollidable collider)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            base.Update(gameTime);
        }

        /// <summary>
        /// Allows the game component to draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
