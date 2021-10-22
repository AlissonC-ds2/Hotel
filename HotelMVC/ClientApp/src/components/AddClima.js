import React, { Component} from "react";
import { Form, Field } from 'react-advanced-form'
import { Input, Button, Select } from 'react-advanced-form-addons'


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

let estadoId = 0;

export  class AddClima extends Component {

  constructor(props) {
    debugger;
    super(props);
    this.state = { clima: [], loading: true, estados: [new Estado], cidades: [new Cidade] }

    this.handleChange = this.handleChange.bind(this);
  };


  registerUser = ({ serialized, fields, form }) => {

    debugger;
    let teste = serialized;


    return fetch('https://backend.dev', {
      body: JSON.stringify(serialized)
    })
  }


  componentDidMount() {
    /*this.populaClimaData();*/
    fetch('https://localhost:44344/api/estado/getall')
      .then(response => response.json())
      .then(data => {
        this.setState({ estados: data });
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

    let teste = this.state.cidades;

    if (estadoId != 0) {
      fetch('https://localhost:44344/api/cidade/' + estadoId)
        .then(response => response.json())
        .then(data => {
            this.setState({ cidades: data });
        });
    }
  }


  render() {  
    const colunas = {
      display: 'inline-block',
      //position: 'relative',
      width: '270px'
    }

    return (
    <Form
      action={this.registerUser}>

      <div style={colunas}>
        <Select name="estado" label="Estado" onChange={this.handleChange}>
          <option disabled selected>Selecione um estado</option>
          {this.state.estados.map(x =>
            <option key={x.id} value={x.id}>{x.nome}</option>
          )}
        </Select>
      </div>

      <div style={colunas}>
        <Select name="cidade" label="Cidade">
          {this.state.cidades.map(x =>
            <option key={x.id} value={x.id}>{x.nome}</option>
          )}
        </Select>
      </div>

      <div style={colunas}>
        <Input
          name="data"
          label="Data"
          type="date"
          required />
      </div>

      <div style={colunas}>
        <Input
          name="temperatura"
          label="Temperatura"
          required />
      </div>

      <div style={colunas}>
        <Input
          name="temperaturamax"
          label="Temperatura maxima"
          required />
      </div>
      <div style={colunas}>
        <Input
          name="temperaturamin"
          label="Temperatura minima"
          required />
        </div>
      <div style={colunas}>
        <Input
          name="descricao"
          label="Descrição"
          required />
      </div>
      <div style={colunas}>
        <Input
          name="umidade"
          label="Umidade"
          required />
      </div>
      <div style={colunas}>
        <Input
          name="pressaoAtm"
          label="Pressão Atmosférica"
          required />
      </div>
      <div style={colunas}>
        <Input
          name="tipoClima"
          label="Tipo Clima"
          required />
      </div>

      <Button primary>Cadastrar Clima</Button>
    </Form>
    );
  }
}