create table Citas (
CitaId int identity(1, 1)not null primary key,
ClienteId int not null foreign key references Clientes,
Nombres varchar(100),
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
CitaId int not null foreign key references Citas,
ClienteId int not null foreign key references Clientes,
Precio int,
ServicioId int not null foreign key references Servicios,
Servicio varchar(100)
);

create table FacturaDetalles(
Id int identity(1,1)not null primary key,
FacturaId int not null foreign key references Facturas,
ServicioId int not null foreign key references Servicio, 
Servicios varchar(300),
Precio    float,
Descuento float,
Cantidad  int,
SubTotal  float 
);

create table Facturas (
FacturaId int identity(1,1)not null primary key,
ClienteId int not null foreign key references Clientes,
Clientes varchar(300),
Fecha datetime ,
Total float,
Empleados varchar(300)
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
