create database rinconescuintleco
use rinconescuintleco
go

create table cat_producto
(
id_categoria int primary key,
nombre_cat varchar(50)
);
create table producto
(
id_producto int primary key,
nombre_producto varchar(50),
existencia_procuto int
);
create table cliente
(
id_cliente int primary key,
nombre_cliente varchar(50),
apellido_cliente varchar(50),
direccion_cliente varchar(50),
telefono_cliente int
);
create table proveedor
(
id_proveedor int primary key,
nombre_proveedor varchar(50),
direccion_proveedor varchar(50),
telefono_proveedor int
);
create table catalogo_devolucion
(
id_catdevolucion int primary key,
descripcion varchar(50)
);
create table devoluciones
(
id_devolucion int primary key,
fecha_devolucion date,
cantidad_devolucion int,
);
create table usuario
(
id_usuario int primary key,
contraseña varchar(10),
nombre_usuario varchar(50),
apellido_usuario varchar(50)
);
select *from usuario
create table tarjeta
(
id_tarjeta int primary key,
fecha_vencimiento date,
vcc int,
);
create table enc_factura
(
id_encabezado int primary key,
fecha_encabezado date
);
select *from enc_factura
create table detalle_fact
(
factura int,
producto varchar(50),
precio int,
primary key(factura, producto)
);
create table caja
(
id_caja int primary key,
fecha_caja date,
monto_caja int
);
create table promocion
(
id_promocion int primary key,
descripcion_promocion varchar(50)
);