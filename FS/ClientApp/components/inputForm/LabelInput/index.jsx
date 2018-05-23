import React, { Component } from "react";
import PropTypes from "prop-types";

import "Css/form.css";

export default class LabelInput extends Component {
    constructor(props) {
        super(props);

        this.state = {};
    }

    componentWillMount() {
        if (this.isDatePicker()) {
            this.setState({
                value: this.props.inputProps.value,
            });
        }
    }

    isDatePicker = () => this.props.inputProps.type === "date";

    handleDateChange = (e) => {
        this.setState({
            value: e.target.value,
        });
        this.props.onChange(e);
    }

    render() {
        const inputProps = this.props.inputProps || {};

        return (
            <label className="form__label-input" htmlFor={inputProps.name}>
                {inputProps.label}:
                <input
                    className="form__input"
                    id={inputProps.name}
                    name={inputProps.name}
                    type={inputProps.type}
                    value={this.isDatePicker() ? this.state.value : inputProps.value}
                    onChange={this.isDatePicker() ? this.handleDateChange : this.props.onChange}
                />
            </label>
        );
    }
}

LabelInput.propTypes = {
    inputProps: PropTypes.shape({
        name: PropTypes.string,
        label: PropTypes.string,
        type: PropTypes.string,
        value: PropTypes.string,
    }),
    onChange: PropTypes.func,
};

LabelInput.defaultProps = {
    inputProps: null,
    onChange: null,
};
