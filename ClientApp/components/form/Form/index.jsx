import React, { Component } from "react";

import PropTypes from "prop-types";

import { retrieveNameAndValueFromEvent } from "Utilities/retrieveNameAndValueFunctions";

import formItemHOC from "../formItemHOC";

import "./index.css";

export default class Form extends Component {
    constructor(props) {
        super(props);

        this.model = {};
    }

    componentDidMount() {
        for (let i = 0; i < this.props.children.length; i += 1) {
            const { props: childProps } = this.props.children[i];
            this.changeModel(
                childProps.name,
                childProps.value || childProps.defaultValue,
            );
        }
    }

    changeModel = (name, value) => {
        this.model[name] = value;

        console.log(this.model)
    }

    handleChange = (name, value) => {
        this.changeModel(name, value);
    }

    handleSubmit = (e) => {
        e.preventDefault();

        const { onSubmit } = this.props;

        if (onSubmit) {
            onSubmit(this.model);
        }
    }

    render() {
        const { children, submitValue } = this.props;

        return (
            <div className="form-container">
                <form className="form" onSubmit={this.handleSubmit}>
                    {children.map((child, index) => {
                        const wrappedChild = formItemHOC(
                            child,
                            this.handleChange,
                            child.props.retrieveNameAndValueFunc || retrieveNameAndValueFromEvent,
                        );

                        return (
                            <label key={index} className="form__label-input" htmlFor={wrappedChild.props.name}>
                                {wrappedChild.props.label && `${wrappedChild.props.label}:`}
                                {wrappedChild}
                            </label>
                        );
                    })}

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

Form.propTypes = {
    children: PropTypes.oneOfType([
        PropTypes.shape({}),
        PropTypes.arrayOf(PropTypes.shape({})),
    ]),
    submitValue: PropTypes.string,
    onSubmit: PropTypes.func,
};

Form.defaultProps = {
    children: null,
    submitValue: null,
    onSubmit: null,
};
