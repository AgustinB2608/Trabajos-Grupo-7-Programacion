CREATE DATABASE Clinica
ON
	(NAME = Clinica_dat,
	FILENAME = 'C:\clinica\clinica.mdf'
)
GO

USE Clinica
GO

CREATE TABLE Administradores(
    Legajo_AD CHAR(4) NOT NULL,
    Nombre_AD VARCHAR(15) NOT NULL,
    Apellido_AD VARCHAR(15) NOT NULL,
    Contraseña_AD VARCHAR(15) NOT NULL,
    CONSTRAINT PK_ADMINISTRADORES PRIMARY KEY (Legajo_AD)
);
--

CREATE TABLE Provincias (
    CodProvincia_PR CHAR(4) NOT NULL ,
    Descripcion_PR VARCHAR(50) NOT NULL,
	CONSTRAINT PK_PROVINCIAS PRIMARY KEY(CodProvincia_PR)
);
--

CREATE TABLE Localidades (
	CodLocalidad_LO CHAR(4) NOT NULL,
    CodProvincia_LO CHAR(4) NOT NULL,
    Descripcion_LO VARCHAR(50) NOT NULL,
	CONSTRAINT PK_LOCALIDADES PRIMARY KEY(CodLocalidad_LO),
    CONSTRAINT FK_LOCALIDADES_PROVINCIAS FOREIGN KEY (CodProvincia_LO) REFERENCES Provincias(CodProvincia_PR)
);
--

CREATE TABLE Especialidades(
    CodEspecialidad_ES CHAR(4) NOT NULL,
    Descripcion_ES VARCHAR(50)
    CONSTRAINT PK_ESPECIALIDADES PRIMARY KEY (CodEspecialidad_ES)
);
--

CREATE TABLE DiasAtencion (
    CodAtencion_DA CHAR(4) NOT NULL,
    Descripcion_DA VARCHAR(50) NOT NULL,
	CONSTRAINT PK_DiasAtencion PRIMARY KEY(CodAtencion_DA)
);

CREATE TABLE HorariosAtencion (
    CodHorariosAtencion_HA CHAR(4) NOT NULL,
    Descripcion_HA VARCHAR(50) NOT NULL,
	CONSTRAINT PK_HorariosAtencion PRIMARY KEY(CodHorariosAtencion_HA)
);
--

CREATE TABLE Pacientes(
	CodPaciente_PA CHAR(4) NOT NULL,
	CodProvincia_PA CHAR(4) NOT NULL,
	CodLocalidad_PA CHAR(4) NOT NULL,
	Dni_PA CHAR(8) NOT NULL,
	Nombre_PA CHAR(50) NOT NULL,
	Apellido_PA CHAR(50) NOT NULL,
	FechaNacimiento_PA DATE NOT NULL,
	Nacionalidad_PA VARCHAR(50) NOT NULL,
	Direccion_PA VARCHAR(50) NOT NULL,
	Email_PA  VARCHAR(50) NOT NULL,
	Sexo_PA CHAR(1) CHECK (Sexo_PA IN ('M', 'F', 'O')) NOT NULL,
	Telefono_PA VARCHAR(15) NOT NULL,
	Estado_PA BIT DEFAULT 1 NOT NULL,
	CONSTRAINT PK_PACIENTEs PRIMARY KEY (CodPaciente_PA),
	CONSTRAINT UK_PACIENTES UNIQUE (Dni_PA),
	CONSTRAINT FK_PACIENTES_PROVINCIAS FOREIGN KEY (CodProvincia_PA) REFERENCES Provincias (CodProvincia_PR),
	CONSTRAINT FK_PACIENTES_LOCALIDADES FOREIGN KEY (CodLocalidad_PA) REFERENCES Localidades (CodLocalidad_LO)
);


CREATE TABLE Medicos(
	CodMedico_ME CHAR(4) NOT NULL,
	CodProvincia_ME CHAR(4) NOT NULL,
	CodLocalidad_ME CHAR(4) NOT NULL,
	CodEspecialidad_ME CHAR(4) NOT NULL,
	CodDiasAtencion_ME CHAR(4) NOT NULL,
	CodHorariosAtencion_ME CHAR(4) NOT NULL,
	Dni_ME CHAR(8) NOT NULL,
	Nombre_ME VARCHAR(50) NOT NULL,
	Apellido_ME VARCHAR(50) NOT NULL,
	Sexo_ME CHAR(1) NOT NULL,
	Nacionalidad_ME VARCHAR(50) NOT NULL,
	FechaNacimiento_ME DATE NOT NULL,
	Direccion_ME VARCHAR(50) NOT NULL,
	Email_ME VARCHAR(50) NOT NULL,
	Telefono_ME VARCHAR(50) NOT NULL,
	Usuario_ME VARCHAR(20) NOT NULL,
	Contraseña_ME VARCHAR(20) NOT NULL,
	Estado_ME BIT DEFAULT 1 NOT NULL,
	CONSTRAINT PK_MEDICOS PRIMARY KEY(CodMedico_ME),
	CONSTRAINT FK_MEDICOS_PROVINCIAS FOREIGN KEY (CodProvincia_ME) REFERENCES Provincias (CodProvincia_PR),
    CONSTRAINT FK_MEDICOS_LOCALIDADES FOREIGN KEY (CodLocalidad_ME) REFERENCES Localidades (CodLocalidad_LO),
	CONSTRAINT FK_MEDICOS_ESPECIALIDADES FOREIGN KEY (CodEspecialidad_ME) REFERENCES Especialidades (CodEspecialidad_ES),
	CONSTRAINT UK_MEDICPS UNIQUE (Usuario_ME),
);
--

