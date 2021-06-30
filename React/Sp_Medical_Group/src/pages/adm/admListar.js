import { Component } from 'react'
import '../../asset/css/admListar.css'
import casa from '../../asset/img/pagina-inicial.png'
import logo from '../../asset/img/logo.png'
import { Link } from 'react-router-dom';

class AdmListar extends Component{
    constructor(props)
    {
        super(props);
        this.state = 
        {
            listaConsultas : []
        }
    }

    componentDidMount()
    {
        this.listarConsultas();
    }

    listarConsultas = () =>
    {
        console.log('nespolindo')

        fetch('http://localhost:5000/api/Consulta/ListarTudo',
        {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => resposta.json())

        .then(resposta => this.setState({ listaConsultas : resposta }))

        .catch((erro) => console.log(erro))
    }

    funcaoLogout = () => 
    {
        localStorage.removeItem('usuario-login')
    }  

    render()
    {
        return(

            <div>
               <header className="cab-AL">
        <div className="ctn-AL">
            <div className="logo-AL">
                <img className="img-AL" src={logo} alt="logo" />
            </div>
    
            <div className="header-AL">
                <Link to ="/">login</Link>
                <Link to ="/adm"><img src={casa} alt="home" /></Link>
                <Link to ="/"><button onClick={this.funcaoLogout}>logout</button></Link>
            </div>
        </div>
    </header>

    <main className="main-AL">
        <table>
                <tr className="tr-AL">
                    <th className="th-AL">consulta</th>
                    <th className="th-AL">paciente</th>
                    <th className="th-AL">médico</th>
                    <th className="th-AL">descrição</th>
                    <th className="th-AL">situação</th>
                    <th className="th-AL">data da consulta</th>
                    <th className="th-AL">exame</th>
                </tr>
                {
                            this.state.listaConsultas.map( (consultas) =>{

                                return(
                                    <tr className="tr-AL" key={consultas.idConsulta}>
                                        <td>{consultas.idConsulta}</td>
                                        <td>{consultas.idPacienteNavigation.nomePaciente}</td>
                                        <td>{consultas.idMedicoNavigation.nomeMedico}</td>
                                        <td>{consultas.descricao}</td>
                                        <td>{consultas.idSituacaoNavigation.tipoSituacao}</td>
                                        <td>{new Intl.DateTimeFormat('pt-BR').format(new Date(consultas.dataConsulta))}</td>
                                        <td>{consultas.exames}</td>
                                    </tr>
                        );
                    })
                        }
                
        </table>
    </main> 
            </div>
        )
    }
}

export default AdmListar