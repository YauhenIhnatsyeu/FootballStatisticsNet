import React, { Component } from "react";

import PropTypes from "prop-types";

import InputForm from "Components/inputForm/InputForm";
import inputProps from "Constants/inputProps";

export default class RegisterPage extends Component {
    handleSubmit = (e, user) => {
        e.preventDefault();
        this.props.register(user);
    }

    render() {
        return (
            <InputForm
                inputProps={inputProps.register}
                submitValue="Register"
                onSubmit={this.handleSubmit}
            />
        );
    }
}

RegisterPage.propTypes = {
    register: PropTypes.func.isRequired,
};
