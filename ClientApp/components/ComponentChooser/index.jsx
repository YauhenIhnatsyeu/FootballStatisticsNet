import React, { Component } from "react";

import PropTypes from "prop-types";

import { injectPropsIntoComponent } from "Helpers/propsHelper";

import "./index.css";

export default class ComponentChooser extends Component {
    constructor(props) {
        super(props);

        this.state = {
            inputValue: "",
            relatedComponents: [],
        };
    }

    handleInputChange = (e) => {
        const { getComponents } = this.props;

        if (!getComponents) return;

        const { value } = e.target;
        let relatedComponents = [];

        if (value !== "") {
            relatedComponents = getComponents(value);
        }

        this.setState({
            inputValue: value,
            relatedComponents,
        });
    }

    handleComponentClick = (component) => {
        const { onChange, getSelectedComponentValue } = this.props;

        if (onChange) {
            onChange(component);
        }

        const inputValue = getSelectedComponentValue
            ? getSelectedComponentValue(component)
            : "";

        this.setState({
            inputValue,
            relatedComponents: [],
        });
    }

    renderComponents = () => this.state.relatedComponents.map((component, index) => (
        <div className="chooser__component-container" key={index}>
            {injectPropsIntoComponent(
                component,
                { onClick: this.handleComponentClick },
            )}
        </div>
    ))

    render() {
        return (
            <div className="chooser">
                <div className="chooser__input-container">
                    <input
                        className="chooser__input"
                        type="text"
                        value={this.state.inputValue}
                        onChange={this.handleInputChange}
                    />
                </div>
                <div className="chooser__components-container">
                    {this.renderComponents()}
                </div>
            </div>
        );
    }
}

ComponentChooser.propTypes = {
    getComponents: PropTypes.func,
    getSelectedComponentValue: PropTypes.func,
    onChange: PropTypes.func,
};

ComponentChooser.defaultProps = {
    getComponents: null,
    getSelectedComponentValue: null,
    onChange: null,
};
