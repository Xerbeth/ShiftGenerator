#region Referencias
using Domain.ShiftGenerator.BussinesLayer.Interfaces;
using Domain.ShiftGenerator.Common.Data_Transfer_Object;
using Domain.ShiftGenerator.Services.Interfaces;
#endregion Referencias

namespace Domain.ShiftGenerator.Services.Implementation
{
    public class ShiftsServices : IShiftsServices
    {
        private readonly IShiftsBL _shiftsBL;
        
        public ShiftsServices(IShiftsBL shiftsBL)
        {
            _shiftsBL = shiftsBL;
        }

        /// <summary>
        /// Método para crear los turnos para apartar el servicio prestado por los comercios
        /// </summary>
        /// <param name="createShift"> Clase de transporte de datos </param>
        /// <returns> Objecto resultado de la transacción </returns>
        public TransactionDto<string> CreateShifts(CreateShiftDto createShift)
        {
            return _shiftsBL.CreateShifts(createShift);
        }
    }
}
