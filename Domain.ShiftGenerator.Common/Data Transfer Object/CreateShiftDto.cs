using System;

namespace Domain.ShiftGenerator.Common.Data_Transfer_Object
{
    /// <summary>
    /// Clase de transferencia de datos entre capas
    /// </summary>
    public class CreateShiftDto
    {
        /// <summary>
        /// Propiedad para el identificador del servicio
        /// </summary>
        public int ServiceId { get; set; }
        /// <summary>
        /// Propiedad para la fecha y hora de reserva
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// propiedad para la fecha y hora de finalización de la reserva
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Método constructor de la clase
        /// </summary>
        public CreateShiftDto() { }
        /// <summary>
        /// Método constructor sobrecargado de la clase
        /// </summary>
        public CreateShiftDto(int serviceId, DateTime startDate, DateTime endDate)
        {
            ServiceId = serviceId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
