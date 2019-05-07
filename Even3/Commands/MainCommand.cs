using Even3.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Even3.Commands
{
    /// <summary>
    /// MainCommnd class
    /// </summary>
    public class MainCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainCommand"/> class.
        /// </summary>
        public MainCommand()
        {            
        }

        /// <summary>
        /// Solutions the one.
        /// </summary>
        /// <returns></returns>
        public SolutionResponse SolutionOne()
        {
            List<Passenger> passengers = new List<Passenger>() { new Passenger(8, 0), new Passenger(0, 10) };
            var elevator = new Elevator(10, 5);
            var shorterDistance = 0;
            var paxCombinations = Permutate(passengers, passengers.Count);
            foreach (var paxPermu in paxCombinations)
            {
                foreach (var pax in paxPermu)
                {
                    elevator.GoTo(pax.CurrentFloor);
                    elevator.GoTo(pax.DestionationFloor);                    
                }
                if (shorterDistance == 0 || elevator.TravelledDistance < shorterDistance)
                {
                    shorterDistance = elevator.TravelledDistance;
                }               
                elevator.ResetCount();
            }

            SolutionResponse response = new SolutionResponse() { ShorterTravelledDistance = $"Em seu menor caminho, o elevador percorre {shorterDistance} andares." };

            return response;
        }

        /// <summary>
        /// Solutions the two.
        /// </summary>
        /// <returns></returns>
        public SolutionResponse SolutionTwo()
        {
            List<Passenger> passengers = new List<Passenger>() { new Passenger(8, 0), new Passenger(0, 7), new Passenger(3, 15) };
            var elevator = new Elevator(20, 3);
            var shorterDistance = 0;
            var paxCombinations = Permutate(passengers, passengers.Count);
            foreach (var paxPermu in paxCombinations)
            {
                List<Passenger> travelledPaxes = new List<Passenger>();
                foreach (var pax in paxPermu)
                {
                    var paxesInRoute = GetPassengersInRoute(pax, paxPermu, pax.Ascending);
                    if (travelledPaxes.Contains(pax)) { continue; }
                    if (paxesInRoute.Any() && paxesInRoute.Count() > 1)
                    {                        
                        var firstStop = paxesInRoute.Min(s => s.CurrentFloor);
                        var lastStop = paxesInRoute.Max(s => s.DestionationFloor);

                        elevator.GoTo(firstStop);
                        elevator.GoTo(lastStop);
                        travelledPaxes = paxesInRoute;
                    }
                    else
                    {
                        elevator.GoTo(pax.CurrentFloor);
                        elevator.GoTo(pax.DestionationFloor);
                    }
                }

                if (shorterDistance == 0 || elevator.TravelledDistance < shorterDistance)
                {
                    shorterDistance = elevator.TravelledDistance;
                }
                elevator.ResetCount();
            }

            SolutionResponse response = new SolutionResponse() { ShorterTravelledDistance = $"Em seu menor caminho, o elevador percorre {shorterDistance} andares." };

            return response;
        }

        

        /// <summary>
        /// Solutions the three.
        /// </summary>
        /// <returns></returns>
        public SolutionResponse SolutionThree(SolutionThreeRequest request)
        {
            var shorterDistance = 0;
            var paxCombinations = Permutate(request.Passengers, request.Passengers.Count);
            foreach (var paxPermu in paxCombinations)
            {
                List<Passenger> travelledPaxes = new List<Passenger>();
                foreach (var pax in paxPermu)
                {
                    var paxesInRoute = GetPassengersInRoute(pax, paxPermu, pax.Ascending);
                    travelledPaxes.ForEach(s => paxesInRoute.Remove(s));
                    if (travelledPaxes.Contains(pax)) { continue; }
                    if (paxesInRoute.Any() && paxesInRoute.Count() > 1)
                    {
                        int firstStop = pax.Ascending ? paxesInRoute.Min(s => s.CurrentFloor) : paxesInRoute.Max(s => s.CurrentFloor);
                        int lastStop = pax.Ascending ? paxesInRoute.Max(s => s.DestionationFloor) : paxesInRoute.Min(s => s.DestionationFloor);

                        request.Elevator.GoTo(firstStop);
                        request.Elevator.GoTo(lastStop);
                        paxesInRoute.ForEach(s => travelledPaxes.Add(s));
                    }
                    else
                    {
                        request.Elevator.GoTo(pax.CurrentFloor);
                        request.Elevator.GoTo(pax.DestionationFloor);
                        travelledPaxes.Add(pax);
                    }
                }

                if (shorterDistance == 0 || request.Elevator.TravelledDistance < shorterDistance)
                {
                    shorterDistance = request.Elevator.TravelledDistance;
                }
                request.Elevator.ResetCount();
            }

            SolutionResponse response = new SolutionResponse() { ShorterTravelledDistance = $"Em seu menor caminho, o elevador percorre {shorterDistance} andares." };

            return response;
        }

        #region AuxMehtods

        /// <summary>
        /// Rotates the specified sequence.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <param name="count">The count.</param>
        private static void Rotate(List<Passenger> sequence, int count)
        {
            Passenger tmp = sequence[count - 1];
            sequence.RemoveAt(count - 1);
            sequence.Insert(0, tmp);
        }


        /// <summary>
        /// Permutates the specified pax list.
        /// </summary>
        /// <param name="paxList">The pax list.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        private static IEnumerable<List<Passenger>> Permutate(List<Passenger> paxList, int count)
        {
            if (count == 1)
            {
                yield return paxList;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    foreach (var perm in Permutate(paxList, count - 1))
                        yield return perm;
                    Rotate(paxList, count);
                }
            }
        }

        /// <summary>
        /// Gets the passengers in route.
        /// </summary>
        /// <param name="pax">The pax.</param>
        /// <param name="passengers">The passengers.</param>
        /// <param name="isAscending">if set to <c>true</c> [is ascending].</param>
        /// <returns></returns>
        private List<Passenger> GetPassengersInRoute(Passenger pax, List<Passenger> passengers, bool isAscending)
        {
            IEnumerable<Passenger> passengersInRoute = new List<Passenger>();
            if (isAscending)
            {
                passengersInRoute = passengers.Where(s => s.CurrentFloor >= pax.CurrentFloor && s.Ascending);
            }
            else
            {
                passengersInRoute = passengers.Where(s => s.CurrentFloor <= pax.CurrentFloor && !s.Ascending);
            }
            return passengersInRoute.ToList();
        }
        #endregion
    }
}
