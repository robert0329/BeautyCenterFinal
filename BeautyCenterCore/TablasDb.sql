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
SueldoFijo float
);

create table CitasDetalles(
Id  int identity(1,1)not null primary key,
CitaId int,
ClienteId int ,
ServicioId int,
EmpleadoId int 
);

create table FacturaDetalles(
Id int identity(1,1)not null primary key,
FacturaId int ,
ClienteId int,
ServicioId int, 
Precio    float,
Descuento float,
Cantidad  int,
SubTotal  float 
);

create table Facturas (
FacturaId int identity(1,1)not null primary key,
Cliente varchar(200),
Fecha datetime ,
Total float,
);

create table Servicios(
ServicioId int identity(1,1)not null primary key,
Nombre varchar(100),
Precio float,
);

create table Usuarios(
UsuarioId int identity(1,1) not null,
Nombre varchar(50),
Apellido varchar(100),
Email varchar(100),
NombreUsuario varchar(25),
Contraseña varchar(20),
ConfirmContraseña varchar(20)
);
