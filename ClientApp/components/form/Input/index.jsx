import React, { Component } from "react";

import PropTypes from "prop-types";

export default class Input extends Component {
    render() {
        const {
            type, name, defaultValue, onChange,
        } = this.props;

        return (
            <input
                className="form__input"
                type={type}
                name={name}
                defaultValue={defaultValue}
                onChange={onChange}
            />
        );
    }
}

Input.propTypes = {
    type: PropTypes.string,
    name: PropTypes.string,
    defaultValue: PropTypes.string,
    onChange: PropTypes.func,
};

Input.defaultProps = {
    type: null,
    name: null,
    defaultValue: "",
    onChange: null,
};
