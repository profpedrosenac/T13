-- Comando para criar BD
Create database T13_Ex01

use T13_Ex01

create table usuario
(
	id_usuario int not null identity primary key,
	nome_usuario varchar(50) not null,
	cpf_usuario char(14) not null unique,
	login_usuario varchar(50) not null unique,
	senha_usuario varchar(50) not null, 
	obs_usuario varchar(255) null,
	status_usuario varchar(25) not null
)

select * from usuario
select nome_usuario, login_usuario, status_usuario from usuario
select nome_usuario as 'Nome da pessoa', 
	   login_usuario as 'Login',
	   status_usuario as 'Status da pessoa'
from usuario

create table cidade
(
	id_cidade int identity primary key,
	nome_cidade varchar(50) not null
)

insert into cidade values
	

insert into usuario 
	(nome_usuario,cpf_usuario,login_usuario,senha_usuario,obs_usuario,status_usuario)
values
	('Administrador','111.111.111-11','admin','123','','Ativo')

insert into usuario 
	(nome_usuario,cpf_usuario,login_usuario,senha_usuario,obs_usuario,status_usuario)
values
	('Asdrubal','111.111.111-12','asdrubal','123','','Ativo'),
	('Benegundes','111.111.111-13','benegundes','123','','Ativo')

create table Categoria
(
	id_categoria int not null identity primary key,
	nome_categoria varchar(50) not null,
	descricao_categoria varchar(255) null,
	obs_categoria varchar(255) null,
	status_categoria varchar(25) not null
)
select * from Categoria
insert into categoria
	(nome_categoria,descricao_categoria,obs_categoria,status_categoria)
values
	('Parafuso','','','Ativo')

-- para deletar uma tabela
drop table categoria

create table Produto
(
	id_produto int not null identity primary key,
	nome_produto varchar(50) not null unique,
	descricao_produto varchar(255) null,
	valor_produto decimal(10,2) not null,
	cadastro_produto smalldatetime not null default getdate(),
	qtde_produto int not null,
	id_categoria_produto int not null,
	id_usuario_produto int not null,
	obs_produto varchar(255) null,
	status_produto varchar(25) not null

	constraint FK_Id_Categoria_Produto foreign key(id_categoria_produto) references Categoria (id_categoria),
	constraint FK_id_Usuario_produto foreign key(id_usuario_produto) references usuario(id_usuario)
)

select * from produto

insert into produto
(nome_produto,descricao_produto,valor_produto,qtde_produto,id_categoria_produto,id_usuario_produto,obs_produto,status_produto)
values
('Parafuso Bla','',2.32,300,1,1,'','Ativo')

insert into produto
(cadastro_produto,nome_produto,descricao_produto,valor_produto,qtde_produto,id_categoria_produto,id_usuario_produto,obs_produto,status_produto)
values
('19-01-2023','Parafuso Ble','Retroativo',2.32,300,1,4,'','Ativo')

SET DATEFORMAT ymd
insert into produto
(cadastro_produto,nome_produto,descricao_produto,valor_produto,qtde_produto,id_categoria_produto,id_usuario_produto,obs_produto,status_produto)
values
('2023-01-20','Parafuso Bli','Retroativo',2.32,300,1,4,'','Ativo')


-- where

select * from usuario where id_usuario = 4

-- atualizando um registro - UPDATE
update usuario set senha_usuario = '123456' where id_usuario = 4

-- Deletando um registro - DELETE
delete from usuario where id_usuario = 3

