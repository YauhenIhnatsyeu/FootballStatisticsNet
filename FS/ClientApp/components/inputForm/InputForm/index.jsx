import React, { Component } from "react";

import PropTypes from "prop-types";

import LabelInput from "../LabelInput";

import "./index.css";

export default class InputForm extends Component {
    constructor(props) {
        super(props);

        this.model = {};
    }

    handleChange = (e) => {
        const { name: inputName, value: inputValue } = e.target;
        this.model[inputName] = inputValue;
    }

    render() {
        const { inputProps, submitValue, onSubmit } = this.props;

        return (
            <div className="form-container">
                <form className="form" onSubmit={e => onSubmit && onSubmit(e, this.model)}>
                    {inputProps && Object.keys(inputProps).map((key, index) => (
                        <LabelInput
                            key={index}
                            inputProps={inputProps[key]}
                            onChange={this.handleChange}
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
