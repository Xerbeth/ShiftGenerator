CREATE PROCEDURE develop.CreateShifts	@ServiceId INT,
										@StartDate DATETIME, 
										@EndDate DATETIME,
										@Message varchar(100) out
AS
BEGIN
	-- Bloque para declaración de variables SP
	BEGIN
		DECLARE @Existence INT
		DECLARE @OpeningTime TIME
		DECLARE @Duration INT
		DECLARE @OpenTimeAux TIME
		DECLARE @CloseTimeAux TIME
		DECLARE @StartDateAux DATETIME = @StartDate
		DECLARE @Days INT -- Número de dias entre las fechas
		DECLARE @DaysAux INT = 0
		DECLARE @Shift_ INT = 0 -- Número de turnos por día
		DECLARE @ShiftAux INT = 0
		DECLARE @ShiftsGenerated INT = 0
	END -- Fin bloque declaración de variables SP
	-- BLOQUE PRINCIPAL
	BEGIN
		BEGIN -- Bloque de validación de rango de fechas
			IF @EndDate < @StartDate
			BEGIN 
				SET @Message = 'La fecha final no puede ser menor a la fecha inicial'
				RETURN @Message
			END
		END -- Fin bloque de validación de rango de fechas
		BEGIN -- Bloque para validar la existencia del identificador del servicio
			BEGIN TRY -- Control de ejecución de bloque 
				SELECT @Existence = CAST(COUNT(1)  AS INT)
				FROM develop.Services 
				WHERE Service_Id = @ServiceId
				IF @Existence = 0
				BEGIN 
					SET @Message = 'No existe el identificador del servicio'
					RETURN @Message
				END						
			END TRY  
			BEGIN CATCH
				SET @Message = 'Ocurrió un error consultando el identificador del servicio'
				RETURN @Message
			END CATCH
		END -- Fin bloque validar la existencia del identificador del servicio
		BEGIN -- Bloque para consultar la hora de apertura, la hora de cierre y la duración del servicio
			BEGIN TRY -- Control de ejecución de bloque 
				SELECT @OpeningTime = Opening_Time,
					   @OpenTimeAux = Opening_Time,
					   @Duration = Duration,
					   @CloseTimeAux = Close_Time
				FROM develop.Services  
				WHERE Service_Id = @ServiceId		
			END TRY  
			BEGIN CATCH
				SET @Message = 'Ocurrió un error consultando la hora de apertura, la hora de cierre y la duración del servicio'
				RETURN @Message
			END CATCH
		END -- Fin bloque para consultar la hora de apertura, la hora de cierre y la duración del servicio
		BEGIN			
			BEGIN TRY -- Control de ejecución de bloque
				SET @Days = (SELECT DATEDIFF(DAY, @StartDate, @EndDate)) + 1 -- Cantidad de ciclos por dia
				SET @Shift_ = (SELECT DATEDIFF(MINUTE, Opening_Time, Close_Time)/Duration FROM develop.Services WHERE Service_Id = @ServiceId) -- Diferencia en minutos de la hora de inico y la hora de cierre y se divide en la duración del turno para obtener la cantidad de turnos por día
				WHILE (@DaysAux < @Days)
				BEGIN -- Inicio while dias	
					SET @ShiftAux = 0
					SET @OpenTimeAux = @OpeningTime
					WHILE (@ShiftAux < @Shift_)
					BEGIN	
						SET @CloseTimeAux = (SELECT DATEADD(MINUTE,@Duration,@OpenTimeAux) FROM develop.Services)
						INSERT INTO develop.Shifts (service_id, Shift_Date, Start_Time, End_Time)
				        VALUES (@ServiceId,@StartDateAux,@OpenTimeAux,@CloseTimeAux)
						SET @OpenTimeAux = (SELECT DATEADD(MINUTE,@Duration,@OpenTimeAux) FROM develop.Services)
						SET @ShiftAux = @ShiftAux + 1
						SET @ShiftsGenerated = @ShiftsGenerated + 1
					END
					SET @StartDateAux = (SELECT DATEADD(DAY,1,@StartDateAux)) -- Se aumenta la sigiente fecha de generación de turnos
					SET @DaysAux = @DaysAux + 1 -- se aumenta la variable de ciclos por día
				END -- Fin while dias			
				SET @Message = 'Solicitud de reserva realizada satisfactoriamente. Total de turnos generados ' + CAST(@ShiftsGenerated as varchar(1000))
			END TRY  
			BEGIN CATCH
				SET @Message = 'Ocurrió un error registrando la reserva'
				RETURN @Message
			END CATCH
		END 
	END
END
GO