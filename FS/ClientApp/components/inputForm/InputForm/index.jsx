import React, { Component } from "react";

import PropTypes from "prop-types";

import validate from "Helpers/validationHelper";

import LabelInput from "../LabelInput";

import "./index.css";

export default class InputForm extends Component {
    constructor(props) {
        super(props);

        this.model = {};

        // Filling in model with values from inputProps
        Object.keys(props.inputProps).map((key) => {
            this.model[key] = props.inputProps[key].value;
            return null;
        });

        this.state = {
            errorMessages: [],
        };
    }

    handleChange = (value, name) => {
        this.model[name] = value;
    }

    handleSubmit = (e) => {
        e.preventDefault();

        const { model } = this;
        const { inputProps, onSubmit } = this.props;

        const errorMessages = Object.keys(model).map(key =>
            validate(model[key], inputProps[key].validationOptions));

        if (errorMessages.every(i => i === null) && onSubmit) {
            onSubmit(model);
            return;
        }

        this.setState({
            errorMessages,
        });
    }

    render() {
        const { inputProps, submitValue } = this.props;

        return (
            <div className="form-container">
                <form className="form" onSubmit={this.handleSubmit}>
                    {inputProps && Object.keys(inputProps).map((key, index) => (
                        <LabelInput
                            key={index}
                            inputProps={inputProps[key]}
                            onChange={this.handleChange}
                            errorMessage={this.state.errorMessages[index]}
                        />
                    ))}
                    <input
                        className="form__input form__submit"
                        type="submit"
                        value={submitValue || "Submit"}
                    />
                </form>
            </div>
        );
    }
}

InputForm.propTypes = {
    inputProps: PropTypes.shape({}),
    submitValue: PropTypes.string,
    onSubmit: PropTypes.func,
};

InputForm.defaultProps = {
    inputProps: null,
    submitValue: null,
    onSubmit: null,
};
