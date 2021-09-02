using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ShiftGenerator.Common.Data_Transfer_Object;
using Domain.ShiftGenerator.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Domain.ShiftGenerator.API.Controllers.Shifts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftsServices _shiftsServices;
        public ShiftsController(IShiftsServices shiftsServices)
        {
            _shiftsServices = shiftsServices;
        }

        /// <summary>
        /// Método para crear los turnos para apartar el servicio prestado por los comercios
        /// </summary>
        /// <param name="createShift"> Clase de transporte de datos </param>
        /// <returns> Estado de la transacción </returns>
        [HttpPost("CreateShifts")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult CreateShifts(CreateShiftDto createShift)
        {
            // Validación del modelo
            if (!ModelState.IsValid)
            {
                return BadRequest("Error en datos del modelo");
            }

            string context = ControllerContext.HttpContext.Request.Path.Value;
            try
            {                
                return Ok(_shiftsServices.CreateShifts(createShift));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }
    }
}