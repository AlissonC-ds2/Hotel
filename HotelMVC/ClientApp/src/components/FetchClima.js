import { Button } from "bootstrap";
import React, { Component } from "react"
import { Link } from 'react-router-dom'

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

export class FetchClima extends Component {
  static displayName = "Climas";

  constructor() {
    super();
    this.state = { clima: [], loading: true, estados: [new Estado], cidades: [new Cidade] }
  }

  componentDidMount() {
    this.populaClimaData();
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

    const combobox = {
      width: '200px',
      height: '100px',
      display: 'inline-block'
    }

    let contents = this.state.loading
      ? <p><em> Carregando... </em> </p>
      : FetchClima.renderClimaTabela(this.state.clima);

    return (
      <div>
        <h2 id="tableLabel">Climas</h2>
        <br></br>

        <div style={combobox}>
          <label for="combobox">Estados: </label>
          <select>
            <option disabled selected>Selecione um estado</option>
            {this.state.estados.map(x =>
              <option key={x.id}>{x.nome}</option>
            )}

          </select>
        </div>
        <div style={combobox}>
          <label for="combobox">Cidades: </label>
          <select>
            <option disabled selected>Selecione uma cidade</option>
            {this.state.cidades.map(x =>
              <option key={x.id}>{x.nome}{x.estadoId}</option>
            )}

          </select>
        </div>


        {contents}

      </div>

    );
  }

  async populaClimaData() {
    debugger;
    const response = await fetch("https://localhost:44344/api/clima/GetAll");
    const data = await response.json();

    this.setState({ clima: data, loading: false })
  }
}