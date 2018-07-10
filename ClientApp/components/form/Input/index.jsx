import React, { Component } from "react";

import PropTypes from "prop-types";

export default class Input extends Component {
    render() {
        const {
            type, name, defaultValue, onChange, className,
        } = this.props;

        return (
            <input
                className={className}
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
    className: PropTypes.string,
};

Input.defaultProps = {
    type: null,
    name: null,
    defaultValue: "",
    onChange: null,
    className: null,
};
