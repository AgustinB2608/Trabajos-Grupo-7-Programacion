CREATE DATABASE Clinica
ON
	(NAME = Clinica_dat,
	FILENAME = 'C:\clinica\clinica.mdf'
)
GO

USE Clinica
GO

CREATE TABLE Administrador(
    CodAdmin_AD VARCHAR(10) NOT NULL,
    Nombre_AD VARCHAR(50) NOT NULL,
    Apellido_AD VARCHAR(50) NOT NULL,
    Usuario_AD VARCHAR(20) UNIQUE NOT NULL,
    Contraseña_AD VARCHAR(20) NOT NULL,
    Email_AD VARCHAR(50) NOT NULL,
    Telefono_AD VARCHAR(15),
    CONSTRAINT PK_ADMINISTRADOR PRIMARY KEY (CodAdmin_AD)
)


CREATE TABLE Paciente(
	CodPaciente_PA VARCHAR(10) NOT NULL,
	Dni_PA CHAR(11) NOT NULL,
	Nombre_PA CHAR(50) NOT NULL,
	Apellido_PA CHAR(50) NOT NULL,
	FechaNacimiento_PA DATE NOT NULL,
	Direccion_PA VARCHAR(50) NOT NULL,
	Localidad_PA CHAR(50) NOT NULL,
	Provincia_PA CHAR(50) NOT NULL,
	Email_PA  CHAR(50) NOT NULL,
	Telefono_PA VARCHAR(15) NOT NULL,
	CONSTRAINT PK_PACIENTE PRIMARY KEY (CodPaciente_PA)
)

CREATE TABLE Sexo(
	CodSexo_SX INT NOT NULL,
	DescripcionSexo_SX CHAR(15) NOT NULL,
	CONSTRAINT PK_Sexo PRIMARY KEY (CodSexo_SX)
)

CREATE TABLE Especialidad(
    CodEspecialidad_ES VARCHAR(10) NOT NULL,
    NombreEspecialidad_ES VARCHAR(50) NOT NULL,
    Descripcion_ES VARCHAR(100),
    CONSTRAINT PK_ESPECIALIDAD PRIMARY KEY (CodEspecialidad_ES)
);

CREATE TABLE Provincias (
    CodProvincia_PR INT NOT NULL ,
    Nombre NVARCHAR(100) NOT NULL
	CONSTRAINT PK_CodProvincia_PR PRIMARY KEY(CodProvincia_PR)
);

CREATE TABLE Localidades (
    CodLocalidad_LL INT NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    CodProvincia_LL INT,
	CONSTRAINT PK_Localidades PRIMARY KEY(CodLocalidad_LL),
    CONSTRAINT FK_Localidad_Provincia FOREIGN KEY (CodProvincia_LL) REFERENCES Provincias(CodProvincia_PR)
);

CREATE TABLE DiasAtencion (
    IdDia INT NOT NULL,
    Nombre NVARCHAR(20) NOT NULL,
	CONSTRAINT PK_DiasAtencion PRIMARY KEY(IdDia)
);

CREATE TABLE HorariosAtencion (
    IdHorario INT NOT NULL,
    Hora NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_HorariosAtencion PRIMARY KEY(IdHorario)
);

