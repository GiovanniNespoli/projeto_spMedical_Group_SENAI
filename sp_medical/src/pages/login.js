import { StatusBar } from 'expo-status-bar';
import React, {Component} from 'react';
import { StyleSheet, TextInput,Image, Text, TouchableOpacity, View } from 'react-native';
import api from '../services/api';
import AsyncStorage from '@react-native-async-storage/async-storage';
import jwt_decode from 'jwt-decode';

export default class Login extends Component{
  constructor(props){
      super(props);
      this.state = {
        email: '',
        senha: ''
      }
  }

  login = async () =>
  {
    console.warn(this.state.email + ' ' + this.state.senha)

    try {
      
      const resp = await api.post('/Login/Login', {
        email : this.state.email,
        senha : this.state.senha
      });

      const token = resp.data.token;

      console.warn(token);

      await AsyncStorage.setItem('userToken', token)

      var decoded = jwt_decode(token).role;

      console.warn(decoded)

      if(decoded === "1")
      {
        this.props.navigation.navigate('medico')
      }

      if(decoded === "2")
      {
        this.props.navigation.navigate('user')
      }
      
    } catch (error) {
      console.warn(error)
    }
  }


  render() {
      return (
        <View style={styles.container}>
            <View style={styles.inputsLogin}>
                <TextInput
                    style={styles.mainInput}
                    placeholder="Email"
                    placeholderTextColor="white"
                    keyboardType='email-address'
                    onChangeText={email => this.setState({email})}
                    />

                    <TextInput
                    style={styles.mainInput}
                    placeholder="Senha"
                    placeholderTextColor="white"
                    secureTextEntry={true}
                    keyboardType='email-address'
                    onChangeText={senha => this.setState({senha})}
                    />

                    <TouchableOpacity style={styles.btnStyle} onPress={this.login}>
                        <Text style={styles.btnLogin}>login</Text>
                    </TouchableOpacity>
            </View>
            <View style={styles.imgLogin}>
                <Image
                    source={require('../../assets/img/logoLogin.png')}
                    style={styles.logoLogin}
                />
            </View>
        </View>
      );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#006B49',
  },

  inputsLogin: {
    flex: 0.70,
    // backgroundColor: 'red',
    justifyContent: 'center',
    alignItems: 'center'
  },

  mainInput: {
    width: 270,
    height: 35,
    fontSize: 18,
    fontFamily: 'Arial',
    color: 'white',
    borderBottomWidth: 2,
    borderBottomColor: 'white',
    marginBottom : 50,
  },

  btnStyle: {
    width: 120,
    height: 40,
    marginTop: 40,
    backgroundColor: '#fff',
    borderRadius: 5,
    justifyContent: 'center',
    alignItems: 'center'
  },

  btnLogin: {
    fontSize: 18,
    fontFamily: 'Arial',
    textTransform: 'uppercase',
  },

  imgLogin: {
    flex: 0.25,
    // backgroundColor: 'red',
    justifyContent: 'center',
    alignItems: 'center',
  },

  logoLogin:{
    width: 400,
    height: 100,
  },
});