CREATE TABLE Turnos(
	CodTurno_TU CHAR(4) NOT NULL,
	CodEspecialidades_TU CHAR(4) NOT NULL,
	CodMedico_TU CHAR(4) NOT NULL,
	CodPaciente_TU CHAR(4) NOT NULL,
	Dia_TU DATE NOT NULL,
	Horario_TU TIME NOT NULL,
	CodEstadoTurno_TU char(1) CHECK (CodEstadoTurno_TU IN ('C', 'P', 'S')) NOT NULL,
	CONSTRAINT PK_TURNOS PRIMARY KEY (CodTurno_TU),
	CONSTRAINT FK_TURNOS_PACIENTE FOREIGN KEY (CodPaciente_TU) REFERENCES Pacientes (CodPaciente_PA),
	CONSTRAINT FK_TURNOS_MEDICO FOREIGN KEY (CodMedico_TU) REFERENCES Medicos (CodMedico_ME)
	
);
GO

CREATE TABLE Informes(
    CodInforme_IN CHAR(4) NOT NULL,
	CodPaciente_IN CHAR(4) NOT NULL,
    FechaCreacion_IN DATE NOT NULL,
    Descripcion_IN VARCHAR(200) NOT NULL,
    CONSTRAINT PK_INFORMES PRIMARY KEY (CodInforme_IN),
	CONSTRAINT FK_INFORMES_PACIENTES FOREIGN KEY (CodPaciente_IN) REFERENCES Pacientes (CodPaciente_PA)
);
GO

CREATE PROCEDURE SP_bajaMedico
@CodMedico CHAR(4)
AS
UPDATE Medicos SET Estado_ME = 0
WHERE CodMedico_ME = @CodMedico
GO

CREATE PROCEDURE SP_bajaPaciente
@CODPaciente CHAR(4)
AS
UPDATE Pacientes SET Estado_PA = 0
WHERE CodPaciente_PA = @CODPaciente
GO

CREATE TRIGGER TR_EliminarMedico
ON Medicos
AFTER DELETE
AS BEGIN
 DECLARE @CODMEDICO CHAR(4)
 SELECT @CODMEDICO = CodMedico_ME FROM deleted
 EXECUTE SP_bajaMedico @CODMEDICO
END
GO

CREATE TRIGGER TR_EliminarPaciente
ON Pacientes
AFTER DELETE
AS BEGIN
 DECLARE @CODPACIENTE CHAR(4)
 SELECT @CODPACIENTE = CodPaciente_PA FROM deleted
 EXECUTE SP_bajaPaciente @CODPACIENTE
END
GO

--

CREATE PROCEDURE SP_modificarPaciente
	@CodPaciente CHAR(4), 
    @Dni CHAR(8), 
    @Direccion VARCHAR(50), 
    @Localidad CHAR(4), 
    @Provincia CHAR(4), 
    @Email VARCHAR(50), 
    @Telefono VARCHAR(15)
AS
BEGIN
    -- Actualizar datos del paciente si está activo
    UPDATE Pacientes
    SET 
        Dni_PA = @Dni,
        Direccion_PA = @Direccion,
        CodLocalidad_PA = @Localidad,
        CodProvincia_PA = @Provincia,
        Email_PA = @Email,
        Telefono_PA = @Telefono
    WHERE CodPaciente_PA = @CodPaciente AND Estado_PA = 1;

    -- Confirmar cambios
    PRINT 'Paciente actualizado correctamente.'
END;
GO

SELECT CodPaciente_PA AS CodPaciente, Dni_PA AS Dni, Nombre_PA AS Nombre, Apellido_PA AS Apellido, FechaNacimiento_PA AS 'Fecha de Nacimiento',
Direccion_PA AS Direccion, CodLocalidad_PA AS Localidad, CodProvincia_PA AS Provincia, Email_PA AS Email, Telefono_PA AS Telefono
FROM Pacientes
WHERE Estado_PA = 1
GO

--

CREATE PROCEDURE SP_retornarRegistroPacienteCod
@CodPaciente CHAR(4)
AS BEGIN
SELECT 
        CodPaciente_PA AS CodPaciente, 
        Dni_PA AS Dni, 
        Nombre_PA AS Nombre, 
        Apellido_PA AS Apellido, 
        FechaNacimiento_PA AS 'Fecha de Nacimiento',
        Direccion_PA AS Direccion, 
        Localidades.Descripcion_LO AS Localidad, 
        Provincias.Descripcion_PR AS Provincia, 
        Email_PA AS Email, 
        Telefono_PA AS Telefono,
        Sexo_PA AS Sexo
    FROM 
        Pacientes
    JOIN 
        Localidades ON Pacientes.CodLocalidad_PA = Localidades.CodLocalidad_LO
    JOIN 
        Provincias ON Pacientes.CodProvincia_PA = Provincias.CodProvincia_PR
    WHERE 
        CodPaciente_PA = @CodPaciente AND Estado_PA = 1;
