create database AgenciaAutos

use [AgenciaAutos]

create table Autos
(
	AutoId int not null identity(1,1),
	Marca varchar(200),
	Precio decimal(18, 2),
	constraint PK_AutoId Primary key (AutoId)
)

create procedure AltasAutos
(
	@Marca varchar(200),
	@Precio decimal(18, 2)
)
as
	insert into Autos(Marca, Precio) values(@Marca, @Precio)

create procedure BorrarAuto
(
	@AutoId int
)
as
	delete Autos where AutoId = @AutoId

create procedure ObtenerAutos
as
	select AutoId, Marca, Precio from Autos

create procedure ObtenerAutoById
(
	@AutoId int
)
as
	select AutoId, Marca, Precio from Autos
	where AutoId = @AutoId

create procedure ActualizarAuto
(
	@AutoId int,
	@Marca varchar(200),
	@Precio decimal(18, 2)
)
as
	update Autos set Marca = @Marca, Precio = @Precio
	where AutoId = @AutoId