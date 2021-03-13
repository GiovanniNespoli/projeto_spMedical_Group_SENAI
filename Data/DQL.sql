USE Medical_Grup;

INSERT INTO TipoDeUsuario
VALUES		('M�dico'),
			('Paciente'),
			('ADM');
--SELECT * FROM TipoDeUsuario;--
--DELETE TipoDeUsuario WHERE IdTipoDeUsuario = 2;--

INSERT INTO Usuario		(IdTipoDeUsuario , Email , Senha)
VALUES					(7				 , 'ADM@gmail.com' ,123456789),
						(5				 , 'Bruno@gmail.com' , 123456789),
						(6				 , 'Luis@gmail.com', 123456789);
--SELECT * FROM Usuario;--

INSERT INTO Paciente	(IdUsuario,NomePaciente,RG,CPF,ENDERE�O,DataDeNasc,Telefone)
VALUES					(5,'Luis',123456789,12345678901,'Rua Mercedes','19/03/1970',91231-2312);
--SELECT*FROM Paciente;--

INSERT INTO Situa��o
VALUES					('Agendada'),
						('Cancelada'),
						('Feita');
--SELECT*FROM Situa��o;--

INSERT INTO Clinica	(Endereco, RazaoSocial,CNPJ,NomeFantasia)
VALUES				('Rua street 192','cl�nica m�dica SP Medical Group','1234567890123','SP Medical Grup');
--SELECT*FROM Clinica;--

INSERT INTO Especialidade
VALUES		('Acupuntura'),
			('Anestesiologia'),
			('Angiologia'),
			('Cardiologia'),
			('Cirurgia Cardiovascular'),
			('Cirurgia da M�o'),
			('Cirurgia do Aparelho Digestivo'),
			('Cirurgia Geral'),
			('Cirurgia Pedi�trica'),
			('Cirurgia Pl�stica'),
			('Cirurgia Tor�cica'),
			('Cirurgia Vascular'),
			('Dermatologia'),
			('Radioterapia'),
			('Urologia'),
			('Pediatria'),
			('Psiquiatria');
--SELECT*FROM Especialidade;--

INSERT INTO Medico	(IdUsuario,IdEspecialidade,IdClinica,RG,Endereco,DataDeNascimento,Telefone,NomeMedico)
VALUES				(5,13,3,'123456789','Rua casa 144','28/7/1971',2134-7890,'Bruno');	
--SELECT*FROM Medico;--

INSERT INTO Consulta	(IdPaciente,IdMedico,IdSituacao,DataConsulta,Descricao)
VALUES					(12,1,3,'12/03/2021','Pele seca');
SELECT*FROM Consulta;