import React, { Component } from "react";

import PropTypes from "prop-types";

import { injectPropsIntoComponent } from "Helpers/propsHelper";

import { getChangedValueFromEvent } from "Helpers/getChangedValueHelper";

import "./index.css";

export default class Form extends Component {
    constructor(props) {
        super(props);

        this.model = {};
    }

    componentDidMount() {
        this.props.children.forEach((child) => {
            const { props: childProps } = child;
            this.changeModel(
                childProps.name,
                childProps.defaultValue || null,
            );
        });
    }

    changeModel = (name, value) => {
        this.model[name] = value;

        console.log(this.model)
    }

    handleChange = (name, getChangedValueFunc, ...params) => {
        const value = getChangedValueFunc
            ? getChangedValueFunc(...params)
            : "";

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
                                child.props.name,
                                child.props.getChangedValueFunc || getChangedValueFromEvent,
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
