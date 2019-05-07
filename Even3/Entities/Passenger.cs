using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Even3.Entities
{
    /// <summary>
    /// Passenger class
    /// </summary>
    public class Passenger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Passenger" /> class.
        /// </summary>
        /// <param name="currentFloor">The current floor.</param>
        /// <param name="destionationFloor">The destionation floor.</param>
        public Passenger(int currentFloor, int destionationFloor)
        {
            CurrentFloor = currentFloor;
            DestionationFloor = destionationFloor;
        }

        /// <summary>
        /// Gets or sets the current floor.
        /// </summary>
        /// <value>
        /// The current floor.
        /// </value>
        public int CurrentFloor { get; set; }

        /// <summary>
        /// Gets or sets the destionation floor.
        /// </summary>
        /// <value>
        /// The destionation floor.
        /// </value>
        public int DestionationFloor { get; set; }


        /// <summary>
        /// Gets a value indicating whether this <see cref="Passenger" /> is ascending.
        /// </summary>
        /// <value>
        ///   <c>true</c> if ascending; otherwise, <c>false</c>.
        /// </value>
        public bool Ascending { get { return CurrentFloor < DestionationFloor; } }
    }
}
