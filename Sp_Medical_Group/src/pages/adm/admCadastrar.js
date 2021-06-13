import { Component } from 'react'
import { Link } from 'react-router-dom';
import '../../asset/css/admCadastrar.css'
import logo from '../../asset/img/logo.png'
import casa from '../../asset/img/pagina-inicial.png'

class AdmCadastrar extends Component{
    constructor(props)
    {
        super(props);
        this.state = 
        {
            paciente : [],
            medico   : [],
            situacao : [],
            idpaciente : 0,
            idmedico : 0,
            decricao : '',
            idsituacao : 0,
            data : '',
            exames : ''
        }
    }

    atualizarCampos = (campo) =>
  {
    this.setState({ [campo.target.name] : campo.target.value })
  }

  cadastrarConsulta = (event) =>
  {
      event.preventDefault();

      fetch('http://localhost:5000/api/Consulta',
      {
        method : 'POST',

        body : JSON.stringify({
                idPaciente      : this.state.idpaciente,
                idMedico        : this.state.idmedico,
                descricao       : this.state.decricao,
                idSituacao      : this.state.idsituacao,
                dataConsulta    : new Date(this.state.data),
                exames          : this.state.exames
        }),

        headers : {
            "Content-Type" : "application/json",
            'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
      }
    })
   }
    
   funcaoLogout = () => 
  {
      localStorage.removeItem('usuario-login')
  }

    render()
    {
        return(

            <div>
                <header className="cab-CA">
        <div className="ctn-CA">
            <div className="logo-CA">
                <img className="img-CA" src={logo} alt="logo" />
            </div>
    
            <div className="header-CA">
                <Link to="/">login</Link>
                <Link to="/adm"><img src={casa} alt="home" /></Link>
                <Link to ="/"><button onClick={this.funcaoLogout}>logout</button></Link>
            </div>
        </div>
    </header>
    
    <main className="main-CA">
        <div className="quadro-CA">

            <form onSubmit={this.cadastrarConsulta} className="form-CA">
            <div className="lista-CA">
                        <div className="meio-CA">
                            <div className="form-meio-CA">
                                <div className="meio-inputs-CA">
                                    <div className="inputs-CA">
                                        <p>paciente</p>
                                        <input  type="number"
                                                name="idpaciente" 
                                                onChange={this.atualizarCampos}
                                                value={this.state.idpaciente}/>
                                    </div>
    
                                    <div className="inputs-CA">
                                        <p>médico</p>
                                        <input  type="number"
                                                name="idmedico" 
                                                onChange={this.atualizarCampos} 
                                                value={this.state.idmedico}/>
                                    </div>
    
                                    <div className="inputs-CA">
                                        <p>descrição</p>
                                        <input  type="text"
                                                name="decricao" 
                                                onChange={this.atualizarCampos} 
                                                value={this.state.decricao}/>
                                    </div>
                                </div>
                            </div>
    
                            <div className="form-meio-CA">
                                <div className="meio-inputs-CA">
                                    <div className="inputs-CA">
                                        <p>situação</p>
                                        <input  type="number"
                                                name="idsituacao" 
                                                onChange={this.atualizarCampos} 
                                                value={this.state.idsituacao}/>
                                    </div>
    
                                    <div className="inputs-CA">
                                        <p>data</p>
                                        <input  type="date"
                                                name="data" 
                                                onChange={this.atualizarCampos} 
                                                value={this.state.data}/>
                                    </div>
    
                                    <div className="inputs-CA">
                                        <p>exame</p>
                                        <select className="select-CA"
                                                name="exames" 
                                                onChange={this.atualizarCampos} 
                                                value={this.state.exame}>
                                            <option value="Sim">Sim</option>
                                            <option value="Não">Não</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div className="btn-CA">
                            <button type="submit">cadastrar</button>
                        </div>
                    </div>
                </form>


        </div>
    </main>
            </div>

        );
    }
}

export default AdmCadastrar