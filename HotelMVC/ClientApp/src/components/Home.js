import React, { Component } from "react";
import { Form, Field } from 'react-advanced-form'
import { Input, Button, Select } from 'react-advanced-form-addons'
import { AgGridColumn, AgGridReact } from 'ag-grid-react';
import axios from 'axios'

import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-balham.css';


let estadoId = 0;
let cidadeId = 0;

export class Cidade {
  constructor() {
    this.id = 0;
    this.nome = "";
    this.estadoId = 0;
  }
}

export class Estado {
  constructor() {
    this.id = 0;
    this.nome = "";
  }
}

export class Home extends Component {
  static displayName = "Climas";

  constructor(props) {
    super(props);
    this.state = { clima: [], loading: true, estados: [new Estado], estados2: [new Estado], cidades: [new Cidade], cidades2: [new Cidade] }

    this.handleChange = this.handleChange.bind(this);
    this.handleChang2 = this.handleChang2.bind(this);
  }
  componentDidMount() {
    //this.populaClimaData();
    fetch('https://localhost:44344/api/estado/getall')
      .then(response => response.json())
      .then(data => {
        this.setState({ estados: data, estados2: data });
      });
  }

  

  handleChange = ({
    event,
    nextValue,
    prevValue,
    fieldProps,
    fields,
    form
  }) => {
    debugger;
    let abc = this.state.estados;

    estadoId = parseInt(nextValue);

    this.setState({ abc: abc });

    if (estadoId != 0) {
      fetch('https://localhost:44344/api/cidade/' + estadoId)
        .then(response => response.json())
        .then(data => {
          this.setState({ cidades: data });
        });
    }
  }

  handleChang2 = ({
    event,
    nextValue,
    prevValue,
    fieldProps,
    fields,
    form
  }) => {
    debugger;
    let abc = this.state.estados2;

    estadoId = parseInt(nextValue);

    this.setState({ abc: abc });

    if (estadoId != 0) {
      fetch('https://localhost:44344/api/cidade/' + estadoId)
        .then(response => response.json())
        .then(data => {
          this.setState({ cidades2: data });
        });
    }
  }

  handleChangeCidade = ({ nextValue }) => {
    debugger;
    cidadeId = parseInt(nextValue);;
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
  }

  render() {
    debugger;
    const combobox = {
      width: '370px',
      display: 'inline-block',
      height: '85px',
    }

    const pesquisar = {
      width: '200px',
      height: '46px',
      display: 'inline-block',
      background: 'lightblue'
    }
    const div = {
      display: 'inline-block',
      height: '800px',
    }
    const container = {
      height: '500px',
      width: '1100px',
    }


    debugger;
    return (
      <Form>
        <div style={div}>
          <h2 id="tableLabel">Climas</h2>
          <br></br>

          <div style={combobox}>
            <Select name="estado" label="Estado" onChange={this.handleChange}>
              <option selected>Selecione um Estado</option>
              {this.state.estados.map(x =>
                <option key={x.id} value={x.id}>{x.nome}</option>
              )}

            </Select>
          </div>
          <div style={combobox}>
            <Select name="cidade" label="Cidade" onChange={this.handleChangeCidade}>
              <option selected>Selecione uma Cidade</option>
              {this.state.cidades.map(x =>
                <option key={x.id} value={x.id}>{x.nome}</option>
              )}

            </Select>
          </div>

          <p style={combobox}>
            <button onClick={this.populaClimaData} style={pesquisar}>Pesquisar Climas</button>
          </p>

          <div
            className="ag-theme-balham"
            style={container}
          >
            <AgGridReact
              pagination={true}
              // rowData retorna os dados do grid
              rowData={this.state.rowData}>
              <AgGridColumn field="TemperaturaMax" sortable={true}></AgGridColumn>
              <AgGridColumn field="TemperaturaMin" sortable={true}></AgGridColumn>
              <AgGridColumn field="Temperatura" sortable={true}></AgGridColumn>
              <AgGridColumn field="Descricao" sortable={true}></AgGridColumn>
              <AgGridColumn field="Umidade" sortable={true}></AgGridColumn>
              <AgGridColumn field="Cidade" sortable={true}></AgGridColumn>
              <AgGridColumn field="Data" sortable={true}></AgGridColumn>
              <AgGridColumn field="TipoClima" sortable={true}></AgGridColumn>

            </AgGridReact>
          </div>
        </div>


        <div style={div}>
          <div style={combobox}>
            <Select name="estado2" label="Estado" onChange={this.handleChang2}>
              <option selected>Selecione um Estado</option>
              {this.state.estados2.map(x =>
                <option key={x.id} value={x.id}>{x.nome}</option>
              )}

            </Select>
          </div>
          <div style={combobox}>
            <Select name="cidade2" label="Cidade" onChange={this.handleChangeCidade}>
              <option selected>Selecione uma Cidade</option>
              {this.state.cidades2.map(x =>
                <option key={x.id} value={x.id}>{x.nome}</option>
              )}

            </Select>
          </div>
         
          <p style={combobox}>
            <button onClick={this.populaClimaData} style={pesquisar}>Pesquisar Climas</button>
          </p>

          <div
            className="ag-theme-balham"
            style={container}
          >
            <AgGridReact
              pagination={true}
              // rowData retorna os dados do grid
              rowData={this.state.rowData}>
              <AgGridColumn field="TemperaturaMax" sortable={true}></AgGridColumn>
              <AgGridColumn field="TemperaturaMin" sortable={true}></AgGridColumn>
              <AgGridColumn field="Temperatura" sortable={true}></AgGridColumn>
              <AgGridColumn field="Descricao" sortable={true}></AgGridColumn>
              <AgGridColumn field="Umidade" sortable={true}></AgGridColumn>
              <AgGridColumn field="Data" sortable={true}></AgGridColumn>
              <AgGridColumn field="TipoClima" sortable={true}></AgGridColumn>
              <AgGridColumn field="Cidade" sortable={true}></AgGridColumn>
              <AgGridColumn field="Sigla" sortable={true}></AgGridColumn>

            </AgGridReact>
          </div>
        </div>
      </Form>
    );
  }
  
  async populaClimaData() {
    debugger;
    const response = await fetch('https://localhost:44344/api/clima/' + cidadeId);
    const data = await response.json();

    this.setState({ clima: data, loading: false })
  }
}
