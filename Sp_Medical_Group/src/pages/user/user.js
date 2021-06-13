import { Component } from 'react'
import { Link } from 'react-router-dom'
// import '../../asset/css/user.css'
import logo from '../../asset/img/logo.png'
import casa from '../../asset/img/pagina-inicial.png'
import user from '../../asset/img/userr.png'


class User extends Component
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
         <header class="cab-UM">
        <div class="ctn-UM">
            <div class="logo-UM">
                <img class="img-UM" src={logo} alt="logo" />
            </div>

            <div class="header-UM">
                <Link to="/" href="#">login</Link>
                <Link to="/"><img src={casa} alt="home"/></Link>
                <Link to ="/"><button onClick={this.funcaoLogout}>logout</button></Link>
            </div>
        </div>
    </header>

    <main>
        <section class="ctn-UM">
            <div class="txtmain-UM">

                <p class="p1-UM txt-UM">
                    bem vindo
                </p>

                <div class="p2-UM txt-UM">
                    
                    <div class="p2meio1-UM">
                        <p>paciente</p>
                    </div>

                    <div class="p2meio2-UM">
                        <p>ao</p>
                    </div>

                </div>

                <div class="p3-UM">
                    <div class="p3div-UM txt-UM">
                    sp medical group
                    </div>
                </div>
            </div>

            <div class="meio-UM">
                <div class="linha-UM"></div>
            </div>

            <div class="userImg-UM">
                <img src={user} alt="foto" />
            </div>
        </section>

        <section id="botao-UM">
            <Link to="/userlista"><button onclick="listaConsulta()">suas consultas</button></Link>
        </section>

    </main>
        </div>

    );
  }
}


export default User;
