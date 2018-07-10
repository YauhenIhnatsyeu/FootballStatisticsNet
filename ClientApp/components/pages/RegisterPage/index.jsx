import React, { Component } from "react";

import PropTypes from "prop-types";

import inputProps from "Constants/inputProps";

import Form from "Components/form/Form";
import Input from "Components/form/Input";

import { renderInputs } from "Helpers/formHelper";

import { retrieveNameAndValueFromFileEvent } from "Utilities/retrieveNameAndValueFunctions";

export default class RegisterPage extends Component {
    handleSubmit = (user) => {
        this.props.register(user);
    }

    render() {
        return (
            <Form
                submitValue="Register"
                onSubmit={this.handleSubmit}
            >
                {[
                    ...renderInputs(inputProps.register),
                    <Input
                        name="avatar"
                        type="file"
                        label="Profile picture"
                        retrieveNameAndValueFunc={retrieveNameAndValueFromFileEvent}
                        key={Object.keys(inputProps.register).length}
                    />,
                ]}
            </Form>
        );
    }
}

RegisterPage.propTypes = {
    register: PropTypes.func.isRequired,
};
