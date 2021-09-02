using Domain.ShiftGenerator.Common.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ShiftGenerator.DAL.Interfaces
{
    public interface IShiftsRepository
    {
        /// <summary>
        /// Método para crear los turnos para apartar el servicio prestado por los comercios
        /// </summary>
        /// <param name="createShift"> Clase de transporte de datos </param>
        /// <returns> Mensaje de la ejecución </returns>
        string CreateShifts(CreateShiftDto createShift);
    }
}
