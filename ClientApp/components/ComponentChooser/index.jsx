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
        const { getComponents } = this.props;

        if (!getComponents) return;

        const { value } = e.target;

        if (value === "") {
            this.setState({ relatedComponents: [] });
        } else {
            const relatedComponents = getComponents(value);

            this.setState({ relatedComponents });
        }
    }

    render() {
        return (
            <div className="chooser">
                <input type="text" onChange={this.handleChange} />
                {this.state.relatedComponents}
            </div>
        );
    }
}

ComponentChooser.propTypes = {
    getComponents: PropTypes.func,
};

ComponentChooser.defaultProps = {
    getComponents: null,
};
