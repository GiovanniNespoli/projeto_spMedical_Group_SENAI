USE Medical_Grup_;
GO

INSERT INTO TipoDeUsuario
VALUES		('Médico'),
			('Paciente'),
			('ADM');
GO


INSERT INTO Usuario		(IdTipoDeUsuario , Email , Senha)
VALUES					(3				 , 'ADM@gmail.com' ,123456789),
						(1				 , 'Bruno@gmail.com' , 123456789),
						(2				 , 'Luis@gmail.com', 123456789);
GO

INSERT INTO Paciente	(IdUsuario,NomePaciente,RG,CPF,ENDEREÇO,DataDeNasc,Telefone)
VALUES					(3,'Luis',123456789,12345678901,'Rua Mercedes','19/03/1970',91231-2312);
GO

INSERT INTO Situacao
VALUES					('Agendada'),
						('Cancelada'),
						('Feita');
GO

INSERT INTO Clinica	(Endereco, RazaoSocial,CNPJ,NomeFantasia)
VALUES				('Rua street 192','clínica médica SP Medical Group','1234567890123','SP Medical Grup');
GO

INSERT INTO Especialidade
VALUES		('Acupuntura'),
			('Anestesiologia'),
			('Angiologia'),
			('Cardiologia'),
			('Cirurgia Cardiovascular'),
			('Cirurgia da Mão'),
			('Cirurgia do Aparelho Digestivo'),
			('Cirurgia Geral'),
			('Cirurgia Pediátrica'),
			('Cirurgia Plástica'),
			('Cirurgia Torácica'),
			('Cirurgia Vascular'),
			('Dermatologia'),
			('Radioterapia'),
			('Urologia'),
			('Pediatria'),
			('Psiquiatria');
GO

INSERT INTO Medico	(IdUsuario,IdEspecialidade,IdClinica,RG,Endereco,DataDeNascimento,Telefone,NomeMedico)
VALUES				(2,13,1,'123456789','Rua casa 144','28/7/1971',2134-7890,'Bruno');	
GO

INSERT INTO Consulta	(IdPaciente,IdMedico,IdSituacao,DataConsulta,Descricao)
VALUES					(1,1,3,'12/03/2021','Pele seca');
GO