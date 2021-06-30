import AsyncStorage from '@react-native-async-storage/async-storage';
import { StatusBar } from 'expo-status-bar';
import React,{Component} from 'react';
import { StyleSheet,Image,FlatList, Text, View, ScrollView } from 'react-native';
import api from '../services/api';

export default class Medico extends Component{
  constructor(props){
      super(props);
      this.state = {
        listaMed : []
      }
  }

  listaMed = async () => {
    const valorToken = await AsyncStorage.getItem('userToken');

    const resp = await api.get('/Consulta/UsuarioConsultas',{
      headers : {
        'Authorization' : 'Bearer ' + valorToken
      }
    });

    const dadosApi = resp.data;
    this.setState({ listaMed : dadosApi })
  }

  componentDidMount()
  {
    this.listaMed()
  }

  render() {
      return (
        <View style={styles.container}>
            <View style={styles.headerMed}>
                <Image
                    source={require('../../assets/img/logo.png')}
                    style={styles.headerImg}
                />
            </View>

            <View style={styles.headerText}>
                <Text style={styles.txt}>consultas</Text>
            </View>

            <View style={styles.txtLine}></View>

            <ScrollView>

                <FlatList
                  data={this.state.listaMed}
                  keyExtractor={item => item.idConsulta}
                  renderItem={this.renderItem}
                />
                
            </ScrollView>

        </View>   
      )
  }

  renderItem = ({ item }) => (
    <ScrollView>

    <View style={styles.listInfs}>  

                    <View style={styles.list}>
                        <Text style={styles.listText}>médico:</Text>
                        <Text style={styles.listText}>situação:</Text>
                        <Text style={styles.listText}>exames:</Text>
                        <Text style={styles.listText}>dia:</Text>
                    </View>

                    <View style={styles.infs}>
                        <Text style={styles.infsText}>{item.idMedicoNavigation.nomeMedico}</Text>
                        <Text style={styles.infsText}>{item.idSituacaoNavigation.tipoSituacao}</Text>
                        <Text style={styles.infsText}>{item.exames}</Text>
                        <Text style={styles.infsText}>{new Intl.DateTimeFormat('pt-BR').format(new Date(item.dataConsulta))}</Text>
                    </View>
      </View>
    </ScrollView>
      

  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },

  headerMed: {
    flex: 3,
    backgroundColor: '#006B49',
    justifyContent: 'center',
    alignItems: 'center'
  },

  headerImg: {
    width: 300,
    height: 80,
  },

  headerText: {
    flex: 2,
    // backgroundColor: 'red',
    justifyContent: 'center',
    alignItems: 'center',
    flexDirection: 'column',
  },

  txt: {
    textTransform: 'uppercase',
    fontFamily: 'Arial',
    fontSize: 27,
  },

  txtLine : {
    width: 1000,
    height: 4,
    backgroundColor: '#02D68C',
    marginBottom: 20,
  },

  listInfs : {
    height: 150,
    // backgroundColor: 'red',
    marginTop: 10,
    flexDirection: 'row',
  },

  list : {
    flex: 0.25,
    // backgroundColor: 'green',
    justifyContent: 'center',
    justifyContent: 'space-around',
  },

  listText : {
    fontSize: 20,
    textTransform: 'capitalize',
    fontFamily: 'Arial',
  },

  infs : {
    flex: 0.75,
    // backgroundColor: 'blue',
    justifyContent: 'center',
    justifyContent: 'space-around',
  },

  infsText : {
    fontSize: 20,
    fontFamily: 'Arial',
  },

  infsLine: {
    marginTop: 30,
    margin: 'auto',
    width: 300,
    height: 3,
    backgroundColor: '#006B49',
  },
});