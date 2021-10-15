import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { FetchUser } from './components/FetchUser';
import { FetchCidade } from './components/FetchCidade';
import { AddCliente } from './components/AddCliente';



import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/fetch-user' component={FetchUser} />
        <Route path='/fetch-cidade' component={FetchCidade} />
        <Route path='/add-cliente' component={AddCliente} />
        <Route path='/cliente/put/:id' component={AddCliente} />
      </Layout>
    );
  }
}
