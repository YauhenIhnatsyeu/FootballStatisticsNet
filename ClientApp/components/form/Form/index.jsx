import React, { Component } from "react";

import PropTypes from "prop-types";

import { injectPropsIntoComponent } from "Helpers/propsHelper";

import { retrieveNameAndValueFromEvent } from "Utilities/retrieveNameAndValueFunctions";

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

    handleChange = (retrieveNameAndValueFunc, ...params) => {
        const { name, value } = retrieveNameAndValueFunc
            ? retrieveNameAndValueFunc(...params)
            : { name: "", value: "" };

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
        const { submitValue } = this.props;
        const children = Array.isArray(this.props.children)
            ? this.props.children
            : [this.props.children];

        return (
            <div className="form-container">
                <form className="form">
                    {children.map((child, index) => {
                        const extraProps = {
                            onChange: (...args) => this.handleChange(
                                child.props.retrieveNameAndValueFunc || retrieveNameAndValueFromEvent,
                                ...args,
                            ),
                        };

                        const wrappedChild = injectPropsIntoComponent(child, extraProps);

                        return (
                            <label key={index} className="form__label" htmlFor={wrappedChild.props.name}>
                                {wrappedChild.props.label && `${wrappedChild.props.label}:`}
                                {wrappedChild}
                            </label>
                        );
                    })}

                    <div className="form__submit-container">
                        <input
                            className="form__input form__submit"
                            type="submit"
                            value={submitValue || "Submit"}
                        />
                    </div>
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
