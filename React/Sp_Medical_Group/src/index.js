import React from 'react'
import ReactDOM from 'react-dom'
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom'
import { parseJWT, userLogado } from './services/auth'

import './index.css'

import Login from './pages/login/App'

import User from './pages/user/user'
import UserLista from './pages/user/userLista'

import NotFound from './pages/notfound/notfound'

import Medico from './pages/medico/medico'
import MedicoLista from './pages/medico/medicoLista'

import Adm from './pages/adm/adm'
import AdmListar from './pages/adm/admListar'
import AdmCadastrar from './pages/adm/admCadastrar'

import reportWebVitals from './reportWebVitals';

const PermissaoAdm = ({ component : Component}) =>
(
  <Route
  
    render = { props =>
    
      userLogado() && parseJWT().role === "3" ?

      <Component {...props}/> :

      <Redirect to="notfound"/>

    }
  
  />
)

const PermisaoMed = ({ component : Component }) =>
(
  <Route
  
    render = { props =>
    
      userLogado() && parseJWT().role === "1" ?

      <Component {...props}/> :

      <Redirect to="notfound"/>
    
    }
  
  />
)

const PermisaoUser = ({ component : Component }) =>
(
  <Route
  
    render = { props =>
    
      userLogado() && parseJWT().role === "2" ?

      <Component {...props}/> :

      <Redirect to="notfound"/>
    
    }
  
  />
)

const routing = 
(
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Login}/>
        
        <PermisaoUser path="/user" component={User}/>
        <PermisaoUser path="/userlista" component={UserLista}/>

        <Route path="/notfound" component={NotFound}/>

        <PermisaoMed path="/medico" component={Medico}/>
        <PermisaoMed path="/medicoLista" component={MedicoLista}/>

        <PermissaoAdm path="/adm" component={Adm}/>
        <PermissaoAdm path="/admlistar" component={AdmListar}/>
        <PermissaoAdm path="/admcadastrar" component={AdmCadastrar}/>
        <Redirect to="notfound"/>
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
