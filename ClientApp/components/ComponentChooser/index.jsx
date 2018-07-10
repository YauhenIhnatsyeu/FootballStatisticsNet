import React, { Component } from "react";

import PropTypes from "prop-types";

export default class ComponentChooser extends Component {
    constructor(props) {
        super(props);

        this.state = {
            relatedComponents: [],
        };
    }

    handleChange = (e) => {
        const { components, valueRelatesToComponent } = this.props;
        const { value } = e.target;

        if (value === "") {
            this.setState({ relatedComponents: [] });
        } else {
            const relatedComponents = components.filter(component =>
                valueRelatesToComponent(value, component));

            this.setState({ relatedComponents });
        }
    }

    render() {
        console.log("rendered")
        return (
            <div className="chooser">
                <input type="text" onChange={this.handleChange} />
                {this.state.relatedComponents}
            </div>
        );
    }
}

ComponentChooser.propTypes = {
    components: PropTypes.arrayOf(PropTypes.node),
    valueRelatesToComponent: PropTypes.func,
};

ComponentChooser.defaultProps = {
    components: null,
    valueRelatesToComponent: null,
};
