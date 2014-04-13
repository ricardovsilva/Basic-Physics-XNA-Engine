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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// This is a cube used to tests and to
    /// serve as base class. This is a <see cref="DrawableGameComponent"/>
    /// and implements <see cref="IApplyPhysics"/> and
    /// <see cref="ICollidable"/>.
    /// </summary>
    public class Cube : DrawableGameComponent, IApplyPhysics, ICollidable, IControllable
    {
        private const float MovementForce = 200f;
        private const float JumpForce = 900f;
        private const float PixelsPerMetre = 10f;

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
            this.UsesGamepad = true;
            this.UsesKeyboard = true;
            this.GamepadIndex = 0;
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
        public Vector2 Position
        {
            get { return this.position; }
            set
            {
                this.Delta = value - this.position;
                this.position = value;
            }
        }

        Vector2 position;

        /// <summary>
        /// Gets or sets a value indicating the change from previous
        /// position.
        /// </summary>
        public Vector2 Delta { get; set; }

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

        public Vector2 Force
        {
            get
            {
                Vector2 thisForce = new Vector2
                {
                    X = this.Mass * this.Velocity.X,
                    Y = this.Mass * this.Velocity.Y
                };

                return thisForce;
            }
        }

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
        /// Gets or sets a queue of forces.
        /// </summary>
        private Queue<Vector2> Forces { get; set; }

        /// <summary>
        /// Apply force to this object.
        /// </summary>
        /// <param name="forceToApply">Force to apply.</param>
        /// <param name="gameTime">Reference to game time.</param>
        public void ApplyForce(Vector2 forceToApply, GameTime gameTime)
        {
            Forces.Enqueue(forceToApply);
        }

        private void CalculateForces()
        {
            Vector2 resultForce = Vector2.Zero;

            while (Forces.Count > 0)
            {
                resultForce += Forces.Dequeue();
            }

            this.Acceleration = resultForce/this.Mass;
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
        public void OnCollisionHappens(ICollidable collider, GameTime gameTime)
        {
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            this.Forces = new Queue<Vector2>();
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
                ApplyPhysics(gameTime);
            }

            if (this.UsesGamepad)
            {
                GetGamepadState(gameTime);
            }

            if (this.UsesKeyboard)
            {
                GetKeyboardState(gameTime);
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
            Vector2 gravityForce = new Vector2()
            {
                X = 0,
                Y = this.WorldGravity.Force * Mass
            };

            //gravityForce = gravityForce*elapsedTime;

            this.ApplyForce(gravityForce, gameTime);
        }

        private void GetGamepadState(GameTime gameTime)
        {
            GamePadState gamePadState = GamePad.GetState((PlayerIndex) this.GamepadIndex);
            if (gamePadState.ThumbSticks.Left.X != 0)
            {
                this.ApplyForce(new Vector2
                {
                    X = gamePadState.ThumbSticks.Left.X*MovementForce,
                    Y = 0
                }, gameTime);
            }

            if (gamePadState.Buttons.A.Equals(ButtonState.Pressed))
            {
                this.ApplyForce(new Vector2
                {
                    X = 0,
                    Y = -(Convert.ToInt32(gamePadState.Buttons.A == ButtonState.Pressed) * JumpForce)
                }, gameTime);
            }
        }

        private void GetKeyboardState(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                this.ApplyForce(new Vector2(-MovementForce, 0), gameTime);
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                this.ApplyForce(new Vector2(MovementForce, 0), gameTime);
            }

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                this.ApplyForce(new Vector2(0, -JumpForce), gameTime);
            }
        }

        /// <summary>
        /// Apply physics to object.
        /// </summary>
        /// <param name="gameTime">Reference to game time.</param>
        private void ApplyPhysics(GameTime gameTime)
        {
            ApplyGravity(gameTime);
            CalculateForces();
            this.Velocity += Acceleration * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            this.Position += PixelsPerMetre * Velocity * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
        }

        public bool UsesKeyboard { get; set; }

        public bool UsesGamepad { get; set; }

        public int GamepadIndex { get; set; }

        public ControllableState CurrentState
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
