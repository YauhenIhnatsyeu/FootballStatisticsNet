import React, { Component } from "react";
import PropTypes from "prop-types";

import "Css/form.css";

export default class Select extends Component {
    render() {
        const { inputProps, handleChange } = this.props;

        return (
            <select name={inputProps.name} onChange={handleChange}>
                {inputProps.options && inputProps.options.map((option, index) => (
                    <option value={option.value} key={index}>
                        {option.title}
                    </option>
                ))}
            </select>
        );
    }
}

Select.propTypes = {
    inputProps: PropTypes.shape({
        name: PropTypes.string,
        value: PropTypes.string,
        options: PropTypes.arrayOf(PropTypes.shape({
            value: PropTypes.string,
            title: PropTypes.string,
        })),
    }),
    handleChange: PropTypes.func,
};

Select.defaultProps = {
    inputProps: null,
    handleChange: null,
};
