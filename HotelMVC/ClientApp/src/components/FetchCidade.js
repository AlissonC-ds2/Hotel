import { Button } from "bootstrap";
import React, { Component } from "react"
import { Link } from 'react-router-dom'


export class FetchCidade extends Component {
  static displayName = "Cidades";


  constructor() {
    super();
    this.state = { cidades: [], loading: true }
  }


  componentDidMount() {
    this.populaCidadeData();
  }


  static handleEdit(id) {
    debugger;
    window.location.href = `/add-cidade?id=${id}`;
  }


  static handleDelete(id) {
    if (!window.confirm("você deseja excluir o cidade?")) {
      return;
    }

    fetch("api/cliente" + id, { method: 'delete' })
      .then(json => {
        window.location.href = "fetch-cidade";
        alert('Deletado da base com sucesso.')
      });

  }



  static renderCidadeTabela(cidades) {
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
            <th>Estado</th>
            <th>Editar</th>
            <th>Deletar</th>
          </tr>
        </thead>
        <tbody style={body}>
          {cidades.map(c =>
            <tr key={c.id}>
              <td> {c.id} </td>
              <td> {c.nome}</td>
              <td> {c.estadoNome}</td>
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
      : FetchCidade.renderCidadeTabela(this.state.cidades);


    return (
      <div>
        <h1 id="tableLabel">Cidades</h1>
        <p>Tela de listagem de Cidades</p>

        <p>
          <Link to="/add-cidade"><button className="btn btn-success">Cadastrar Cidade</button></Link>
        </p>

        {contents}

      </div>
    );
  }


  async populaCidadeData() {
    debugger;
    const response = await fetch("https://localhost:44344/api/cidade/getallcidadesestado");
    const data = await response.json();

    this.setState({ cidades: data, loading: false })
  }

}