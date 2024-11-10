CREATE DATABASE Clinica
ON
	(NAME = Clinica_dat,
	FILENAME = 'C:\.Base de Datos'
)



CREATE TABLE ADMINISTRADOR(
    CodAdmin_AD VARCHAR(10) NOT NULL,
    Nombre_AD VARCHAR(50) NOT NULL,
    Apellido_AD VARCHAR(50) NOT NULL,
    Usuario_AD VARCHAR(20) UNIQUE NOT NULL,
    Contraseña_AD VARCHAR(20) NOT NULL,
    Email_AD VARCHAR(50) NOT NULL,
    Telefono_AD VARCHAR(15),
    CONSTRAINT PK_ADMINISTRADOR PRIMARY KEY (CodAdmin_AD)
);

CREATE TABLE PACIENTE(
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

CREATE TABLE ESPECIALIDAD(
    CodEspecialidad_ES VARCHAR(10) NOT NULL,
    NombreEspecialidad_ES VARCHAR(50) NOT NULL,
    Descripcion_ES VARCHAR(100),
    CONSTRAINT PK_ESPECIALIDAD PRIMARY KEY (CodEspecialidad_ES)
);

CREATE TABLE MEDICOS(
	CodMedicos_ME VARCHAR(10) NOT NULL,
	Legajo_ME INT NOT NULL,
	Dni_ME VARCHAR(11) NOT NULL,
	Nombre_ME VARCHAR(50) NOT NULL,
	Apellido_ME VARCHAR(50) NOT NULL,
	Sexo_ME CHAR(1) NOT NULL,
	Nacionalidad_ME VARCHAR(30) NOT NULL,
	FechaNacimiento_ME DATE NOT NULL,
	Direccion_ME VARCHAR(50) NOT NULL,
	Localidad_ME VARCHAR(50) NOT NULL,
	Provincia_ME VARCHAR(50) NOT NULL,
	Email_ME VARCHAR(50) NOT NULL,
	Telefono_ME VARCHAR(15) NOT NULL,
	CodEspecialidad_ME VARCHAR(10) NOT NULL,
	Dias_ME VARCHAR(20) NOT NULL,
	HorarioAtencion_ME TIME NOT NULL,
	Usuario_ME VARCHAR(20) UNIQUE,
	Contraseña_ME VARCHAR(20),
	CONSTRAINT PK_MEDICOS PRIMARY KEY(CodMedicos_ME),
	CONSTRAINT FK_ESPECIALIDAD_MEDICOS FOREIGN KEY (CodEspecialidad_ME) REFERENCES ESPECIALIDAD(CodEspecialidad_ES)
);


CREATE TABLE TURNOS(
	CodTurno_TU VARCHAR(10) NOT NULL,
	Especialidad_TU VARCHAR(50) NOT NULL,
	Dia_TU DATE NOT NULL,
	Horario_TU TIME NOT NULL,
	Paciente_TU VARCHAR(10) NOT NULL,
	Medico_TU VARCHAR(10) NOT NULL,
	Duracion_TU INT DEFAULT 60 NOT NULL, 
	CONSTRAINT PK_TURNOS PRIMARY KEY (CodTurno_TU),
	CONSTRAINT FK_TURNOS_PACIENTE FOREIGN KEY (Paciente_TU) REFERENCES PACIENTE(CodPaciente_PA),
	CONSTRAINT FK_TURNOS_MEDICO FOREIGN KEY (Medico_TU) REFERENCES MEDICOS(CodMedicos_ME)
);

CREATE TABLE INFORME(
    CodInforme_IN VARCHAR(10) NOT NULL,
    FechaCreacion_IN DATE NOT NULL,
    TipoInforme_IN VARCHAR(50) NOT NULL, -- Ej "Asistencia"
    CONSTRAINT PK_INFORME PRIMARY KEY (CodInforme_IN),
);

CREATE TABLE DETALLE_INFORME(
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

INSERT INTO ADMINISTRADOR(CodAdmin_AD, Nombre_AD,Usuario_AD, Contraseña_AD , Apellido_AD, Email_AD, Telefono_AD)
SELECT 'AD001', 'Carlos', 'Gomez', 'cgomez', 'pass1234', 'carlos.gomez@example.com', '123456789' UNION ALL
SELECT 'AD002', 'Lucia', 'Perez', 'lperez', 'pass1234', 'lucia.perez@example.com', '987654321' UNION ALL
SELECT 'AD003', 'Marta', 'Rodriguez', 'mrodriguez', 'pass1234', 'marta.rodriguez@example.com', '456123789' UNION ALL
SELECT 'AD004', 'Juan', 'Martinez', 'jmartinez', 'pass1234', 'juan.martinez@example.com', '321654987' UNION ALL
SELECT 'AD005', 'Ana', 'Lopez', 'alopez', 'pass1234', 'ana.lopez@example.com', '654987321';

INSERT INTO PACIENTE(CodPaciente_PA, Dni_PA, Nombre_PA, Apellido_PA, FechaNacimiento_PA, Direccion_PA, Localidad_PA, Provincia_PA, Email_PA, Telefono_PA)
SELECT 'PA001', '12345678', 'María', 'Suarez', '1990-05-15', 'Calle 123', 'Buenos Aires', 'Buenos Aires', 'maria.suarez@example.com', '1122334455' UNION ALL
SELECT 'PA002', '87654321', 'José', 'Ramirez', '1985-09-20', 'Av. Siempreviva 742', 'Córdoba', 'Córdoba', 'jose.ramirez@example.com', '2233445566' UNION ALL
SELECT 'PA003', '11223344', 'Luciana', 'Fernandez', '1992-03-10', 'Calle Falsa 123', 'Rosario', 'Santa Fe', 'luciana.fernandez@example.com', '3344556677' UNION ALL
SELECT 'PA004', '44332211', 'Mario', 'Gomez', '1978-11-25', 'Calle Los álamos 456', 'Mendoza', 'Mendoza', 'mario.gomez@example.com', '4455667788' UNION ALL
SELECT 'PA005', '99887766', 'Sofia', 'Lopez', '2000-07-12', 'Calle Las Rosas 789', 'La Plata', 'Buenos Aires', 'sofia.lopez@example.com', '5566778899';

INSERT INTO ESPECIALIDAD (CodEspecialidad_ES, NombreEspecialidad_ES, Descripcion_ES)
VALUES 
    ('ESP001', 'Cardiología', 'Especialidad enfocada en el tratamiento de enfermedades del coraz�n'),
    ('ESP002', 'Pediatría', 'Especialidad enfocada en el tratamiento de niños'),
    ('ESP003', 'Dermatología', 'Especialidad en problemas de la piel'),
    ('ESP004', 'Neurología', 'Estudio y tratamiento del sistema nervioso'),
    ('ESP005', 'Ginecología', 'Atención de la salud femenina');

INSERT INTO MEDICOS (CodMedicos_ME, Legajo_ME, Dni_ME, Nombre_ME, Apellido_ME, Sexo_ME, Nacionalidad_ME, FechaNacimiento_ME, Direccion_ME, Localidad_ME,
                     Provincia_ME, Email_ME, Telefono_ME, CodEspecialidad_ME, Dias_ME, HorarioAtencion_ME, Usuario_ME, Contraseña_ME)
SELECT 'ME001', 1001, '12345678', 'Juan', 'Perez', 'M', 'Argentina', '1980-05-20', 'Calle 1', 'Buenos Aires', 'Buenos Aires', 'juan.perez@example.com', '111222333', 'ESP001', 'Lunes, Mi�rcoles', '09:00', 'jperez', 'password1' UNION ALL
SELECT 'ME002', 1002, '87654321', 'Ana', 'Gomez', 'F', 'Argentina', '1975-10-15', 'Calle 2', 'Córdoba', 'Córdoba', 'ana.gomez@example.com', '222333444', 'ESP003', 'Martes, Jueves', '10:00', 'agomez', 'password2' UNION ALL
SELECT 'ME003', 1003, '11223344', 'Carlos', 'Ramirez', 'M', 'Argentina', '1988-02-25', 'Calle 3', 'Rosario', 'Santa Fe', 'carlos.ramirez@example.com', '333444555', 'ESP002', 'Lunes, Viernes', '08:00', 'cramirez', 'password3' UNION ALL
SELECT 'ME004', 1004, '44332211', 'Maria', 'Lopez', 'F', 'Argentina', '1990-07-08', 'Calle 4', 'Mendoza', 'Mendoza', 'maria.lopez@example.com', '444555666', 'ESP005', 'Mi�rcoles, Viernes', '14:00', 'mlopez', 'password4' UNION ALL
SELECT 'ME005', 1005, '99887766', 'Luis', 'Fernandez', 'M', 'Argentina', '1982-12-30', 'Calle 5', 'La Plata', 'Buenos Aires', 'luis.fernandez@example.com', '555666777', 'ESP004', 'Martes, Jueves', '13:00', 'lfernandez', 'password5';


INSERT INTO TURNOS(CodTurno_TU, Especialidad_TU, Dia_TU, Horario_TU, Paciente_TU, Medico_TU, Duracion_TU)
SELECT 'T001', 'Cardiología', '2024-01-10', '09:00', 'PA001', 'ME001', 140   UNION ALL
SELECT 'T002', 'Neurología', '2024-01-11', '10:00', 'PA002', 'ME002', 95 UNION ALL
SELECT 'T003', 'Pediatría', '2024-01-12', '08:00', 'PA003', 'ME003', 180 UNION ALL
SELECT 'T004', 'Dermatología', '2024-01-13', '14:00', 'PA004', 'ME004', 80 UNION ALL
SELECT 'T005', 'Oftalmología', '2024-01-14', '13:00', 'PA005', 'ME005', 120;

INSERT INTO INFORME(CodInforme_IN, FechaCreacion_IN, TipoInforme_IN)
SELECT 'INF001', '2024-02-01', 'Asistencia' UNION ALL
SELECT 'INF002', '2024-02-02', 'Asistencia' UNION ALL
SELECT 'INF003', '2024-02-03', 'Asistencia' UNION ALL
SELECT 'INF004', '2024-02-04', 'Asistencia' UNION ALL
SELECT 'INF005', '2024-02-05', 'Asistencia';

INSERT INTO DETALLE_INFORME(CodDetalle_DI, CodInforme_IN, FechaTurno_DI, EstadoAsistencia_DI, Paciente_DI, Observacion_DI)
SELECT 'DI001', 'INF001', '2024-01-10', 'Presente', 'PA001', 'Consulta sin novedades' UNION ALL
SELECT 'DI002', 'INF001', '2024-01-11', 'Ausente', 'PA002', NULL UNION ALL
SELECT 'DI003', 'INF002', '2024-01-12', 'Presente', 'PA003', 'Paciente con leve mejoría' UNION ALL
SELECT 'DI004', 'INF003', '2024-01-13', 'Presente', 'PA004', 'Tratamiento aplicado exitosamente' UNION ALL
SELECT 'DI005', 'INF004', '2024-01-14', 'Ausente', 'PA005', NULL;
