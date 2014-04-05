//-----------------------------------------------------------------------
// <copyright file="ICollidable.cs" company="RVS Game Company">
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
    /// This interface will provide information 
    /// to calculate collisions. All collidable
    /// object must implement to IExistsInGameWorld. 
    /// Basically, it's object needs to provide a
    ///  Rectangle with bounds information, 
    /// and must have an method to trigger 
    /// when collision happens.
    /// </summary>
    public interface ICollidable : IExistsInGameWorld
    {
        /// <summary>
        /// Gets or sets a value that indicating
        /// bounds of object.
        /// </summary>
        Rectangle Bounds { get; set; }

        /// <summary>
        /// Method to be trigger when this object
        /// get involved in collision.
        /// </summary>
        /// <param name="collider">Other object participating
        /// in collision.</param>
        void OnCollisionHappens(ICollidable collider);
    }
}
