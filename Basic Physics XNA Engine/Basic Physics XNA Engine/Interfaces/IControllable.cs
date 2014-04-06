//-----------------------------------------------------------------------
// <copyright file="IControllable.cs" company="RVS Game Company">
//     Copyright (c) RVS Game Company. All rights reserved.
// </copyright>
// <author>Ricardo da Verdade Silva</author>
// <create_date> 2014-04-05 </create_date>
// <project> 2D Basic Physics Engine </project>
//-----------------------------------------------------------------------
namespace Basic_Physics_XNA_Engine.Interfaces
{
    /// <summary>
    /// Every class that implement this interface will be
    /// controllable.
    /// </summary>
    public interface IControllable : IExistsInGameWorld
    {
        /// <summary>
        /// Gets or sets a value indicating whether
        /// this object is controllable by keyboard.
        /// </summary>
        bool UsesKeyboard { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// this object is controllable by gamepad.
        /// </summary>
        bool UsesGamepad { get; set; }

        /// <summary>
        /// Gets or sets a value indicating gamepad index.
        /// </summary>
        int GamepadIndex { get; set; }
    }
}
