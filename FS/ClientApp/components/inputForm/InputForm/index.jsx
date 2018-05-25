import React, { Component } from "react";

import PropTypes from "prop-types";

import validate from "Helpers/validationHelper";

import LabelInput from "../LabelInput";

import "./index.css";

export default class InputForm extends Component {
    constructor(props) {
        super(props);

        const model = {};

        Object.keys(props.inputProps).map((key) => {
            model[key] = props.inputProps[key].value;
            return null;
        });

        this.state = {
            model,
            errorMessages: [],
        };
    }

    handleChange = (e) => {
        const { name: inputName, value: inputValue } = e.target;
        this.state.model[inputName] = inputValue;
    }

    handleSubmit = (e) => {
        e.preventDefault();

        const { model } = this.state;
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
