import React, { Component } from "react";
import PropTypes from "prop-types";

import "Css/form.css";

export default class LabelInput extends Component {
    render() {
        const {
            inputProps,
            value,
            handleChange,
            handleBlur,
        } = this.props;

        return (
            <input
                className="form__input"
                id={inputProps.name}
                name={inputProps.name}
                type={inputProps.type}
                value={value || ""}
                onChange={handleChange}
                onBlur={handleBlur}
            />
        );
    }
}

LabelInput.propTypes = {
    inputProps: PropTypes.shape({
        name: PropTypes.string,
        type: PropTypes.string,
        value: PropTypes.string,
    }),
    value: PropTypes.string,
    handleChange: PropTypes.func,
    handleBlur: PropTypes.func,
};

LabelInput.defaultProps = {
    inputProps: null,
    value: null,
    handleChange: null,
    handleBlur: null,
};
