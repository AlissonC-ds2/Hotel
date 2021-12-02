import React, { Component, useEffect, useState } from "react";

//componentes

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

export class AddCidade extends Component {
  constructor(props) {
    super(props);
    this.state = { title: "", cidade: new Cidade(), loading: true, estados: [new Estado] };

    this.handleSave = this.handleSave.bind(this);
    this.handleCancel = this.handleCancel.bind(this);
    this.handleChange = this.handleChange.bind(this);
  }

  //quando monta o componente ele chama essa função
  componentDidMount() {
    this.state = { title: "Cadastrar", cidade: new Cidade(), loading: false };
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
        <h3>Cidade</h3>
        {contents}
      </div>
    );
  }


  handleSave(event) {
    event.preventDefault();

    const data = new FormData(event.target);
    data.append("estadoId", this.state.cidade.estadoId);

    const response2 = fetch('https://localhost:44344/api/cidade', { method: 'POST', body: data });
    this.props.history.push('/fetch-Cidade');

  }

  handleChange(event) {
    var cidade = this.state.cidade;
    cidade.estadoId = event.target.value;

    this.setState({ cidade: cidade});
  }

  handleCancel(event) {
    event.preventDefault();
    this.props.history.push('/fetch-cidade');
  }


  renderCreateForm() {
    return (
      <form id="carform" onSubmit={this.handleSave}>
        <div className="form-group row">
          <input type="hidden" name="id" value={this.state.cidade.id} />
        </div>

        <div className="form-group row">
          <label for="inputNome" className="col-sm-1 control-label">Nome</label>
          <div className="col-md-6">
            <input className="form-control" placeholder="Nome" type="text" name="nome" defaultValue={this.state.cidade.nome} required />
          </div>
        </div>

        <div className="form-group row">
          <select form="carform" onChange={this.handleChange}>
            <option>Selecione um estado</option>
            {this.state.estados.map(x =>
              <option key={x.id} value={x.id}>{x.nome}</option>
            )}
           
          </select>
        </div>

        <div className="form-group">
          <button type="submit" className="btn btn-success" value={this.state.cidade.id}>Salvar</button>
          <button className="btn btn-danger" onClick={this.handleCancel}>Cancelar</button>
        </div>
      </form>
    );
  }
}