import React, { Component } from "react";
import { Form, Field } from 'react-advanced-form'
import { Input, Button, Select } from 'react-advanced-form-addons'


let estadoId = 0;

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
    debugger;
    super(props);
    this.state = { clima: [], loading: true, estados: [new Estado], cidades: [new Cidade] }

    this.handleChange = this.handleChange.bind(this);
  }

  componentDidMount() {
    this.populaClimaData();
    fetch('https://localhost:44344/api/estado/getall')
      .then(response => response.json())
      .then(data => {
        this.setState({ estados: data });
      });
  }

  handleChange({ event }) {
    debugger;
    let abc = this.state.estados;
    abc.id = event.target.value;

    estadoId = parseInt(abc.id);

    this.setState({ abc: abc });

    if (estadoId != 0) {
      fetch('https://localhost:44344/api/cidade/' + estadoId)
        .then(response => response.json())
        .then(data => {
          this.setState({ cidades: data });
        });
    }
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
      width: '300px',
      display: 'inline-block'
    }

    const pesquisar = {
      width: '200px',
      height: '46px',
      display: 'inline-block',
      background: 'lightblue'
    }

    debugger;
    return (
      <Form>
        <div>
          <h2 id="tableLabel">Climas</h2>
          <br></br>

          <div style={combobox}>
            <label>Estados: </label>
            <Select onChange={this.handleChange}>
              <option disabled selected>Selecione um estado</option>
              {this.state.estados.map(x =>
                <option key={x.id} value={x.id}>{x.nome}</option>
              )}

            </Select>
          </div>
          <div style={combobox}>
            <label>Cidades: </label>
            <Select>
              <option disabled selected>Selecione uma cidade</option>
              {this.state.cidades.map(x =>
                <option key={x.id} value={x.id}>{x.nome}</option>
              )}

            </Select>
          </div>

          <p style={combobox}>
            <button style={pesquisar}>Pesquisar Climas</button>
          </p>

        </div>
      </Form>
    );
  }

  async populaClimaData() {
    debugger;
    const response = await fetch("https://localhost:44344/api/clima/GetAll");
    const data = await response.json();

    this.setState({ clima: data, loading: false })
  }
}
