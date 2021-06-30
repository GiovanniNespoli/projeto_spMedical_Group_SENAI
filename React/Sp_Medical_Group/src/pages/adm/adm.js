import { Component } from 'react'
import '../../asset/css/adm.css'
import casa from '../../asset/img/pagina-inicial.png'
import logo from '../../asset/img/logo.png'
import user from '../../asset/img/userr.png'
import { Link } from 'react-router-dom'


class Adm extends Component
{
    constructor(props){
        super(props);
        this.state = {

        }
    }
    

    funcaoLogout = () => 
    {
        localStorage.removeItem('usuario-login')
    }  


  render()
  {
    return(

        <div>
          <header className="cab-ADM">
        <div className="ctn-ADM">
            <div className="logo-ADM">
                <img className="img-ADM" src={logo} alt="logo-ADM"/>
            </div>

            <div className="header-ADM">
                <Link to ="/">login</Link>
                <Link to ="/"><img src={casa} alt="home"/></Link>
                <Link to ="/"><button onClick={this.funcaoLogout}>logout</button></Link>
            </div>
        </div>
    </header>

    <main className="main-ADM">
        <section className="ctn-ADM">
            <div className="txtmain-ADM">
                
                <p>acesso do</p>
                <p>administrador</p>
              
            </div>

            <div className="meio-ADM">
                <div className="linha-ADM"></div>
            </div>

            <div className="userImg-ADM">
                <img src={user} alt="foto"/>
            </div>
        </section>

        <section id="botao-ADM">
            <Link to ="/admcadastrar"><button onclick={this.state.cadastrarCon}>cadastrar consultas</button></Link>
            <Link to ="/admlistar"><button onclick={this.state.listaConsulta}>lista de consultas</button></Link>
            <button onclick="">cadastrar usuário</button>
        </section>
        
    </main>
        </div>

    );
  }
}


export default Adm;