CREATE TABLE Medicos(
	CodMedicos_ME VARCHAR(10) NOT NULL,
	Legajo_ME INT NOT NULL,
	Dni_ME VARCHAR(11) NOT NULL,
	Nombre_ME VARCHAR(50) NOT NULL,
	Apellido_ME VARCHAR(50) NOT NULL,
	Sexo_ME INT NOT NULL,
	Nacionalidad_ME VARCHAR(30) NOT NULL,
	FechaNacimiento_ME DATE NOT NULL,
	Direccion_ME VARCHAR(50) NOT NULL,
	Localidad_ME INT NOT NULL,
	Provincia_ME INT NOT NULL,
	Email_ME VARCHAR(50) NOT NULL,
	Telefono_ME VARCHAR(15) NOT NULL,
	CodEspecialidad_ME VARCHAR(10) NOT NULL,
	Dias_ME VARCHAR(20) NOT NULL,
	HorarioAtencion_ME TIME NOT NULL,
	Usuario_ME VARCHAR(20) UNIQUE,
	Contraseña_ME VARCHAR(20),
	CONSTRAINT PK_MEDICOS PRIMARY KEY(CodMedicos_ME),
	CONSTRAINT FK_SEXO_MEDICOS FOREIGN KEY (Sexo_ME) REFERENCES Sexo(CodSexo_SX),
	CONSTRAINT FK_PROVINCIA_MEDICOS FOREIGN KEY (Provincia_ME) REFERENCES Provincias(CodProvincia_PR),
    CONSTRAINT FK_LOCALIDAD_MEDICOS FOREIGN KEY (Localidad_ME) REFERENCES Localidades(CodLocalidad_LL),
	CONSTRAINT FK_ESPECIALIDAD_MEDICOS FOREIGN KEY (CodEspecialidad_ME) REFERENCES ESPECIALIDAD(CodEspecialidad_ES),
);

CREATE TABLE Medico_Horarios (
    IdMedico VARCHAR(10),
    IdHorario INT,
    CONSTRAINT PK_Medico_Horarios PRIMARY KEY (IdMedico, IdHorario),
    CONSTRAINT FK_Medico FOREIGN KEY (IdMedico) REFERENCES MEDICOS(CodMedicos_ME),
    CONSTRAINT FK_Horario FOREIGN KEY (IdHorario) REFERENCES HorariosAtencion(IdHorario)
);

--10/11
CREATE TABLE Estado_Turnos (
    CodEstado char(3) not null,
    DescEstado varchar(15) not null,
	CONSTRAINT PK_Estado_Turnos PRIMARY KEY (CodEstado),
	CONSTRAINT UK_TURNOS UNIQUE (DescEstado)
)
GO

DROP TABLE Turnos
GO

CREATE TABLE Turnos(
	CodTurno_TU VARCHAR(10) NOT NULL,
	Especialidad_TU VARCHAR(50) NOT NULL,
	Dia_TU DATE NOT NULL,
	Horario_TU TIME NOT NULL,
	Paciente_TU VARCHAR(10) NOT NULL,
	Medico_TU VARCHAR(10) NOT NULL,
	Duracion_TU INT DEFAULT 60 NOT NULL,
	CodEstadoTurno_TU char(3) NOT NULL,
	CONSTRAINT PK_TURNOS PRIMARY KEY (CodTurno_TU),
	CONSTRAINT FK_TURNOS_PACIENTE FOREIGN KEY (Paciente_TU) REFERENCES PACIENTE(CodPaciente_PA),
	CONSTRAINT FK_TURNOS_MEDICO FOREIGN KEY (Medico_TU) REFERENCES MEDICOS(CodMedicos_ME),
	CONSTRAINT FK_TURNOS_Estado_Turnos FOREIGN KEY (CodEstadoTurno_TU) REFERENCES Estado_Turnos(CodEstado)
	
)
GO

CREATE TABLE Informe(
    CodInforme_IN VARCHAR(10) NOT NULL,
    FechaCreacion_IN DATE NOT NULL,
    TipoInforme_IN VARCHAR(50) NOT NULL, -- Ej "Asistencia"
    CONSTRAINT PK_INFORME PRIMARY KEY (CodInforme_IN),
);

CREATE TABLE Detalle_Informe(
    CodDetalle_DI VARCHAR(10) NOT NULL,
    CodInforme_IN VARCHAR(10) NOT NULL,
    FechaTurno_DI DATE NOT NULL,
    EstadoAsistencia_DI VARCHAR(10) NOT NULL, -- Ej "Presente" o "Ausente"
    Paciente_DI VARCHAR(10) NOT NULL, 
    Observacion_DI VARCHAR(255), -- Observaciones del medico para el paciente en ese turno
    CONSTRAINT PK_DETALLE_INFORME PRIMARY KEY (CodDetalle_DI),
    CONSTRAINT FK_DETALLE_INFORME FOREIGN KEY (CodInforme_IN) REFERENCES INFORME(CodInforme_IN),
    CONSTRAINT FK_DETALLE_PACIENTE FOREIGN KEY (Paciente_DI) REFERENCES PACIENTE(CodPaciente_PA)
);

