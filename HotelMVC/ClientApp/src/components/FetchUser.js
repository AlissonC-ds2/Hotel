import React, { Component } from "react"
import { Link } from 'react-router-dom'

export class FetchUser extends Component {
  static displayName = "Clientes";


  constructor() {
    super();
    this.state = { clientes:[], loading: true}
  }


  componentDidMount() {
    this.populaClienteData();
  }


  static handleEdit(id) {
    window.location.href = "/usuario/put" + id;
  }


  static handleDelete(id) {
    if (!window.confirm("você deseja excluir o cliente?")) {
      return;
    }

    fetch("api/cliente" + id, { method: 'delete' })
      .then(json => {
        window.location.href = "fetch-user";
        alert('Deletado da base com sucesso.')
      });
   
  }

  //static renderClienteTabela(clientes) {

  //  return (
  //    <table className='table table-striped' aria-labelledby="tableLabel">
  //      <thead>
  //        <tr>
  //          <th>Código</th>
  //          <th>Nome</th>
  //          <th>Cidade</th>
  //          <th>Endereco</th>
  //          <th>Nacionalidade</th>
  //          <th></th>
  //        </tr>
  //      </thead>
  //      <body>
  //        {clientes.map(c =>
  //          <tr key={c.id}>
  //            <td> { c.id} </td>
  //            <td> {c.nome}</td>
  //            <td> {c.cidade}</td>
  //            <td> {c.endereco}</td>
  //            <td> {c.nacionalidade}</td>
  //            <td>
  //              <button className="btn btn-sucess" onClick={(id) => this.handleEdit(c.id)}>Edit</button> &nbsp;
  //              <button className="btn btn-danger" onClick={(id) => this.handleDelete(c.id)}>Delete</button>;
  //            </td>

  //          </tr>

  //          )}
  //      </body>
  //    </table>
  //    );
  //}

  static renderClienteTabela(clientes) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Código</th>
            <th>Nome</th>
            <th>Cidade</th>
            <th>Endereco</th>
            <th>Nacionalidade</th>
          </tr>
        </thead>
        <tbody>
          {clientes.map(c =>
            <tr key={c.id}>
              <td> {c.id} </td>
              <td> {c.nome}</td>
              <td> {c.cidade}</td>
              <td> {c.endereco}</td>
              <td> {c.nacionalidade}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }







  render() {
    let contents = this.state.loading
      ? <p><em> Carregando... </em> </p>
      : FetchUser.renderClienteTabela(this.state.clientes);


    return (
      <div>
        <h1 id="tableLabel">Clientes</h1>
        <p>Tela de listagem de Clientes</p>


        <p>
          <Link to= "/add-cliente">Cadastrar Cliente</Link>
          
        </p>

        { contents }

      </div>
      );
  }



  async populaClienteData() {
    debugger;
    const response = await fetch("https://localhost:44344/api/cliente");
    const data = await response.json();

    this.setState({ clientes: data, loading: false })
  }


}