import React, { Component } from "react";

import PropTypes from "prop-types";

import "Css/form.css";

export default class RegisterPage extends Component {
    constructor(props) {
        super(props);

        this.user = {
            login: "",
            password: "",
        };
    }

    handleChange = (e) => {
        const { name: inputName, value: inputValue } = e.target;

        this.user[inputName] = inputValue;

        console.log(JSON.stringify(this.user));
    }

    handleSubmit = (e) => {
        e.preventDefault();

        this.props.register(this.user);
    }

    render() {
        return (
            <form className="form" onSubmit={this.handleSubmit}>
                <input className="form__input" type="text" name="login" onChange={this.handleChange} />
                <input className="form__input" type="password" name="password" onChange={this.handleChange} />
                <input className="form__input" type="submit" value="Register" />
            </form>
        );
    }
}

RegisterPage.propTypes = {
    register: PropTypes.func.isRequired,
};

RegisterPage.defaultProps = {
};