INSERT INTO Administrador(CodAdmin_AD, Nombre_AD,Usuario_AD, Contraseña_AD , Apellido_AD, Email_AD, Telefono_AD)
SELECT 'AD001', 'Carlos', 'Gomez', 'cgomez', 'pass1234', 'carlos.gomez@example.com', '123456789' UNION ALL
SELECT 'AD002', 'Lucia', 'Perez', 'lperez', 'pass1234', 'lucia.perez@example.com', '987654321' UNION ALL
SELECT 'AD003', 'Marta', 'Rodriguez', 'mrodriguez', 'pass1234', 'marta.rodriguez@example.com', '456123789' UNION ALL
SELECT 'AD004', 'Juan', 'Martinez', 'jmartinez', 'pass1234', 'juan.martinez@example.com', '321654987' UNION ALL
SELECT 'AD005', 'Ana', 'Lopez', 'alopez', 'pass1234', 'ana.lopez@example.com', '654987321';

INSERT INTO Sexo(CodSexo_SX, DescripcionSexo_SX)
SELECT 1, 'Masculino' UNION ALL
SELECT 2, 'Femenino';

INSERT INTO Provincias(CodProvincia_PR, Nombre)
SELECT 1, 'Buenos Aires' UNION ALL
SELECT 2, 'Santa Fe' UNION ALL
SELECT 3, 'Cordoba' UNION ALL
SELECT 4, 'Tucuman' UNION ALL
SELECT 5, 'Entre Rios' UNION ALL
SELECT 6, 'Misiones';

INSERT INTO Localidades(CodLocalidad_LL, Nombre, CodProvincia_LL)
SELECT 1, 'La Plata', 1 UNION ALL
SELECT 2, 'Rosario', 2 UNION ALL
SELECT 3, 'Córdoba Capital', 3 UNION ALL
SELECT 4, 'San Miguel de Tucumán', 4 UNION ALL
SELECT 5, 'Paraná', 5 UNION ALL
SELECT 6, 'Posadas', 6;

INSERT INTO DiasAtencion(IdDia, Nombre)
SELECT 1, 'Lunes' UNION ALL
SELECT 2, 'Martes' UNION ALL
SELECT 3, 'Miercoles' UNION ALL
SELECT 4, 'Jueves' UNION ALL
SELECT 5, 'Viernes' UNION ALL
SELECT 6, 'Sabado' UNION ALL
SELECT 7, 'Domingo';

INSERT INTO HorariosAtencion(IdHorario, Hora)
SELECT 1, '8:00 a  12:00 Hs' UNION ALL
SELECT 2, '12:00 a 16:00 Hs' UNION ALL
SELECT 3, '16:00 a  20:00 Hs' UNION ALL
SELECT 4, '20:00 a  24:00 Hs' UNION ALL
SELECT 5, '08:00 a  20:00 Hs' UNION ALL
SELECT 6, '10:00 a  22:00 Hs';

INSERT INTO Especialidad (CodEspecialidad_ES, NombreEspecialidad_ES, Descripcion_ES)
SELECT 'ESP001', 'Cardiología', 'Especialidad enfocada en el tratamiento de enfermedades del corazón' UNION ALL
SELECT 'ESP002', 'Pediatría', 'Especialidad enfocada en el tratamiento de niños' UNION ALL
SELECT 'ESP003', 'Dermatología', 'Especialidad en problemas de la piel' UNION ALL
SELECT 'ESP004', 'Neurología', 'Estudio y tratamiento del sistema nervioso' UNION ALL
SELECT 'ESP005', 'Ginecología', 'Atención de la salud femenina';

