using Microsoft.Xna.Framework;

namespace Basic_Physics_XNA_Engine
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class ColliderManager : Microsoft.Xna.Framework.GameComponent
    {
        public ColliderManager(Game game)
            : base(game)
        {
            this.CollidablesList = new List<ICollidable>();
            game.Components.Add(this);
        }
        private List<ICollidable> CollidablesList { get; set; }

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
            foreach (var collidable in CollidablesList)
            {
                foreach (var otherCollidable in CollidablesList)
                {
                    if (collidable != otherCollidable
                        && collidable.Bounds.Intersects(otherCollidable.Bounds))
                    {
                        collidable.OnCollisionHappens(otherCollidable, gameTime);
                        otherCollidable.OnCollisionHappens(collidable, gameTime);
                    }
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Add collidable to list.
        /// </summary>
        /// <param name="collidable">Collidable reference.</param>
        /// <exception cref="Exception">Throws when collidable passed by parameter
        /// already exists in List.</exception>
        public void AddCollidable(ICollidable collidable)
        {
            if (!this.CollidablesList.Contains(collidable))
            {
                this.CollidablesList.Add(collidable);
            }
            else
            {
                throw new Exception("Collidable already in list. Cannot add again.");
            }
        }
    }
}
