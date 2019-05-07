using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Even3.Entities
{
    /// <summary>
    /// SolutionThreeRequest class
    /// </summary>
    public class SolutionThreeRequest
    {
        /// <summary>
        /// Gets or sets the passengers.
        /// </summary>
        /// <value>
        /// The passengers.
        /// </value>
        public List<Passenger> Passengers { get; set; }

        /// <summary>
        /// Gets or sets the elevator.
        /// </summary>
        /// <value>
        /// The elevator.
        /// </value>
        public Elevator Elevator { get; set; }
    }
}