INSERT INTO Informe(CodInforme_IN, FechaCreacion_IN, TipoInforme_IN)
SELECT 'INF001', '2024-02-01', 'Asistencia' UNION ALL
SELECT 'INF002', '2024-02-02', 'Asistencia' UNION ALL
SELECT 'INF003', '2024-02-03', 'Asistencia' UNION ALL
SELECT 'INF004', '2024-02-04', 'Asistencia' UNION ALL
SELECT 'INF005', '2024-02-05', 'Asistencia';



ALTER TABLE Medicos
ADD Estado BIT NULL DEFAULT 0
GO

ALTER TABLE Paciente
ADD Estado BIT NULL DEFAULT 0
GO

ALTER TABLE Turnos
ADD Estado BIT NULL DEFAULT 0
GO

CREATE OR ALTER PROCEDURE SP_bajaMedico
@CodMedico VARCHAR(10)
AS
UPDATE Medicos SET Estado = 0
WHERE CodMedicos_ME = @CodMedico
GO

CREATE PROCEDURE SP_bajaPaciente
@CODPaciente VARCHAR(10)
AS
UPDATE Paciente SET Estado = 0
WHERE CodPaciente_PA = @CODPaciente
GO

CREATE TRIGGER TR_EliminarMedico
ON Medicos
AFTER DELETE
AS BEGIN
 DECLARE @CODMEDICO VARCHAR(10)
 SELECT @CODMEDICO = CodMedicos_ME FROM deleted
 EXECUTE SP_bajaMedico @CODMEDICO
END

CREATE TRIGGER TR_EliminarPaciente
ON Paciente
AFTER DELETE
AS BEGIN
 DECLARE @CODPACIENTE VARCHAR(10)
 SELECT @CODPACIENTE = CodPaciente_PA FROM deleted
 EXECUTE SP_bajaPaciente @CODPACIENTE
END

--10/11
CREATE PROCEDURE SP_modificarPaciente
@Direccion CHAR(50), @Localidad CHAR(50), @Provincia CHAR(50), @Email CHAR(50), 
@Telefono VARCHAR(15), @CodPaciente VARCHAR(10)
AS
BEGIN
UPDATE Paciente SET Direccion_PA = @Direccion, Localidad_PA = @Localidad, 
Provincia_PA = @Provincia, Email_PA = @Email, Telefono_PA = @Telefono
WHERE CodPaciente_PA = @CodPaciente
END
GO

SELECT CodPaciente_PA, Dni_PA, Nombre_PA, Apellido_PA, FechaNacimiento_PA, Direccion_PA, 
Localidad_PA, Provincia_PA, Email_PA, Telefono_PA
FROM Paciente
WHERE Estado = 1
GO

CREATE OR ALTER PROCEDURE SP_retornarRegistroPaciente
@CodPaciente VARCHAR(10)
AS
SELECT CodPaciente_PA, Dni_PA, Nombre_PA, Apellido_PA, FechaNacimiento_PA, Direccion_PA, 
Localidad_PA, Provincia_PA, Email_PA, Telefono_PA
FROM Paciente
WHERE CodPaciente_PA = @CodPaciente AND Estado = 1
GO

--11/11

CREATE OR ALTER PROCEDURE SP_modificarMedico
	@Legajo INT, @Nombre VARCHAR(50), @Apellido VARCHAR(50),
	@Sexo INT, @Nacionalidad VARCHAR(30), @FechaNacimiento DATE,
	@Direccion VARCHAR(50), @Localidad INT, @Provincia INT,
	@Email VARCHAR(50), @Telefono VARCHAR(15), @CodEspecialidad VARCHAR(10),
	@Dias VARCHAR(20), @HorarioAtencion TIME, @Usuario VARCHAR(20), @Contraseña VARCHAR(20)
