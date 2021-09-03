using Domain.ShiftGenerator.Common.Data_Transfer_Object;
using Domain.ShiftGenerator.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Domain.ShiftGenerator.DAL.Implementation
{
    public class ShiftsRepository : IShiftsRepository
    {
        #region Propiedades
        private IConfiguration Configuration;
        private readonly string ConnectionString;
        #endregion Propiedades
        /// <summary>
        /// Método constructor con la cadena de conexión
        /// </summary>
        /// <param name="configuration"> Cadena de conexión </param>
        public ShiftsRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public string CreateShifts(CreateShiftDto createShift)
        {
            string message = string.Empty;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                try
                {                    
                    cmd.CommandText = "develop.CreateShifts";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ServiceId", SqlDbType.Int));
                    cmd.Parameters["@ServiceId"].Value = createShift.ServiceId;
                    cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime));
                    cmd.Parameters["@StartDate"].Value = createShift.StartDate;
                    cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime));
                    cmd.Parameters["@EndDate"].Value = createShift.EndDate;
                    cmd.Parameters.Add(new SqlParameter("@Message", SqlDbType.VarChar,100));
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    message = cmd.Parameters["@Message"].Value.ToString();                    
                }
                catch (ArgumentException ex)
                {
                    message = ex.Message;
                }
                finally
                {
                    connection.Close();
                }

                return message;
            }            
        }
    }
}
