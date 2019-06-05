/* ---------------------------------------------------- */
/*  Script del Modelo de Datos de la Solución   		*/
/* ---------------------------------------------------- */

/* Drop Foreign Key Constraints */

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Actividades_EstadoActividad]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Actividades] DROP CONSTRAINT [FK_Actividades_EstadoActividad]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_ActividadesEquipo_Actividades]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [ActividadesEquipo] DROP CONSTRAINT [FK_ActividadesEquipo_Actividades]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_ActividadesEquipo_Equipos]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [ActividadesEquipo] DROP CONSTRAINT [FK_ActividadesEquipo_Equipos]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_ActividadesProyecto_Proyectos]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [ActividadesProyecto] DROP CONSTRAINT [FK_ActividadesProyecto_Proyectos]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_EquiposProyecto_Equipos]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [EquiposProyecto] DROP CONSTRAINT [FK_EquiposProyecto_Equipos]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_EquiposProyecto_Proyectos]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [EquiposProyecto] DROP CONSTRAINT [FK_EquiposProyecto_Proyectos]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Integrantes_TiposDocumento]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Integrantes] DROP CONSTRAINT [FK_Integrantes_TiposDocumento]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_IntegrantesEquipo_Equipos]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [IntegrantesEquipo] DROP CONSTRAINT [FK_IntegrantesEquipo_Equipos]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_IntegrantesEquipo_Integrantes]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [IntegrantesEquipo] DROP CONSTRAINT [FK_IntegrantesEquipo_Integrantes]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_IntegrantesProyecto_Integrantes]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [IntegrantesProyecto] DROP CONSTRAINT [FK_IntegrantesProyecto_Integrantes]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_IntegrantesProyecto_Proyectos]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [IntegrantesProyecto] DROP CONSTRAINT [FK_IntegrantesProyecto_Proyectos]
GO

/* Drop Tables */

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Actividades]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Actividades]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[ActividadesEquipo]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [ActividadesEquipo]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[ActividadesProyecto]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [ActividadesProyecto]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Equipos]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Equipos]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[EquiposProyecto]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [EquiposProyecto]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[EstadoActividad]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [EstadoActividad]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Integrantes]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Integrantes]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[IntegrantesEquipo]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [IntegrantesEquipo]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[IntegrantesProyecto]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [IntegrantesProyecto]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Proyectos]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Proyectos]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[TiposDocumento]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [TiposDocumento]
GO

/* Create Tables */

CREATE TABLE [Actividades]
(
	[idActividad] int NOT NULL IDENTITY (1, 1),
	[nombreActividad] varchar(50) NOT NULL,
	[descripcionActividad] varchar(max) NULL,
	[fechaInicio] datetime NOT NULL,
	[fechaFin] datetime NULL,
	[idEstadoActividad] int NULL
)
GO

CREATE TABLE [ActividadesEquipo]
(
	[idActividadEquipo] int NOT NULL IDENTITY (1, 1),
	[idEquipo] int NULL,
	[idActividad] int NULL
)
GO

CREATE TABLE [ActividadesProyecto]
(
	[idActividadProyecto] int NOT NULL IDENTITY (1, 1),
	[idProyecto] int NULL
)
GO

CREATE TABLE [Equipos]
(
	[idEquipo] int NOT NULL IDENTITY (1, 1),
	[nombreEquipo] varchar(50) NOT NULL,
	[descripcionEquipo] varchar(max) NULL,
	[logoEquipo] varchar(max) NULL
)
GO

CREATE TABLE [EquiposProyecto]
(
	[idEquipoProyecto] int NOT NULL IDENTITY (1, 1),
	[idEquipo] int NULL,
	[idProyecto] int NULL
)
GO

CREATE TABLE [EstadoActividad]
(
	[idEstadoActividad] int NOT NULL IDENTITY (1, 1),
	[nombreEstado] varchar(50) NOT NULL
)
GO

CREATE TABLE [Integrantes]
(
	[idIntegrante] int NOT NULL IDENTITY (1, 1),
	[numeroDocumento] varchar(50) NOT NULL,
	[primerNombre] varchar(50) NOT NULL,
	[segundoNombre] varchar(50) NULL,
	[primerApellido] varchar(50) NOT NULL,
	[segundoApellido] varchar(50) NULL,
	[fechaNacimiento] datetime NULL,
	[idTipoDocumento] int NULL
)
GO

CREATE TABLE [IntegrantesEquipo]
(
	[idIntegranteEquipo] int NOT NULL IDENTITY (1, 1),
	[idIntegrante] int NULL,
	[idEquipo] int NULL
)
GO

CREATE TABLE [IntegrantesProyecto]
(
	[idIntegranteProyecto] int NOT NULL IDENTITY (1, 1),
	[idIntegrante] int NULL,
	[idProyecto] int NULL
)
GO

CREATE TABLE [Proyectos]
(
	[idProyecto] int NOT NULL IDENTITY (1, 1),
	[nombreProyecto] varchar(50) NOT NULL,
	[descripcionProyecto] varchar(200) NULL,
	[logoProyecto] varchar(max) NULL
)
GO

CREATE TABLE [TiposDocumento]
(
	[idTipoDocumento] int NOT NULL IDENTITY (1, 1),
	[nombreTipo] varchar(50) NOT NULL,
	[acronimoTipo] varchar(50) NOT NULL
)
GO

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [Actividades] 
 ADD CONSTRAINT [PK_Actividades]
	PRIMARY KEY CLUSTERED ([idActividad] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Actividades_EstadoActividad] 
 ON [Actividades] ([idEstadoActividad] ASC)
