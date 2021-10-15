import { Button } from "bootstrap";
import React, { Component } from "react"
import { Link } from 'react-router-dom'


let unidadeId = 0;

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

  async handleChange(event) { 
    debugger;
    let abc = this.state.estados;
    abc.id = event.target.value;
    unidadeId = parseInt(abc.id);

    this.setState({ abc: abc });

    let teste = this.state.cidades;

    if (unidadeId != 0) {

      fetch('https://localhost:44344/api/cidade/' + unidadeId)
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
          <label>Estados: </label>
          <select onChange={this.handleChange}>
            <option disabled selected>Selecione um estado</option>
            {this.state.estados.map(x =>
              <option key={x.id} value={x.id}>{x.nome}</option>
            )}

          </select>
        </div>
        <div style={combobox}>
          <label>Cidades: </label>
          <select onChange={this.handleChange}>
            <option disabled selected>Selecione uma cidade</option>
            {this.state.cidades.map(x =>
              <option key={x.id} value={x.id}>{x.nome}</option>
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