create database agenda;
use agenda;

create table Paciente(
	codigoPaciente int primary key not null auto_increment,
    nome varchar(100) not null,
    convenio varchar(50) not null,
    tratamento varchar(50) not null,
    lugar varchar(50) not null,
    telefone varchar(14) not null,
    horario varchar(5),
    dias varchar(75),
    cpf varchar(11),
    imposto varchar(15),		
    divida varchar(50)
)Engine InnoDB;

drop table Paciente;

select * from Paciente;