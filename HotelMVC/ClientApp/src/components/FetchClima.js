import { Button } from "bootstrap";
import React, { Component } from "react"
import { Link } from 'react-router-dom'

export class FetchClima extends Component {
  static displayName = "Climas";

  constructor() {
    super();
    this.state = { clima: [], loading: true }
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
    let contents = this.state.loading
      ? <p><em> Carregando... </em> </p>
      : FetchClima.renderClimaTabela(this.state.clima);


    return (

      <div>
        <h2 id="tableLabel">Climas</h2>
        <br></br>

        <div>
          <label for="cars">Estados: </label>
          <select name="cars" id="cars">
            <option value="volvo">Volvo</option>
            <option value="saab">Saab</option>
            <option value="opel">Opel</option>
            <option value="audi">Audi</option>
          </select>
        </div>
        <div>
          <label for="cars">Estados: </label>
          <select name="cars" id="cars">
            <option value="volvo">Volvo</option>
            <option value="saab">Saab</option>
            <option value="opel">Opel</option>
            <option value="audi">Audi</option>
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