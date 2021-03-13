USE Medical_Grup;

SELECT Clinica.IdClinica , Clinica.RazaoSocial , Medico.NomeMedico ,
Especialidade.Especialidades ,
Consulta.IdConsulta , Paciente.NomePaciente , 
Situa��o.TipoSituacao , Consulta.DataConsulta ,
Descricao FROM Consulta

INNER JOIN Clinica
ON Consulta.IdConsulta = Clinica.IdClinica
INNER JOIN Medico
ON Consulta.IdConsulta = Medico.IdMedico
INNER JOIN Especialidade
ON Consulta.IdConsulta = Especialidade.IdEspecialidade
INNER JOIN Situa��o
ON Consulta.IdConsulta = Situa��o.IdSituacao
INNER JOIN Paciente
ON Consulta.IdConsulta = Paciente.IdPaciente
