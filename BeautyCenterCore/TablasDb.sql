create table Citas (
CitaId int identity(1, 1)not null primary key,
ClienteId  int,
Nombres   varchar(100),
ServicioId int,
Servicio  varchar(100) ,
EmpleadoId int,
NombreE varchar(100),
Fecha datetime
);

create table Clientes (
ClienteId int identity(1, 1)not null primary key,
Nombres   varchar(150),
Provincia varchar(100),
Ciudad    varchar(100),
Direccion varchar(300),
Cedula  varchar(25) ,
Telefono varchar(15) ,
FechaNac datetime
);

create table Empleados(
EmpleadoId int identity(1, 1)not null primary key,
Nombres   varchar(150),
Provincia varchar(100),
Ciudad    varchar(100),
Direccion varchar(300),
Cedula  varchar(25) ,
Telefono varchar(15) ,
FechaNac datetime,
SueldoFijo decimal
);

create table DetalleCitas(
Id  int identity(1,1)not null primary key,
CitaId int,
ClienteId int ,
ServicioId int,
EmpleadoId int 
);

create table FacturaDetalles(
Id int identity(1,1)not null primary key,
FacturaId int ,
ServicioId varchar(25),
Costo      float(53),
Descuento  float(53),
SubTotal  float(53)  
);

create table Facturas (
FacturaId int identity(1,1)not null primary key,
ClienteId int foreign key references Clientes,
Fecha datetime ,
Total decimal(18),
);

create table Servicios(
ServicioId int identity(1,1)not null primary key,
Nombre varchar(100),
Costo decimal(18) ,
);

