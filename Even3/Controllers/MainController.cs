using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Even3.Commands;
using Even3.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Even3.Controllers
{
    /// <summary>
    /// Main Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[Controller]/[Action]")]
    [ApiController]
    public class MainController : ControllerBase
    {

        /// <summary>
        /// Action referente a solução 1 da terceira questão.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<SolutionResponse> SolutionOne()
        {
            MainCommand mainCommand = new MainCommand();
            return Ok(mainCommand.SolutionOne());
        }



        /// <summary>
        /// Action referente a solução 2 da terceira questão.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<SolutionResponse> SolutionTwo()
        {
            MainCommand mainCommand = new MainCommand();
            return Ok(mainCommand.SolutionTwo());
        }

        /// <summary>
        /// Action referente a solução 3 da terceira questão.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<SolutionResponse> SolutionThree(SolutionThreeRequest request)
        {
            if(request.Passengers == null || !request.Passengers.Any() || request.Elevator == null || request.Passengers.Any(s=>s.CurrentFloor > request.Elevator.TopFloor || s.DestionationFloor > request.Elevator.TopFloor))
            {
                return BadRequest();
            }
            MainCommand mainCommand = new MainCommand ();
            return Ok(mainCommand.SolutionThree(request));
        }
    }
}
