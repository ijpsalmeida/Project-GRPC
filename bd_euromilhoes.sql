create table sorteios(
	id integer not null identity(1,1),
	nsorteio integer not null,	
	nome varchar(100) not null,
	telemovel varchar(100) not null,
	chave varchar(100) not null,
	primary key(id)
);

insert into sorteios(nsorteio, nome, telemovel, chave) values ('1', 'administrador', 'administrador', 'administrador')