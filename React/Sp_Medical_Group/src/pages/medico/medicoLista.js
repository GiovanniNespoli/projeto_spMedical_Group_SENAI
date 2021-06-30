import { Component } from "react"
import '../../asset/css/medicoListar.css'
import casa from '../../asset/img/pagina-inicial.png'
import logo from '../../asset/img/logo.png'

class ListaMedico extends Component
{
    constructor(props)
    {
        super(props);
        this.state =
        {
            listaMedico : [],
            idDesc : 0,
            Desc : ''
        }
    }

    listarMedicoConsulta = () =>
    {
        fetch('http://localhost:5000/api/Consulta/MedicoConsultas',
        {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resp => resp.json())

        .then(resposta => this.setState({ listaMedico : resposta }))

        .catch((erro) => console.log(erro))
    }

    atualizarState = async (event) => {
        await this.setState({ Desc : event.target.value })
    };

    buscarDescId = async (med) =>
    {
        await this.setState({
            idDesc : med.idConsulta,
            Desc : med.descricao
            
        })
        console.log(this.state.idDesc, this.state.Desc)
    }

    atualizarDesc = (event) =>
    {
        event.preventDefault()

        fetch('http://localhost:5000/api/Consulta/'+this.state.idDesc,
        {
            // Define o método da requisição ( PUT )
            method : 'PUT',

            // Define o corpo da requisição especificando o tipo ( JSON )
            body : JSON.stringify({
            descricao : this.state.Desc
            }),

            // Define o cabeçalho da requisição
            headers : {
                "Content-Type" : "application/json",
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(this.listarMedicoConsulta())        
    }

    componentDidMount = () => 
    {
        this.listarMedicoConsulta();
    }

    funcaoLogout = () => 
  {
      localStorage.removeItem('usuario-login')
  }

    render()
    {
        return(

            <div>
                <header className="cab-ML">
        <div className="ctn-ML">
            <div className="logo-ML">
                <img className="img-ML" src={logo} alt="logo" />
            </div>
    
            <div className="header-ML">
                <a href="/">login</a>
                <a href="/medico"><img src={casa} alt="home" /></a>
                <a href="/"><button onClick={this.funcaoLogout}>logout</button></a>
            </div>
        </div>
    </header>

    <main className="main-ML">
        {
            this.state.listaMedico.map( (med) =>{
                return(

        <form onSubmit={this.atualizarDesc} className="lista-ML">
            <div className="lista-meio-ML">
                <div className="lista-input-ML">
                    <div className="meio-input-ML">
                        <p>paciente</p>
                    </div>
                    <div className="input-meio-ML">
                        <input type="text" placeholder={med.idPacienteNavigation.nomePaciente} readOnly />
                    </div>
                </div>
                <div className="lista-input-ML">
                    <div className="meio-input-ML">
                        <p>nascimento</p>
                    </div>
                    <div className="input-meio-ML">
                        <input type="text" placeholder={new Intl.DateTimeFormat('pt-BR').format(new Date(med.idPacienteNavigation.dataDeNasc))} readOnly />
                    </div>
                </div>
                <div className="lista-input-ML">
                    <div className="meio-input-ML">
                        <p>data da consulta</p>
                    </div>
                    <div className="input-meio-ML">
                        <input type="text" placeholder={new Intl.DateTimeFormat('pt-BR').format(new Date(med.dataConsulta))} readOnly />
                    </div>
                </div>
            </div>

            <div className="lista-meio-ML">
                <div className="lista-input-ML">
                    <div className="meio-input-ML">
                        <p>exame</p>
                    </div>
                    <div className="input-meio-ML">
                        <input type="text" placeholder={med.exames} readOnly />
                    </div>
                </div>
                <div className="lista-input-ML">
                    <div className="meio-input-ML">
                        <p>situação</p>
                    </div>
                    <div className="input-meio-ML">
                        <input type="text" placeholder={med.idSituacaoNavigation.tipoSituacao} readOnly/>
                    </div>
                </div>
                <div className="lista-input-ML">
                    <div className="meio-input-ML">
                        <p>descrição</p>
                    </div>
                    <div className="input-meio-ML">
                        <input onChange={this.atualizarState} value={this.state.Desc} type="text" placeholder={med.descricao}/>
                    </div>
                    <div className="btn-meio-ML">
                        <button onClick={() => this.buscarDescId(med)}>atualizar</button>
                        <button type="submit">confirmar</button>
                    </div>
                </div>
            </div>
        </form>
                );
            })

        }
    </main>
            </div>

        );
    }
}

export default ListaMedico