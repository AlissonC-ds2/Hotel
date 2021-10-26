import { Button } from "bootstrap";
import React, { Component } from "react"
import { Link } from 'react-router-dom'


export class FetchEstado extends Component {
  static displayName = "Estados";


  constructor() {
    super();
    this.state = { estados: [], loading: true }
  }


  componentDidMount() {
    this.populaCidadeData();
  }


  static handleEdit(id) {
    debugger;
    window.location.href = `/add-estado?id=${id}`;
  }


  static handleDelete(id) {
    if (!window.confirm("você deseja excluir o cidade?")) {
      return;
    }

    fetch("api/cliente" + id, { method: 'delete' })
      .then(json => {
        window.location.href = "fetch-estado";
        alert('Deletado da base com sucesso.')
      });

  }



  static renderEstadoTabela(estados) {
    const body = {
      margin: '30px',
      background: '#ffffff',
      color: 'red',
    };

    const table = {
      width: '100%',
      margin: '2.4rem',
      background: '#20262e',
      color: '#fff',
      overflow: 'hidden',
    };


    return (
      <table className='table table-striped' aria-labelledby="tabelLabel" style={table}>
        <thead>
          <tr>
            <th>Código</th>
            <th>Nome</th>
            <th>Sigla</th>
            <th>Editar</th>
            <th>Deletar</th>
          </tr>
        </thead>
        <tbody style={body}>
          {estados.map(c =>
            <tr key={c.id}>
              <td> {c.id} </td>
              <td> {c.nome}</td>
              <td> {c.sigla}</td>
              <td>
                <button className="btn btn-success" onClick={(id) => this.handleEdit(c.id)}>Editar</button> &nbsp;
              </td>
              <td>
                <button className="btn btn-danger" onClick={(id) => this.handleDelete(c.id)}>Delete</button>
              </td>

            </tr>
          )}
        </tbody>
      </table>
    );
  }


  render() {
    let contents = this.state.loading
      ? <p><em> Carregando... </em> </p>
      : FetchEstado.renderEstadoTabela(this.state.estados);


    return (
      <div>
        <h1 id="tableLabel">Estados</h1>
        <p>Tela de listagem de Estados</p>

        <p>
          <Link to="/add-estado"><button className="btn btn-success">Cadastrar Estado</button></Link>
        </p>

        {contents}

      </div>
    );
  }


  async populaCidadeData() {
    debugger;
    const response = await fetch("https://localhost:44344/api/estado/GetAll");
    const data = await response.json();

    this.setState({ estados: data, loading: false })
  }

}
