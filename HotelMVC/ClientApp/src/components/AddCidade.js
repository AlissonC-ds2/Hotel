import React, { Component, useEffect } from "react";

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
    debugger;
    super(props);
    this.state = { title: "", cidade: new Cidade(), loading: true, estados: [new Estado] };

    this.handleSave = this.handleSave.bind(this);
    this.handleCancel = this.handleCancel.bind(this);

  }


  componentDidMount() {
    debugger;
    this.populaCidadeData();
    fetch('https://localhost:44344/api/estado/getall')
      .then(response => response.json())
      .then(data => {
        this.setState({ estados: data });
      });
  }

  render() {
    debugger;
    let contents = this.renderCreateForm();

    return (
      <div>
        <h1>{this.state.title}</h1>
        <h3>Cliente</h3>
        {contents}
      </div>
    );
  }


  handleSave(event) {
    event.preventDefault();

    const data = new FormData(event.target);

    if (this.state.cidade.id) {
      const response1 = fetch('https://localhost:44344/api/cidade' + this.state.cidade.id, { method: 'PUT', body: data });
      //this.props.history.push('/fetch-User');
    }
    else {
      const response2 = fetch('https://localhost:44344/api/cidade', { method: 'POST', body: data });
      //this.props.history.push('/fetch-User');
    }
  }

  handleCancel(event) {
    event.preventDefault();
    this.props.history.push('/fetch-cidade');
  }


  renderCreateForm() {
    debugger;
    return (
      <form onSubmit={this.handleSave}>
        <div className="form-group row">
          <input type="hidden" name="id" value={this.state.cidade.id} />
        </div>

        <div className="form-group row">
          <label for="inputNome" class="col-sm-1 control-label">Nome</label>
          <div className="col-md-6">
            <input className="form-control" placeholder="Nome" type="text" name="nome" defaultValue={this.state.cidade.nome} required />
          </div>
        </div>

        <div>
          <select>
            <option disabled selected>Selecione um estado</option>
            {this.state.estados.map(x =>
              <option key={x.id}>{x.nome}</option>
            )}

          </select>
        </div>
      </form>
    );
  }


  async populaCidadeData() {
    const search = this.props.location.search; // returns the URL query String
    const params = new URLSearchParams(search);
    let id = parseInt(params.get('id'));


    if (id > 0) {
      const response = await fetch('https://localhost:44344/api/cidade/' + id);
      const data = await response.json();

      this.setState({ title: "Edição", cidade: data, loading: false });

    }

    this.state = { title: "Cadastrar", cidade: new Cidade(), loading: false};

  }

}