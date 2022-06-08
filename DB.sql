CREATE TABLE [Personas] (
	Id numeric NOT NULL,
	Nombres varchar NOT NULL,
	Apellido varchar NOT NULL,
	Tipo_Identi varchar NOT NULL,
	No_Ide varchar NOT NULL UNIQUE,
	Email varchar NOT NULL,
	Fecha_crea date NOT NULL,
  CONSTRAINT [PK_PERSONAS] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Usuario] (
	Id numeric NOT NULL,
	Usuario varchar NOT NULL,
	Pass varchar NOT NULL,
	Fecha_crea varchar NOT NULL
)
GO
ALTER TABLE [Usuario] WITH CHECK ADD CONSTRAINT [Usuario_fk0] FOREIGN KEY ([Id]) REFERENCES [Personas]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Usuario] CHECK CONSTRAINT [Usuario_fk0]
GO

/****** Columna calculada nombres y apellidos concatenados  ******/
SELECT [Id],
	[Nombres],
	[Apellido],
	[Tipo_Identi],
	[No_Ide],
	[Email],
	[Fecha_crea],
     CONCAT( [Nombres],' ',[Apellido] ) as Nombre_Completo
FROM
    [dbo].[Personas]
ORDER BY
    Nombre_Completo;
/****** Columna calculada número de identificación con tipo de identificación concatenados  ******/
SELECT
	[Id],
	[Nombres],
	[Apellido],
	[Tipo_Identi],
	[No_Ide],
	[Email],
	[Fecha_crea],
     CONCAT( [Tipo_Identi],' ',[No_Ide]) as Identificacion
FROM
    [dbo].[Personas]
ORDER BY
    Identificacion;