import React, { Component, useEffect, useState } from "react";


export class Estado {
  constructor() {
    this.id = 0;
    this.nome = "";
    this.sigla = -1;
  }
}


export class AddEstado extends Component {
  constructor(props) {
    super(props);
    this.state = { title: "", estado: new Estado(), loading: true };

    this.handleSave = this.handleSave.bind(this);
    this.handleCancel = this.handleCancel.bind(this);
    this.handleChange = this.handleChange.bind(this);
  }

  //quando monta o componente ele chama essa função
  componentDidMount() {
    this.state = { title: "Cadastrar", estado: new Estado(), loading: false };

    fetch('https://localhost:44344/api/estado/getall')
      .then(response => response.json())
      .then(data => {
        this.setState({ estados: data });
      });
  }

  render() {
    let contents = this.renderCreateForm();

    return (
      <div>
        <h1>{this.state.title}</h1>
        <h3>Estado</h3>
        {contents}
      </div>
    );
  }

  handleSave(event) {
    event.preventDefault();

    const data = new FormData(event.target);
    data.append("sigla", this.state.estado.sigla);

    const response2 = fetch('https://localhost:44344/api/estado', { method: 'POST', body: data });
    this.props.history.push('/fetch-Estado');

  }


  handleCancel(event) {
    event.preventDefault();
    this.props.history.push('/fetch-Estado');
  }

  handleChange(event) {
    let estado = this.state.estado;
    estado.sigla = parseInt(event.target.value);

    this.setState({ estado: estado });
  }

  renderCreateForm() {

    const ESigla = [
      { value: 0, label: 'AC' },
      { value: 1, label: 'AL' },
      { value: 2, label: 'AP' },
      { value: 3, label: 'AM' },
      { value: 4, label: 'BA' },
      { value: 5, label: 'CE' },
      { value: 6, label: 'DF' },
      { value: 7, label: 'ES' },
      { value: 8, label: 'GO' },
      { value: 9, label: 'MA' },
      { value: 10, label: 'MT' },
      { value: 11, label: 'MS' },
      { value: 12, label: 'MG' },
      { value: 13, label: 'PA' },
      { value: 14, label: 'PB' },
      { value: 15, label: 'PR' },
      { value: 16, label: 'PE' },
      { value: 17, label: 'PI' },
      { value: 18, label: 'RJ' },
      { value: 19, label: 'RN' },
      { value: 20, label: 'RS' },
      { value: 21, label: 'RO' },
      { value: 22, label: 'RR' },
      { value: 23, label: 'SC' },
      { value: 24, label: 'SP' },
      { value: 25, label: 'SE' },
      { value: 26, label: 'TO' },
    ]

    return (
      <form onSubmit={this.handleSave}>
        <div className="form-group row">
          <input type="hidden" name="id" value={this.state.estado.id} />
        </div>
        <div className="form-group row">
          <label htmlFor="inputNome" className="col-sm-1 control-label">Nome</label>
          <div className="col-md-6">
            <input className="form-control" placeholder="Nome" type="text" name="nome" defaultValue={this.state.estado.nome} required />
          </div>
        </div>
        <div className="form-group row">
          <select form="carform" name="sigla" onChange={this.handleChange}>
            <option>Selecione uma Sigla</option>
            {ESigla.map(x =>
              <option key={x.value} value={x.value}>{x.label}</option>
            )}

          </select>
        </div>

        <div className="form-group">
          <button type="submit" className="btn btn-success" value={this.state.estado.id}>Salvar</button>
          <button className="btn btn-danger" onClick={this.handleCancel}>Cancelar</button>
        </div>
      </form>
    );
  }
}