GO

ALTER TABLE [ActividadesEquipo] 
 ADD CONSTRAINT [PK_ActividadesEquipo]
	PRIMARY KEY CLUSTERED ([idActividadEquipo] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_ActividadesEquipo_Actividades] 
 ON [ActividadesEquipo] ([idActividad] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_ActividadesEquipo_Equipos] 
 ON [ActividadesEquipo] ([idEquipo] ASC)
GO

ALTER TABLE [ActividadesProyecto] 
 ADD CONSTRAINT [PK_ActividadesProyecto]
	PRIMARY KEY CLUSTERED ([idActividadProyecto] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_ActividadesProyecto_Proyectos] 
 ON [ActividadesProyecto] ([idProyecto] ASC)
GO

ALTER TABLE [Equipos] 
 ADD CONSTRAINT [PK_Equipos]
	PRIMARY KEY CLUSTERED ([idEquipo] ASC)
GO

ALTER TABLE [EquiposProyecto] 
 ADD CONSTRAINT [PK_EquiposProyecto]
	PRIMARY KEY CLUSTERED ([idEquipoProyecto] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_EquiposProyecto_Equipos] 
 ON [EquiposProyecto] ([idEquipo] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_EquiposProyecto_Proyectos] 
 ON [EquiposProyecto] ([idProyecto] ASC)
GO

ALTER TABLE [EstadoActividad] 
 ADD CONSTRAINT [PK_EstadoActividad]
	PRIMARY KEY CLUSTERED ([idEstadoActividad] ASC)
GO

ALTER TABLE [Integrantes] 
 ADD CONSTRAINT [PK_Integrantes]
	PRIMARY KEY CLUSTERED ([idIntegrante] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Integrantes_TiposDocumento] 
 ON [Integrantes] ([idTipoDocumento] ASC)
GO

ALTER TABLE [IntegrantesEquipo] 
 ADD CONSTRAINT [PK_IntegrantesEquipo]
	PRIMARY KEY CLUSTERED ([idIntegranteEquipo] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_IntegrantesEquipo_Equipos] 
 ON [IntegrantesEquipo] ([idEquipo] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_IntegrantesEquipo_Integrantes] 
 ON [IntegrantesEquipo] ([idIntegrante] ASC)
GO

ALTER TABLE [IntegrantesProyecto] 
 ADD CONSTRAINT [PK_IntegrantesProyecto]
	PRIMARY KEY CLUSTERED ([idIntegranteProyecto] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_IntegrantesProyecto_Integrantes] 
 ON [IntegrantesProyecto] ([idIntegrante] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_IntegrantesProyecto_Proyectos] 
 ON [IntegrantesProyecto] ([idProyecto] ASC)
GO

ALTER TABLE [Proyectos] 
 ADD CONSTRAINT [PK_Proyectos]
	PRIMARY KEY CLUSTERED ([idProyecto] ASC)
GO

ALTER TABLE [TiposDocumento] 
 ADD CONSTRAINT [PK_TiposDocumento]
	PRIMARY KEY CLUSTERED ([idTipoDocumento] ASC)
GO

/* Create Foreign Key Constraints */

ALTER TABLE [Actividades] ADD CONSTRAINT [FK_Actividades_EstadoActividad]
	FOREIGN KEY ([idEstadoActividad]) REFERENCES [EstadoActividad] ([idEstadoActividad]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [ActividadesEquipo] ADD CONSTRAINT [FK_ActividadesEquipo_Actividades]
	FOREIGN KEY ([idActividad]) REFERENCES [Actividades] ([idActividad]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [ActividadesEquipo] ADD CONSTRAINT [FK_ActividadesEquipo_Equipos]
	FOREIGN KEY ([idEquipo]) REFERENCES [Equipos] ([idEquipo]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [ActividadesProyecto] ADD CONSTRAINT [FK_ActividadesProyecto_Proyectos]
	FOREIGN KEY ([idProyecto]) REFERENCES [Proyectos] ([idProyecto]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [EquiposProyecto] ADD CONSTRAINT [FK_EquiposProyecto_Equipos]
	FOREIGN KEY ([idEquipo]) REFERENCES [Equipos] ([idEquipo]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [EquiposProyecto] ADD CONSTRAINT [FK_EquiposProyecto_Proyectos]
	FOREIGN KEY ([idProyecto]) REFERENCES [Proyectos] ([idProyecto]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Integrantes] ADD CONSTRAINT [FK_Integrantes_TiposDocumento]
	FOREIGN KEY ([idTipoDocumento]) REFERENCES [TiposDocumento] ([idTipoDocumento]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [IntegrantesEquipo] ADD CONSTRAINT [FK_IntegrantesEquipo_Equipos]
	FOREIGN KEY ([idEquipo]) REFERENCES [Equipos] ([idEquipo]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [IntegrantesEquipo] ADD CONSTRAINT [FK_IntegrantesEquipo_Integrantes]
	FOREIGN KEY ([idIntegrante]) REFERENCES [Integrantes] ([idIntegrante]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [IntegrantesProyecto] ADD CONSTRAINT [FK_IntegrantesProyecto_Integrantes]
	FOREIGN KEY ([idIntegrante]) REFERENCES [Integrantes] ([idIntegrante]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [IntegrantesProyecto] ADD CONSTRAINT [FK_IntegrantesProyecto_Proyectos]
	FOREIGN KEY ([idProyecto]) REFERENCES [Proyectos] ([idProyecto]) ON DELETE No Action ON UPDATE No Action
GO
