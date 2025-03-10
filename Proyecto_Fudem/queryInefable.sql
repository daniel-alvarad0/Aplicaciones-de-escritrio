	use master
create database BD_Inefable_POO
use BD_Inefable_POO


create table proveedor(
id_proveedor int identity(1,1) not null,
nombre_proveedor varchar(70) not null,
direccion varchar(70),
telefono_proveedor int,
correo_electronico varchar(70),
contacto varchar(70),
telefono_contacto int
constraint pk_proveedor primary key(id_proveedor)
)

create table empleado(
id_empleado int identity(1,1) not null,
nombre_empleado varchar(40),
apellidos varchar(40),
telefono_1 varchar(50),
telefono_2 varchar(50),
fecha_nacimiento varchar(70),
correo_electronico varchar(70),
direccion varchar(70),
dui varchar(70),
nit varchar(70),
AFP varchar(70),
Num_AFP bigint,
ISSS int,
usuario varchar(40),
contraseña varchar(40)
constraint pk_empleado primary key(id_empleado)
)

create table cliente(
id_cliente int identity(1,1) not null,
nombre_cliente varchar(40) not null,
apellidos varchar(40) not null,
num_telefono int,
direccion varchar(40),
dui varchar(70),
nit varchar(70),
correo_electronico varchar(70),
fecha_afiliacion varchar(70)
constraint pk_cliente primary key(id_cliente)
)

create table producto(
id_producto int identity(1,1) not null,
id_proveedor int not null,
id_empleado int not null,
nombre_producto varchar(50) not null,
precio_compra decimal(18,2),
precio_venta decimal(18,2),
descripcion varchar(70),
fecha_producto datetime NULL DEFAULT (sysdatetime()),
tipo varchar(50) NULL
constraint pk_producto primary key(id_producto)
constraint fk_proveedor foreign key(id_proveedor) references proveedor(id_proveedor),
constraint fk_empleado foreign key(id_empleado) references empleado(id_empleado)
on delete cascade
on update cascade
)

create table inventario(
id_inventario int identity(1,1) not null,
producto int not null,
cantidad int not null,
Fecha_inventario datetime NULL DEFAULT (sysdatetime()),
tipo varchar(50) NULL
constraint pk_inventario primary key(id_inventario)
constraint fk_producto foreign key(producto) references producto(id_producto)
)

create table detalle_factura(
id_detalle int identity(1,1) not null,
id_producto int not null,
cantidad int not null,
factura int not null,
precio decimal(18,2)
constraint pk_detalle primary key(id_detalle)
constraint fk_id_producto foreign key(id_producto) references producto(id_producto)
)

create table factura(
id_factura int identity(1,1) not null,
num_factura int not null,
id_cliente int not null,
id_empleado int not null,
fecha_facturacion datetime NULL DEFAULT (sysdatetime()),
metodoPago varchar(40),
total decimal(18,2),
sub_total decimal(18,2),
IVA decimal(18,2),
descuento decimal(18,2)
constraint pk_factura primary key(id_factura)
constraint fk_id_empleado foreign key(id_empleado) references empleado(id_empleado),
constraint fk_id_cliente foreign key(id_cliente) references cliente(id_cliente)
)

use BD_Inefable_POO
drop database BD_Inefable_POO
select * from cliente
select * from empleado
select * from proveedor
select * from producto
select * from inventario
select * from factura
select * from detalle_factura
