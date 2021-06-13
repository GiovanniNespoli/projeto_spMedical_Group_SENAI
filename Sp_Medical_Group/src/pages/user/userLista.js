import { Component } from "react"
import '../../asset/css/userLista.css'
import logo from '../../asset/img/logo.png'
import casa from '../../asset/img/pagina-inicial.png'

class UserLista extends Component
{
    constructor(props)
    {
        super(props);
        this.state = 
        {
            listaUser : []
        }
    }

    componentDidMount()
    {
        this.listarConsultaUser();
    }

    listarConsultaUser()
    {
        fetch('http://localhost:5000/api/Consulta/UsuarioConsultas',
        {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resp => resp.json())

        .then(resposta => this.setState({ listaUser : resposta }))

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
                <header class="cab-UL">
        <div class="ctn-UL">
            <div class="logo-UL">
                <img class="img-UL" src={logo} alt="logo" />
            </div>
    
            <div class="header-UL">
                <a href="/">login</a>
                <a href="/user"><img src={casa} alt="home" /></a>
                <a href="/"><button onClick={this.funcaoLogout}>logout</button></a>
            </div>
        </div>
    </header>

    <main class="main-UL">
        {
            this.state.listaUser.map( (lista) => {
                return(

        <div class="lista-UL">
            <div class="meio-lista-UL">
                <div class="meio-input-UL">
                    <div class="meio-p-UL">
                        <p>médico</p>
                    </div>
                    <input type="text" placeholder={lista.idMedicoNavigation.nomeMedico} readOnly/>
                </div>
                <div class="meio-input-UL">
                    <div class="meio-p-UL">
                        <p>especialidade</p>
                    </div>
                    <input type="text" placeholder={lista.idMedicoNavigation.idEspecialidadeNavigation.especialidades} readOnly/>
                </div>
                <div class="meio-input-UL">
                    <div class="meio-p-UL">
                        <p>endereço</p>
                    </div>
                    <input type="text" placeholder={lista.idMedicoNavigation.idClinicaNavigation.endereco} readOnly/>
                </div>
                <div class="meio-input-UL">
                    <div class="meio-p-UL">
                        <p>clínica</p>
                    </div>
                    <input type="text" placeholder={lista.idMedicoNavigation.idClinicaNavigation.nomeFantasia} readOnly/>
                </div>
            </div>
            <div class="meio-lista-UL">
                <div class="meio-input-UL">
                    <div class="meio-p-UL">
                        <p>data</p>
                    </div>
                    <input type="text" placeholder={new Intl.DateTimeFormat('pt-BR').format(new Date(lista.dataConsulta))} readOnly/>
                </div>
                <div class="meio-input-UL">
                    <div class="meio-p-UL">
                        <p>situação</p>
                    </div>
                    <input type="text" placeholder={lista.idSituacaoNavigation.tipoSituacao} readOnly/>
                </div>
                <div class="meio-input-UL">
                    <div class="meio-p-UL">
                        <p>descrição</p>
                    </div>
                    <input type="text" placeholder={lista.descricao} readOnly/>
                </div>
                <div class="meio-input-UL">
                    <div class="meio-p-UL">
                        <p>exame</p>
                    </div>
                    <input type="text" placeholder={lista.exames} readOnly/>
                </div>
            </div>
        </div>
                );
            })
        }
    </main>
            </div>

        );
    }
}

export default UserLista