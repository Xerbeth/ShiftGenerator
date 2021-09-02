using Domain.ShiftGenerator.Common.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ShiftGenerator.Services.Interfaces
{
    public interface IShiftsServices
    {
        /// <summary>
        /// Método para crear los turnos para apartar el servicio prestado por los comercios
        /// </summary>
        /// <param name="createShift"> Clase de transporte de datos </param>
        /// <returns> Objecto resultado de la transacción </returns>
        TransactionDto<string> CreateShifts(CreateShiftDto createShift);
    }
}
