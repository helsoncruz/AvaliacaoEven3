using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Even3.Entities
{
    /// <summary>
    /// Elevator class
    /// </summary>
    public class Elevator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator" /> class.
        /// </summary>
        /// <param name="topFloor">The top floor.</param>
        /// <param name="starterFloor">The starter floor.</param>
        public Elevator(int topFloor, int starterFloor)
        {
            TopFloor = topFloor;
            CurrentFloor = starterFloor;
            StarterFloor = starterFloor;
            ResetCount();
        }

        /// <summary>
        /// Gets or sets the top floor.
        /// </summary>
        /// <value>
        /// The top floor.
        /// </value>
        public int TopFloor { get; set; }

        /// <summary>
        /// Gets or sets the current floor.
        /// </summary>
        /// <value>
        /// The current floor.
        /// </value>
        public int CurrentFloor { get; set; }

        /// <summary>
        /// Gets or sets the starter floor.
        /// </summary>
        /// <value>
        /// The starter floor.
        /// </value>
        public int StarterFloor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Elevator"/> is ascending.
        /// </summary>
        /// <value>
        ///   <c>true</c> if ascending; otherwise, <c>false</c>.
        /// </value>
        public bool Ascending { get; set; }

        /// <summary>
        /// Gets or sets the travelled distance.
        /// </summary>
        /// <value>
        /// The travelled distance.
        /// </value>
        public int TravelledDistance { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public int Distance { get; set; }

        /// <summary>
        /// Goes to.
        /// </summary>
        /// <param name="destinationFloor">The destination floor.</param>
        public void GoTo(int destinationFloor)
        {
            if(destinationFloor >= 0 && destinationFloor <= TopFloor)
            {
                Ascending = CurrentFloor < destinationFloor ? true : false;
                Distance = Ascending ? (destinationFloor - CurrentFloor) : (CurrentFloor - destinationFloor);
                TravelledDistance += Distance;
                CurrentFloor = destinationFloor;
            }

        }

        /// <summary>
        /// Resets the count.
        /// </summary>
        public void ResetCount()
        {
            Distance = 0;
            TravelledDistance = 0;
            CurrentFloor = StarterFloor;
        }
    }
}
