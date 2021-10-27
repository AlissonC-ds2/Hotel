import { Button } from "bootstrap";
import React, { Component } from "react"
import { Form, Field } from 'react-advanced-form'
import { Link } from 'react-router-dom'
import { AgGridColumn, AgGridReact } from 'ag-grid-react';

import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-balham.css';


export class FetchEstado extends Component {
  static displayName = "Estados";


  constructor() {
    super();
    this.state = { estados: [], loading: true }
  }


  componentDidMount() {
    this.populaEstadoData();
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
    const container = {
      height: '500px',
      width: '410px',
    }

    return (
      <Form>
        <div
          className="ag-theme-balham"
          style={container}
        >
          <AgGridReact
            pagination={true}
            // rowData retorna os dados do grid
            rowData={estados}>
            <AgGridColumn field="nome" sortable={true}></AgGridColumn>
            <AgGridColumn field="sigla" sortable={true}></AgGridColumn>
          </AgGridReact>
        </div>
      </Form>

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


  async populaEstadoData() {
    debugger;
    const response = await fetch("https://localhost:44344/api/estado/GetAll");
    const data = await response.json();

    this.setState({ estados: data, loading: false })
  }

}
