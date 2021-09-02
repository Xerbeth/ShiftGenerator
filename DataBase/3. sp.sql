CREATE PROCEDURE develop.CreateShifts	@ServiceId INT,
										@StartDate DATETIME, 
										@EndDate DATETIME,
										@Message varchar(100) out
AS
	BEGIN-- Bloque para declaración de variables SP
		DECLARE @Existence INT
		DECLARE @OpeningTime TIME
		DECLARE @CloseTime TIME
		DECLARE @Duration INT
		DECLARE @OpenTimeAux TIME
		DECLARE @CloseTimeAux TIME
		DECLARE @StartDateAux DATETIME
	END -- Fin bloque declaración de variables SP
	-- BLOQUE PRINCIPAL
	BEGIN		
		BEGIN -- Bloque para validar la existencia del identificador del servicio
			BEGIN TRY -- Control de ejecución de bloque 
				SET @Existence = (SELECT COUNT(1) FROM develop.Services WHERE Service_Id = @ServiceId)
				IF @Existence = 0
				BEGIN 
					SET @Message = 'No existe el identificador del servicio'
				END						
			END TRY  
			BEGIN CATCH
				SET @Message = 'Ocurrió un error consultando el identificador del servicio'
			END CATCH
		END -- Fin bloque validar la existencia del identificador del servicio
		BEGIN -- Bloque para consultar la hora de apertura, la hora de cierre y la duración del servicio
			BEGIN TRY -- Control de ejecución de bloque 
				SELECT @OpeningTime = Opening_Time,
					   @OpenTimeAux = Opening_Time,
					   @CloseTime = Close_Time,					   
					   @Duration = Duration,
					   @CloseTimeAux = Close_Time
				FROM develop.Services  
				WHERE Service_Id = @ServiceId				
			END TRY  
			BEGIN CATCH
				SET @Message = 'Ocurrió un error consultando la hora de apertura, la hora de cierre y la duración del servicio'
			END CATCH
		END -- Fin bloque para consultar la hora de apertura, la hora de cierre y la duración del servicio
		BEGIN			
			BEGIN TRY -- Control de ejecución de bloque
				--SET @StartDateAux = @StartDate				
				--WHILE (@StartDate <= @EndDate AND @CloseTimeAux <= @CloseTime)
				--BEGIN
				--	IF @CloseTimeAux <= @CloseTime
				--	BEGIN
				--		INSERT INTO develop.Shifts (service_id, Shift_Date, Start_Time, End_Time)
				--		VALUES (@ServiceId,@StartDate,@EndTime,@EndTime)
				--	END					
				--END				
				SET @Message = 'Solicitud de reserva realizada satisfactoriamente'
			END TRY  
			BEGIN CATCH
				SET @Message = 'Ocurrió un error registrando la reserva'
			END CATCH
		END 
	END
GO