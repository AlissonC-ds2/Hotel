import React, { Component} from "react";
import { Form, Field } from 'react-advanced-form'
import { Input, Button, Select } from 'react-advanced-form-addons'


export  class AddClima extends Component {

  registerUser = ({ serialized, fields, form }) => {

    debugger;
    let teste = serialized;


    return fetch('https://backend.dev', {
      body: JSON.stringify(serialized)
    })
  }



  render() {
    return (
      <Form
        action={this.registerUser}>
        <Field.Group name="primaryInfo">
          <Input
            name="userEmail"
            type="email"
            label="E-mail"
            required />
        </Field.Group>

        <Input
          name="userPassword"
          type="password"
          label="Password"
          required />
        <Input
          name="confirmPassword"
          type="password"
          label="Confirm password"
          required
          skip />

        <Select>
          <option value="admin">Administrator</option>
          <option value="editor">Editor</option>
        </Select>

        <Field.Group name="primaryInfo">
          <Input
            name="firstName"
            label="First name"
            required={({ get }) => {
              return !!get(['primaryInfo', 'lastName', 'value'])
            }} />
          <Input
            name="lastName"
            label="Last name"
            required={({ get }) => {
              return !!get(['primaryInfo', 'firstName', 'value'])
            }} />
        </Field.Group>



        <Button primary>Register</Button>
      </Form>
    );
  }




}