namespace Basic_Physics_XNA_Engine
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Floor : DrawableGameComponent, ICollidable, IApplyPhysics
    {
        public Floor(Game game)
            : base(game)
        {
            IsActive = true;
            game.Components.Add(this);
        }

        /// <summary>
        /// Allows the game component to perform any initialization ist needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Called when graphics resources need to be loaded. Override this method to load any component-specific graphics resources.
        /// </summary>
        protected override void LoadContent()
        {
            this.SpriteBatch = (SpriteBatch)this.Game.Services.GetService(typeof(SpriteBatch));
            this.FloorTexture2D = Game.Content.Load<Texture2D>("GameThumbnail");
            base.LoadContent();
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
        /// Called when the DrawableGameComponent needs to be drawn. Override this method with component-specific drawing code. Reference page contains links to related conceptual articles.
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Draw.</param>
        public override void Draw(GameTime gameTime)
        {
            this.SpriteBatch.Draw(this.FloorTexture2D, this.Bounds, Color.White);
            base.Draw(gameTime);
        }

        public Vector2 Size { get; set; }

        public Texture2D FloorTexture2D { get; set; }

        public bool IsPhysicsOn { get;set; }

        public Vector2 Velocity { get; set; }

        public Vector2 Acceleration { get; set; }

        public float Mass { get; set; }

        public Gravity WorldGravity { get; set; }

        public void ApplyForce(Vector2 forceToApply, GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public SpriteBatch SpriteBatch { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int)this.Position.X,
                    (int)this.Position.Y,
                    (int)(this.Size.X),
                    (int)(this.Size.Y));
            }
        }

        public bool IsActive { get; set; }

        public void OnCollisionHappens(ICollidable collider, GameTime gameTime)
        {
            if (collider is IApplyPhysics)
            {
                IApplyPhysics colliderPhysics = (IApplyPhysics) collider;

                Vector2 weightForce = new Vector2
                {
                    X = 0,
                    Y = -(colliderPhysics.WorldGravity.Force * colliderPhysics.Mass)
                };

                colliderPhysics.ApplyForce(weightForce, gameTime);
            }
        }


        public Vector2 Force
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
