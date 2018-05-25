import React, { Component } from "react";

import PropTypes from "prop-types";

import InputForm from "Components/inputForm/InputForm";
import inputProps from "Constants/inputProps";

import { Link } from "react-router-dom";

import routePaths from "Constants/routePaths";

export default class LoginPage extends Component {
    handleSubmit = (user) => {
        this.props.login(user);
    }

    render() {
        return (
            <React.Fragment>
                <InputForm
                    inputProps={inputProps.login}
                    submitValue="Login"
                    onSubmit={this.handleSubmit}
                />
                <br />
                <Link to={routePaths.register}>If you haven{"'"}t got an account, create one</Link>
            </React.Fragment>
        );
    }
}

LoginPage.propTypes = {
    login: PropTypes.func.isRequired,
};
