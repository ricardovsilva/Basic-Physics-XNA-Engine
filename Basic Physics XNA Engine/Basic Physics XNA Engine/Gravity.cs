//-----------------------------------------------------------------------
// <copyright file="Gravity.cs" company="RVS Game Company">
//     Copyright (c) RVS Game Company. All rights reserved.
// </copyright>
// <author>Ricardo da Verdade Silva</author>
// <create_date> 2014-04-05 </create_date>
// <project> 2D Basic Physics Engine </project>
//-----------------------------------------------------------------------

namespace Basic_Physics_XNA_Engine
{
    /// <summary>
    /// This class represents the gravity force.
    /// </summary>
    public class Gravity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gravity"/> class.
        /// </summary>
        /// <param name="force">Intensity of force in newtons..
        /// Use <see cref="Gravity.Forces"/> class to get constant values.</param>
        public Gravity(float force)
        {
            this.Force = force;
        }

        /// <summary>
        /// Gets or sets a value indicating whether gravity is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the force in newtons.
        /// </summary>
        public float Force { get; set; }

        public class Forces
        {
            /// <summary>
            /// Earth acceleration in meters per seconds to square
            /// </summary>
            public const float Earth = 9.81f;
        }
    }
}
