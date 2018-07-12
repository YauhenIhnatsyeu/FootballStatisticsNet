import React, { Component } from "react";

import PropTypes from "prop-types";

import "./index.css";

export default class Select extends Component {
    renderOption = (option, key) => {
        const props = {
            className: "select__option",
            key,
        };

        return typeof option === "object"
            ? <option {...props} value={option && option.value}>{option && option.option}</option>
            : <option {...props}>{option}</option>;
    }

    renderOptions = options => Array.isArray(options) &&
        options.map((option, index) => this.renderOption(option, index))

    render() {
        return (
            <select
                className="select"
                defaultValue={this.props.defaultValue}
                onChange={this.props.onChange}
            >
                {this.renderOptions(this.props.options)}
            </select>
        );
    }
}

Select.propTypes = {
    options: PropTypes.arrayOf(PropTypes.oneOfType([
        PropTypes.string,
        PropTypes.number,
        PropTypes.shape({
            value: PropTypes.oneOfType([
                PropTypes.string,
                PropTypes.number,
            ]),
            option: PropTypes.oneOfType([
                PropTypes.string,
                PropTypes.number,
            ]),
        }),
    ])),
    defaultValue: PropTypes.oneOfType([
        PropTypes.string,
        PropTypes.number,
    ]),
    onChange: PropTypes.func,
};

Select.defaultProps = {
    options: null,
    defaultValue: null,
    onChange: null,
};
