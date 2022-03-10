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