//-----------------------------------------------------------------------
// <copyright file="IApplyPhysics.cs" company="RVS Game Company">
//     Copyright (c) RVS Game Company. All rights reserved.
// </copyright>
// <author>Ricardo da Verdade Silva</author>
// <create_date> 2014-04-05 </create_date>
// <project> 2D Basic Physics Engine </project>
//-----------------------------------------------------------------------
namespace Basic_Physics_XNA_Engine.Interfaces
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Classes that implements this 
    /// interface will apply physics. 
    /// The Idea is receive a gravity 
    /// object reference and interact with this. 
    /// To this happen, some information from 
    /// real world will be necessary, 
    /// like mass and velocity.
    ///  This interface implement IExistsInGameWorld.
    /// </summary>
    public interface IApplyPhysics : IExistsInGameWorld
    {
        /// <summary>
        /// Gets or sets a value indicating whether
        /// object will be affected by physics.
        /// </summary>
        bool IsPhysicsOn { get; set; }

        /// <summary>
        /// Gets or sets the velocity of
        /// object.
        /// </summary>
        Vector2 Velocity { get; set; }

        /// <summary>
        /// Gets or sets object acceleration.
        /// </summary>
        Vector2 Acceleration { get; set; }

        /// <summary>
        /// Gets or sets representation
        /// of object mass.
        /// </summary>
        float Mass { get; set; }

        /// <summary>
        /// Gets or sets reference to world gravity.    
        /// </summary>
        Gravity WorldGravity { get; set; }

        /// <summary>
        /// Apply force to this object.
        /// </summary>
        /// <param name="forceToApply">Force to apply.</param>
        void ApplyForce(Vector2 forceToApply);
    }
}