AS
BEGIN
UPDATE Medicos SET 
	Nombre_ME = @Nombre,
	Apellido_ME = @Apellido,
	Sexo_ME = @Sexo,
	Nacionalidad_ME = @Nacionalidad,
	FechaNacimiento_ME = @FechaNacimiento,
	Direccion_ME = @Direccion,
	Localidad_ME = @Localidad,
	Provincia_ME = @Provincia,
	Email_ME = @Email,
	Telefono_ME = @Telefono,
	CodEspecialidad_ME = @CodEspecialidad,
	Dias_ME = @Dias,
	HorarioAtencion_ME = @HorarioAtencion,
	Usuario_ME = @Usuario,
	Contraseña_ME = @Contraseña
WHERE Legajo_ME = @Legajo
END
GO

SELECT CodMedicos_ME, Legajo_ME, Dni_ME, Nombre_ME, Apellido_ME, Sexo_ME, Nacionalidad_ME, 
FechaNacimiento_ME, Direccion_ME, Localidad_ME, Provincia_ME, Email_ME, Telefono_ME, 
CodEspecialidad_ME, Dias_ME, HorarioAtencion_ME
FROM Medicos 
WHERE Estado = 1
GO

CREATE OR ALTER PROCEDURE SP_retornarRegistroMedico
@CodMedico varchar(10)
AS
BEGIN
SELECT CodMedicos_ME, Legajo_ME, Dni_ME, Nombre_ME, Apellido_ME, Sexo_ME, Nacionalidad_ME, 
FechaNacimiento_ME, Direccion_ME, Localidad_ME, Provincia_ME, Email_ME, Telefono_ME, 
CodEspecialidad_ME, Dias_ME, HorarioAtencion_ME
FROM Medicos
WHERE CodMedicos_ME = @CodMedico AND Estado = 1
END
GO

--12/11
CREATE PROCEDURE SP_bajaPacienteDNI
@DNI CHAR(11)
AS
UPDATE Paciente SET Estado = 0
WHERE Dni_PA = @DNI
GO

--MOD 13/11
CREATE PROCEDURE SP_retornarRegistroPacienteCod
@CodPaciente CHAR(4)
AS

SELECT 
CodPaciente_PA AS CodPaciente, Dni_PA AS Dni, Nombre_PA AS Nombre, Apellido_PA AS Apellido, FechaNacimiento_PA AS 'Fecha de Nacimiento',
Direccion_PA AS Direccion, Localidad_PA AS Localidad, Provincia_PA AS Provincia, Email_PA AS Email, Telefono_PA AS Telefono,
Sexo_PA AS Sexo
FROM Paciente
WHERE CodPaciente_PA = @CodPaciente AND Estado = 1 
GO

CREATE PROCEDURE SP_retornarRegistroPacienteDni
@Dni CHAR(8)
AS
BEGIN
SELECT 
CodPaciente_PA AS CodPaciente, Dni_PA AS Dni, Nombre_PA AS Nombre, Apellido_PA AS Apellido, FechaNacimiento_PA AS 'Fecha de Nacimiento',
Direccion_PA AS Direccion, Localidad_PA AS Localidad, Provincia_PA AS Provincia, Email_PA AS Email, Telefono_PA AS Telefono,
Sexo_PA AS Sexo
FROM Paciente
WHERE Dni_PA = @Dni AND Estado = 1 
END
GO

--16/11

CREATE TABLE Usuarios(
Legajo_US Int identity (1000,1) NOT NULL,
Contraseña_US varchar(20) NOT NULL,
Tipousuariio_US varchar(20)NOT NULL,
Nombre_US varchar(20) NOT NULL,
Apellido_US varchar(20) NOT NULL,
CodAdmin_US varchar(10) NOT NULL,
CodMedicos_US varchar(10) NOT NULL,
CONSTRAINT PK_Usuarios PRIMARY KEY (Legajo_US),
CONSTRAINT FK_Usuarios_Administrador FOREIGN KEY (CodAdmin_US) REFERENCES Administrador(CodAdmin_AD),
CONSTRAINT FK_Usuarios_Medicos FOREIGN KEY (CodMedicos_US) REFERENCES Medicos(CodMedicos_ME)
)
GO