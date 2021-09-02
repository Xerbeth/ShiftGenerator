#region Referencias
using Domain.ShiftGenerator.BussinesLayer.Interfaces;
using Domain.ShiftGenerator.Common.Data_Transfer_Object;
using Domain.ShiftGenerator.DAL.Interfaces;
using System;
#endregion Referencias

namespace Domain.ShiftGenerator.BussinesLayer.Implementation
{
    public class ShiftsBL : IShiftsBL
    {
        private readonly IShiftsRepository _shiftsRepository;
        public ShiftsBL(IShiftsRepository shiftsRepository) 
        {
            _shiftsRepository = shiftsRepository;
        }
        /// <summary>
        /// Método para crear los turnos para apartar el servicio prestado por los comercios
        /// </summary>
        /// <param name="createShift"> Clase de transporte de datos </param>
        /// <returns> Objecto resultado de la transacción </returns>
        public TransactionDto<string> CreateShifts(CreateShiftDto createShift)
        {
            TransactionDto<string> transaction = new TransactionDto<string>();
            try
            {
                transaction.Data = _shiftsRepository.CreateShifts(createShift);
                transaction.Message = "Transacción realizada correctamente.";
                transaction.Status = Status.Success;
            }
            catch (ArgumentException ex)
            {
                transaction.Message = ex.Message;
            }
            return transaction;
        }
    }
}
