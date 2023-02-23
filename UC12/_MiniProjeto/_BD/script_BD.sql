create database t13_miniprojeto
use t13_miniprojeto

create table usuario
(
	id_Usuario	int	not null	identity primary key,	--0
	nome_Usuario	varchar(50)	not null,				--1
	login_Usuario	varchar(30)	not null	unique,		--2
	senha_Usuario	varchar(30)	not null,				--3
	obs_Usuario	varchar(255)	null,					--4
	status_Usuario	varchar(30)	not null				--5
)

insert into usuario 
	(nome_Usuario,login_Usuario,senha_Usuario,obs_Usuario,status_Usuario)
values
	('administrador','admin','123','','Ativo') select SCOPE_IDENTITY()

select * from usuario

insert into usuario 
	(nome_Usuario,login_Usuario,senha_Usuario,obs_Usuario,status_Usuario)
values
	('benegundes','benegundes','123','','Ativo') select SCOPE_IDENTITY()


create table categoria
(
	id_Categoria	int	not null	identity primary key	,
	nome_Categoria	varchar(50)	not null	unique	,
	descricao_Categoria	varchar(255)	null		,
	obs_Categoria	varchar(255)	null		,
	status_Categoria	varchar(30)	not null	
)
insert into categoria values ('Ouro','','','Ativo')
insert into categoria values ('Premium','','','Ativo'),
	 ('Prata','','','Ativo'),
	 ('Bronze','','','Ativo'),
	 ('Madeira','','','Ativo'),
	 ('Materia Prima','','','Ativo'),
	 ('Vidro','','','Ativo'),
	 ('Venda','','','Ativo')

select * from categoria

create table produto
(
	id_Produto	int	not null	identity primary key	,
	nome_Produto	varchar(50)	not null	unique	,
	id_categoria_Produto	int	not null		,
	valorcusto_Produto	decimal(10,5)	not null		,
	valorvenda_Produto	decimal(10,5)	not null		,
	descricao_Produto	varchar(255)	null		,
	qtde_Produto	int	not null	default 0	,
	datacadastro_Produto	smalldatetime	not null	default getdate()	,
	obs_Produto	varchar(255)	null		,
	status_Produto	varchar(30)	not null		
	constraint fk_id_categoria_Produto foreign key (id_categoria_Produto) references categoria (id_categoria)
)

create table MovProduto
(
	id_MovProduto	int	not null	identity primary key	,
	id_produto_MovProduto	int	not null		,
	id_usuario_MovProduto	int	not null		,
	qtde_MovProduto	int	not null		,
	datacadastro_MovProduto	smalldatetime	not null	default getdate()	,
	obs_MovProduto	varchar(255)	null		,
	status_MovProduto	varchar(30)	not null		
	constraint FK_id_produto_MovProduto foreign key(id_produto_MovProduto) references produto(id_produto),
	constraint fk_id_usuario_MovProduto foreign key(id_usuario_MovProduto) references usuario(id_usuario)
)

select * from usuario
select * from categoria
select * from produto
select * from MovProduto