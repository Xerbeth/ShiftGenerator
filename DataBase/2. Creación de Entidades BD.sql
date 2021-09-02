CREATE SCHEMA [develop]
GO

/* Creación de la tabla comercios */
CREATE TABLE develop.Commerces (
    Commerce_Id INT PRIMARY KEY IDENTITY (1, 1),
    Commerce_Name VARCHAR (100) NOT NULL,
	Maximum_Capacity INT NOT NULL,	    
    Registration_Status VARCHAR(20) NOT NULL DEFAULT 'Activo',
	CONSTRAINT Registration_Status_Commerce CHECK (Registration_Status = 'Activo' OR Registration_Status ='Inactivo')
);


/* Creación de la tabla servicios comerciales */
CREATE TABLE develop.Services  (
    Service_Id INT PRIMARY KEY IDENTITY (1, 1),
	Commerce_Id INT NOT NULL,
	Service_Name VARCHAR (50) NOT NULL,
	Opening_Time TIME NOT NULL,	
	Close_Time TIME NOT NULL,
	Duration INT NOT NULL,
    Registration_Status VARCHAR(20) NOT NULL DEFAULT 'Activo',
	CONSTRAINT Registration_Status_Services CHECK (Registration_Status = 'Activo' OR Registration_Status ='Inactivo'),
	FOREIGN KEY (Commerce_Id) REFERENCES develop.Commerces (Commerce_Id),
);

/* Creación de la tabla servicios turnos */
CREATE TABLE develop.Shifts  (
    Shifts_Id INT PRIMARY KEY IDENTITY (1, 1),
	Service_Id INT NOT NULL,
	Shift_Date DATETIME NOT NULL,	
	Start_Time TIME NOT NULL,
	End_Time TIME NOT NULL,
	State VARCHAR(20) NOT NULL DEFAULT 'Creado',
    Registration_Status VARCHAR(20) NOT NULL DEFAULT 'Activo',
	CONSTRAINT State_Shifts CHECK (State = 'Creado' OR State ='Anulado' OR State ='Finalizado' ),
	CONSTRAINT Registration_Status_Shifts CHECK (Registration_Status = 'Activo' OR Registration_Status ='Inactivo'),	
	FOREIGN KEY (Service_Id) REFERENCES develop.Services (Service_Id),
);


INSERT INTO develop.Commerces (Commerce_Name, Maximum_Capacity)
VALUES ('AMAZON',10);
INSERT INTO develop.Services (Commerce_Id, Service_Name, Opening_Time, Close_Time, Duration)
VALUES (1,'CINE','2021-09-02T01:00:00.000Z','2021-09-02T23:00:00.000Z',30)

