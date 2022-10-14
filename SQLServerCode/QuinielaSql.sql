/*
constraint fk_ foreign key () references  (),
*/

/*
CREATE TABLE Persona
(
	idPersona int identity primary key,
	nombre1 varchar(10) not null,
	nombre2 varchar(10),
	apellido1 varchar(12) not null,
	apellido2 varchar(12),
	correo varchar(30) not null
);
*/
/*
create table Usuario
(
	idUser int identity primary key,
	nameUser varchar(25) not null,
	passwworr varchar(25) not null,
	idPersona int not null,
	constraint fk_personUser foreign key (idPersona) references Persona (idPersona)
);
*/



/*
create table Solicitudes
(
	idSolicitud int identity primary key,
	EstadoSolicitud varchar(15) not null
);
*/
/*
create table Invitados
(
	idInvitados int identity primary key,
	idAdministrador int not null,
	idPersona int not null,
	idSolicitud int not null, 
	constraint fk_UserInvitado foreign key (idAdministrador) references Usuario (idUser),
	constraint fk_PersonInvitado foreign key (idPersona) references Persona (idPersona),
	constraint fk_SolicitudInvitado foreign key (idSolicitud) references Solicitudes (idSolicitud)
);
*/
/*
create table TipoQuiniela
(
	idTipQui int identity primary key,
	tipoQuiniela varchar(25) not null
);
*/
/*
create table Mundial
(
	idMundial int identity primary key,
	mundial varchar(50) not null,
	fechar date
);
*/
/*
create table Quiniela
(
	idQui int identity primary key,
	nameQuiniela varchar(50) not null,
	idUser int not null,
	idMundial int not null,
	idTipQui int not null,
	monto varchar(10) not null, 
	constraint fk_UserQuiniela foreign key (idUser) references Usuario (idUser),
	constraint fk_MundialQuiniela foreign key (idMundial) references Mundial (idMundial),
	constraint fk_tipoQuiniela foreign key (idTipQui) references TipoQuiniela (idTipQui)
);
*/
/*
create table Grupo
(
	idGrupo int identity primary key,
	grupo varchar(8) not null,
);
*/
/*
create table Equipo
(
	idEquipo int identity primary key,
	equipo varchar (30) not null
);
*/
/*
create table Encuentros
(
	idEncuentro int identity primary key,
	encuentroNumero varchar(12) not null
);
*/
/*
create table VatiEstado
(
	idVatiEstado int identity primary key,
	nameEstado varchar(15) not null
);
*/
/*
create table EquipoGrupo
(
	idEquiGrup int identity primary key,
	idMundial int not null,
	idGrupo int not null,
	idEquipo int not null,
	goles int not null,
	puntos float not null,
	constraint fk_MundialEquiGrup foreign key (idMundial) references Mundial (idMundial),
	constraint fk_GrupoEquiGrup foreign key (idGrupo) references Grupo (idGrupo),
	constraint fk_EquipoEquiGrup foreign key (idEquipo) references Equipo (idEquipo)
);
*/
/*
create table EncuentroGrupo
(
	idEncGrup int identity primary key,
	idMundial int not null,
	idEncuentro int not null,
	idEquiGrup int not null,
	golesEncuentros int not null,
	puntosEncuentro float not null,
	fechaEncuentro date
);
*/
/*
create table EncuentroGrupoVati
(
	idEncGruVati int identity primary key,
	idEncGrup1 int not null,
	PrediGol1 int not null,
	idEncGrup2 int not null,
	PrediGol2 int not null,
	constraint fk_EncuGrupVati1 foreign key (idEncGrup1) references EncuentroGrupo (idEncGrup),
	constraint fk_EncuGrupVati2 foreign key (idEncGrup2) references EncuentroGrupo (idEncGrup)
);
*/
/*
create table Vaticinio
(
	idVati int identity primary key,
	idPersona int not null,
	idQui int not null,
	idEncuentro int not null,
	idEncGruVati int not null,
	idVatiEstado int not null,
	puntosVati float not null,
	fechaVati date,
	constraint fk_persoVati foreign key (idPersona) references Persona (idPersona),
	constraint fk_QuiVati foreign key (idQui) references Quiniela (idQui),
	constraint fk_EncuentVati foreign key (idEncuentro) references Encuentros (idEncuentro),
	constraint fk_EnGruVatiVati foreign key (idEncGruVati) references EncuentroGrupoVati (idEncGruVati),
	constraint fk_VatiEstado foreign key (idVatiEstado) references VatiEstado (idVatiEstado)
);
*/
/*
create table QuinielaVaticinio
(
	idQuiVati int identity primary key,
	idQui int not null,
	idPersona int not null,
	idVati int not null,
	puntosQuiniela float not null,
	fechaQuiVati date,
	constraint fk_QuiQuivati foreign key (idQui) references Quiniela (idQui),
	constraint fk_PersonQui foreign key (idPersona) references Persona (idPersona),
	constraint fk_VatiQui foreign key (idVati) references Vaticinio (idVati)
);
*/




/*// paraq pruevas de aprendisaje //*/
/*
create table pruevas
(
	idPrueva int identity primary key,
	prue float not null,
	prudate date
)
*/
/*
insert into pruevas (prue,prudate)values(1.2,'05/03/2021');


select * from pruevas;
*/