END
GO

--

CREATE PROCEDURE SP_retornarRegistroPacienteDni
@Dni CHAR(8)
AS
BEGIN
SELECT 
  CodPaciente_PA AS CodPaciente, 
        Dni_PA AS Dni, 
        Nombre_PA AS Nombre, 
        Apellido_PA AS Apellido, 
        FechaNacimiento_PA AS 'Fecha de Nacimiento',
        Direccion_PA AS Direccion, 
        Localidades.Descripcion_LO AS Localidad, 
        Provincias.Descripcion_PR AS Provincia, 
        Email_PA AS Email, 
        Telefono_PA AS Telefono,
        Sexo_PA AS Sexo
    FROM 
        Pacientes
    JOIN 
        Localidades ON Pacientes.CodLocalidad_PA = Localidades.CodLocalidad_LO
    JOIN 
        Provincias ON Pacientes.CodProvincia_PA = Provincias.CodProvincia_PR
    WHERE 
        Dni_PA = @Dni AND Estado_PA = 1;
END
GO

CREATE PROCEDURE SP_bajaPacienteDni
@Dni CHAR(8)
AS
   UPDATE Pacientes
    SET Estado_PA = 0
    WHERE Dni_PA = @Dni;
GO

--

CREATE OR ALTER PROCEDURE SP_modificarMedico
	@Legajo CHAR(4), 
    @Nombre VARCHAR(50), 
    @Apellido VARCHAR(50),
	@Sexo CHAR(1), 
    @Nacionalidad VARCHAR(50), 
    @FechaNacimiento DATE,
	@Direccion VARCHAR(50), 
    @CodLocalidad CHAR(4), 
    @CodProvincia CHAR(4),
	@Email VARCHAR(50), 
    @Telefono VARCHAR(15), 
    @CodEspecialidad CHAR(4),
	@CodDiasAtencion CHAR(4), 
    @CodHorarioAtencion CHAR(4), 
    @Usuario VARCHAR(20), 
    @Contraseña VARCHAR(20)
AS
BEGIN
    UPDATE Medicos
    SET 
        Nombre_ME = @Nombre,
        Apellido_ME = @Apellido,
        Sexo_ME = @Sexo,
        Nacionalidad_ME = @Nacionalidad,
        FechaNacimiento_ME = @FechaNacimiento,
        Direccion_ME = @Direccion,
        CodLocalidad_ME = @CodLocalidad,
        CodProvincia_ME = @CodProvincia,
        Email_ME = @Email,
        Telefono_ME = @Telefono,
        CodEspecialidad_ME = @CodEspecialidad,
        CodDiasAtencion_ME = @CodDiasAtencion,
        CodHorariosAtencion_ME = @CodHorarioAtencion,
        Usuario_ME = @Usuario,
        Contraseña_ME = @Contraseña
    WHERE CodMedico_ME = @Legajo;
END
GO

SELECT CodMedico_ME, Dni_ME, Nombre_ME, Apellido_ME, Sexo_ME, Nacionalidad_ME, 
FechaNacimiento_ME, Direccion_ME, CodLocalidad_ME, CodProvincia_ME, Email_ME, Telefono_ME, 
descripcion_ES AS 'Nombre Especialidad', CodDiasAtencion_ME, CodHorariosAtencion_ME AS 'Horarios de Atención'
FROM Medicos INNER JOIN Especialidades 
ON (CodEspecialidad_ME = CodEspecialidad_ES)
WHERE Estado_ME = 1
GO

CREATE PROCEDURE SP_retornarRegistroMedico
@CodMedico varchar(10)
AS
BEGIN
SELECT CodMedico_ME AS CodigoMedico, Dni_ME AS Dni, Nombre_ME AS Nombre, Apellido_ME AS Apellido,
Sexo_ME AS Sexo, Nacionalidad_ME AS Nacionalidad, FechaNacimiento_ME AS 'Fecha de Nacimiento',
Direccion_ME AS Direccion, CodLocalidad_ME AS Localidad, CodProvincia_ME AS Provincia, Email_ME AS Email,
CodEspecialidad_ME AS CodigoEspecialidad, descripcion_ES AS 'Nombre Especialidad',
CodDiasAtencion_ME AS 'Dias de Atención', CodHorariosAtencion_ME AS 'Horarios de Atención' 
FROM Medicos INNER JOIN Especialidades
ON (CodEspecialidad_ME = CodEspecialidad_ES) 
WHERE CodMedico_ME = @CodMedico AND Estado_ME = 1
END
GO
---SI QUIERE MOSTRAR DESCRIPCION DIAS FALTA INNER JOIN