import { Button } from "bootstrap";
import React, { Component } from "react"
import { Form, Field } from 'react-advanced-form'
import { Link } from 'react-router-dom'
import { AgGridColumn, AgGridReact } from 'ag-grid-react';

import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-balham.css';


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

    const container = {
      height: '500px',
      width: '410px',
    }

    return (
      <Form>
        <div>
          <p>
            <Link to="/add-cidade"><button className="btn btn-success">Cadastrar Cidade</button></Link>
          </p>
          {/*<p>*/}
          {/*  <button className="btn btn-success" onClick={(id) => this.handleEdit(cidades.map(x => x.id))}>Editar</button> &nbsp;*/}
          {/*</p>*/}
          {/*<p>*/}
          {/*  <button className="btn btn-danger" onClick={(id) => this.handleDelete(cidades.map(x => x.id))}>Delete</button>*/}
          {/*</p>*/}
        </div>
        <div>
          <div
            className="ag-theme-balham"
            style={container}
          >
            <AgGridReact
              pagination={true}
              // rowData retorna os dados do grid
              rowData={cidades}>
              <AgGridColumn field="nome" sortable={true}></AgGridColumn>
              <AgGridColumn field="estadoNome" sortable={true}></AgGridColumn>
            </AgGridReact>
          </div>
        </div>
        
      </Form>
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