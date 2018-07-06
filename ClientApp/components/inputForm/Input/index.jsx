import React, { Component } from "react";
import PropTypes from "prop-types";

import "Css/form.css";

export default class LabelInput extends Component {
    render() {
        const {
            inputProps,
            value,
            onChange,
            onBlur,
        } = this.props;

        return (
            <input
                className="form__input"
                id={inputProps.name}
                name={inputProps.name}
                type={inputProps.type}
                defaultValue={value || ""}
                onChange={onChange}
                onBlur={onBlur}
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
    onChange: PropTypes.func,
    onBlur: PropTypes.func,
};

LabelInput.defaultProps = {
    inputProps: null,
    value: null,
    onChange: null,
    onBlur: null,
};
