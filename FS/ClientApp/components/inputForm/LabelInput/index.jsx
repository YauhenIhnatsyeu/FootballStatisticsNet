import React, { Component } from "react";
import PropTypes from "prop-types";

import classNames from "classnames";

import validate from "Helpers/validationHelper";

import "Css/form.css";

export default class LabelInput extends Component {
    constructor(props) {
        super(props);

        this.state = {
            errorMessage: null,
        };
    }

    componentWillMount() {
        if (this.isDatePicker()) {
            this.setState({
                value: this.props.inputProps.value || "",
            });
        }
    }

    componentWillReceiveProps(nextProps) {
        if (nextProps.errorMessage !== this.state.errorMessage) {
            this.setState({
                errorMessage: nextProps.errorMessage,
            });
        }
    }

    isDatePicker = () => this.props.inputProps.type === "date";

    validate = (str) => {
        const errorMessage = validate(str, this.props.inputProps.validationOptions);
        if (errorMessage) {
            this.setState({
                errorMessage,
            });
        } else if (this.state.errorMessage) {
            this.setState({
                errorMessage: null,
            });
        }
    }

    handleDateChange = (e) => {
        this.setState({
            value: e.target.value,
        });
        this.props.onChange(e);
    }

    handleBlur = (e) => {
        if (this.props.inputProps.validationOptions) {
            this.validate(e.target.value);
        }
    }

    render() {
        const inputProps = this.props.inputProps || {};
        const errorMessageStyle = classNames({
            "form__error-message_hidden": !this.state.errorMessage,
            "form__error-message_visible": this.state.errorMessage,
        });

        return (
            <div className="form__label-input-container">
                <label className="form__label-input" htmlFor={inputProps.name}>
                    {inputProps.label}:
                    <input
                        className="form__input"
                        id={inputProps.name}
                        name={inputProps.name}
                        type={inputProps.type}
                        value={this.isDatePicker() ? this.state.value : inputProps.value}
                        onChange={this.isDatePicker() ? this.handleDateChange : this.props.onChange}
                        onBlur={this.handleBlur}
                    />
                </label>

                <span className={errorMessageStyle}>{this.state.errorMessage}</span>
            </div>
        );
    }
}

LabelInput.propTypes = {
    inputProps: PropTypes.shape({
        name: PropTypes.string,
        label: PropTypes.string,
        type: PropTypes.string,
        value: PropTypes.string,
        validationOptions: PropTypes.shape({}),
    }),
    onChange: PropTypes.func,
    errorMessage: PropTypes.string,
};

LabelInput.defaultProps = {
    inputProps: null,
    onChange: null,
    errorMessage: null,
};
