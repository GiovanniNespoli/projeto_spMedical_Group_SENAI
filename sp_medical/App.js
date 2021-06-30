import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

import User from './src/pages/user'
import Login from './src/pages/login'
import Medico from './src/pages/medico'

const AuthStack = createStackNavigator();

export default function Stack(){
  return(
    <NavigationContainer>
      <AuthStack.Navigator
        headerMode = 'none'
      >
        <AuthStack.Screen name = 'login' component={Login} />
        <AuthStack.Screen name = 'user' component={User} />
        <AuthStack.Screen name = 'medico' component={Medico} />
      </AuthStack.Navigator>
    </NavigationContainer>
  )
}