#region Referencias
using System;
#endregion Referencias

namespace Domain.ShiftGenerator.Common.Data_Transfer_Object
{
    /// <summary>
    /// Clase generica como el objeto de transporte de las transacciones de la aplicación
    /// </summary>
    /// <typeparam name="T"> Clase que transporta </typeparam>
    public class TransactionDto<T>
    {
        #region Propiedades
        /// <summary>
        /// Propiedad para el estatus de la transacción
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// Propiedad para el mensaje personalizado de la transacción
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Clase de transporte con la informacíón
        /// </summary>
        public T Data { get; set; }
        #endregion Propiedades

        #region Métodos
        /// <summary>
        /// Método constructor
        /// </summary>
        public TransactionDto()
        {
            Message = String.Empty;
            Status = Status.Failure;
        }
        #endregion Métodos
    }

    /// <summary>
    /// Clase enum para el tipo de estatus
    /// </summary>
    public enum Status
    {
        Failure,
        Success
    }
}
