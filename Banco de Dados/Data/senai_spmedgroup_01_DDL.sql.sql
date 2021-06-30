CREATE DATABASE Medical_Grup_;
GO

USE Medical_Grup_;
GO

CREATE TABLE TipoDeUsuario(

	IdTipoDeUsuario	INT PRIMARY KEY IDENTITY,
	TipoDeUsuario	VARCHAR(200)

);
GO

CREATE TABLE Usuario(

	IdUsuario		INT PRIMARY KEY IDENTITY,
	IdTipoDeUsuario	INT FOREIGN KEY REFERENCES TipoDeUsuario(IdTipoDeUsuario),
	Email			VARCHAR(200) NOT NULL,
	Senha			VARCHAR(200) NOT NULL,

);
GO

CREATE TABLE Paciente(

	IdPaciente		INT PRIMARY KEY IDENTITY,
	IdUsuario		INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
	NomePaciente	VARCHAR(200) NOT NULL,
	RG				CHAR(9) UNIQUE NOT NULL,
	CPF				CHAR(11) UNIQUE NOT NULL,
	ENDEREÇO		VARCHAR(200) NOT NULL,
	DataDeNasc		DATE NOT NULL,
	Telefone		CHAR(9) NOT NULL,

);
GO

CREATE TABLE Situacao(

	IdSituacao		INT PRIMARY KEY IDENTITY,
	TipoSituacao	VARCHAR(200) NOT NULL,

);
GO

CREATE TABLE Especialidade(

	IdEspecialidade	INT PRIMARY KEY IDENTITY,
	Especialidades	VARCHAR(200) NOT NULL,

);
GO

CREATE TABLE Clinica(

	IdClinica			INT PRIMARY KEY IDENTITY,
	Endereco			VARCHAR(200) NOT NULL,
	RazaoSocial			VARCHAR(200) NOT NULL,
	CNPJ				CHAR(13) NOT NULL,
	NomeFantasia		VARCHAR(200) NOT NULL,
	HorarioDeAbertura	VARCHAR(100) DEFAULT ('6AM'),
	HorarioDeEncerrar	VARCHAR(100) DEFAULT ('23PM'),

);
GO

CREATE TABLE Medico(

	IdMedico			INT PRIMARY KEY IDENTITY,
	IdUsuario			INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
	IdEspecialidade		INT FOREIGN KEY REFERENCES Especialidade(IdEspecialidade),
	IdClinica			INT FOREIGN KEY REFERENCES Clinica(IdClinica),
	NomeMedico			VARCHAR(200) NOT NULL,
	RG					CHAR(9) NOT NULL,
	Endereco			VARCHAR(200) NOT NULL,
	DataDeNascimento	DATE NOT NULL,
	Telefone			CHAR(8) NOT NULL,	

);
GO

CREATE TABLE Consulta(

	IdConsulta			INT PRIMARY KEY IDENTITY,
	IdPaciente			INT FOREIGN KEY REFERENCES Paciente(IdPaciente),
	IdMedico			INT FOREIGN KEY REFERENCES Medico(IdMedico),
	IdSituacao			INT FOREIGN KEY REFERENCES Situacao(IdSituacao),
	DataConsulta		DATE NOT NULL,
	Exames				CHAR(3) DEFAULT('Não'),
	Descricao			VARCHAR(200) NOT NULL,	

);