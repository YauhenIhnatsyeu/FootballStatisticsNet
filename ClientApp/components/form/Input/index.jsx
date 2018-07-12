import React, { Component } from "react";

import PropTypes from "prop-types";

export default class Input extends Component {
    render() {
        const {
            type, name, defaultValue, onChange, validation,
        } = this.props;

        return (
            <input
                className="form__input"
                type={type}
                name={name}
                defaultValue={defaultValue}
                onChange={onChange}
                required={validation && validation.required}
                pattern={validation && validation.pattern}
                title={validation && validation.title}
            />
        );
    }
}

Input.propTypes = {
    type: PropTypes.string,
    name: PropTypes.string,
    defaultValue: PropTypes.string,
    onChange: PropTypes.func,
    validation: PropTypes.shape({
        required: PropTypes.bool,
        pattern: PropTypes.string,
        title: PropTypes.string,
    }),
};

Input.defaultProps = {
    type: null,
    name: null,
    defaultValue: "",
    onChange: null,
    validation: null,
};
