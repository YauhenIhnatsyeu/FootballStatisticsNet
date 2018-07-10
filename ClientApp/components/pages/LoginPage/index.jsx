import React, { Component } from "react";

import PropTypes from "prop-types";

import inputProps from "Constants/inputProps";

import Form from "Components/form/Form";

import { renderInputs } from "Helpers/formHelper";

import { Link } from "react-router-dom";

import routePaths from "Constants/routePaths";

export default class LoginPage extends Component {
    handleSubmit = (user) => {
        this.props.login(user);
    }

    render() {
        return (
            <React.Fragment>
                <Form
                    submitValue="Login"
                    onSubmit={this.handleSubmit}
                >
                    {renderInputs(inputProps.login)}
                </Form>
                <br />
                <Link to={routePaths.register}>If you haven{"'"}t got an account, create one</Link>
            </React.Fragment>
        );
    }
}

LoginPage.propTypes = {
    login: PropTypes.func.isRequired,
};
