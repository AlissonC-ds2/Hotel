import React, { Component } from "react"


export class Cliente {
  constructor() {
    this.id = 0;
    this.nome = "";
    this.cidade = "";
    this.endereco = "";
    this.nacionalidade = "";
  }
}


export class AddCliente extends Component {
  constructor(props) {
    debugger;
    super(props);
    this.state = { title: "", cliente: new Cliente(), loading: true };
    this.inicialize();

    this.handleSave = this.handleSave.bind(this);
    this.handleCancel = this.handleCancel.bind(this);
  }


  async inicialize() {
    debugger;

    const search = this.props.location.search; // returns the URL query String
    const params = new URLSearchParams(search);
    let id = parseInt(params.get('id'));


    if (id > 0) {
      const response = await fetch('https://localhost:44344/api/cliente/' + id);
      const data = await response.json();

      this.setState({ title: "Edição", cliente: data, loading: false });

    }

    this.state = { title: "Cadastrar", cliente: new Cliente(), loading: false };
  }


  render() {
    let contents = this.state.loading
      ? <p><em> Carregando... </em> </p>
      : this.renderCreateForm();

    return (
      <div>
        <h1>{this.state.title}</h1>
        <h3>Cliente</h3>
        {contents}
      </div>
    );
  }

  handleSave(event) {
    debugger;
    event.preventDefault();

    const data = new FormData(event.target);

    if (this.state.cliente.id) {
      const response1 = fetch('https://localhost:44344/api/cliente' + this.state.cliente.id, { method: 'PUT', body: data });
      this.props.history.push('/fetch-User');
    }
    else {
      const response2 = fetch('https://localhost:44344/api/cliente', { method: 'POST', body: data });
      this.props.history.push('/fetch-User');
    }
  }


  handleCancel(event) {
    event.preventDefault();
    this.props.history.push('/fetch-User');
  }

  renderCreateForm() {
    return (
      <form onSubmit={this.handleSave}>
        <div className="form-group row">
          <input type="hidden" name="id" value={this.state.cliente.id} />
        </div>
        <div className="form-group row">
          <label for="inputNome" class="col-sm-1 control-label">Nome</label>
          <div className="col-md-6">
            <input className="form-control" placeholder="Nome" type="text" name="nome" defaultValue={this.state.cliente.nome} required />
          </div>
        </div>

        <div className="form-group row">
          <label for="inputCidade" class="col-sm-1 control-label">Cidade</label>
          <div className="col-md-5">
            <input className="form-control" type="text" name="cidade" defaultValue={this.state.cliente.cidade} required />
          </div>
        </div>

        <div className="form-group row">
          <label for="inputEndereco" class="col-sm-1 control-label">Endereço</label>
          <div className="col-md-4">
            <input className="form-control" type="text" name="endereco" defaultValue={this.state.cliente.endereco} required />
          </div>
        </div>

        <div className="form-group row">
          <label for="inputNacionalidade" class="col-sm-2 control-label">Nacionalidade</label>
          <div className="col-md-3">
            <input className="form-control" type="text" name="nacionalidade" defaultValue={this.state.cliente.nacionalidade} required />
          </div>
        </div>

        <div className="form-group">
          <button type="submit" className="btn btn-success" value={this.state.cliente.id}>Salvar</button>
          <button className="btn btn-danger" onClick={this.handleCancel}>Cancelar</button>
        </div>
      </form>
    );
  }


}