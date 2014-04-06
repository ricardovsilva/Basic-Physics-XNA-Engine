//-----------------------------------------------------------------------
// <copyright file="IExistsInGameWorld.cs" company="RVS Game Company">
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
    /// This interface is not the main point of this engine, 
    /// but virtually all objects will implement this. 
    /// The context is very simple, if class is not a manager, 
    /// utilities or extension, then it exists in game world. 
    /// Everything put in game exists in game world. 
    /// </summary>
    public interface IExistsInGameWorld
    {
        /// <summary>
        /// Gets or sets a value indicating position of object
        /// in game world.
        /// </summary>
        Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets a value that indicating
        /// bounds of object.
        /// </summary>
        Rectangle Bounds { get; }

        /// <summary>
        /// Gets or sets a value indicating whether object
        /// is active in game world.Sometimes you may want 
        /// temporarily remove object from game, for this 
        /// just deactivate. While deactivated, object 
        /// should do nothing and cannot impact in game world.
        /// </summary>
        bool IsActive { get; set; }
    }
}
