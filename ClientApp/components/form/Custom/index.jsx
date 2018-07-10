import React, { Component } from "react";

import PropTypes from "prop-types";

export default class Custom extends Component {
    itemHOC = (ItemComponent, extraProps) =>
        <ItemComponent.type {...ItemComponent.props} {...extraProps} />

    render() {
        const {
            component, onChange,
        } = this.props;

        return this.itemHOC(component, { onChange });
    }
}

Custom.propTypes = {
    component: PropTypes.node,
    onChange: PropTypes.func,
};

Custom.defaultProps = {
    component: null,
    onChange: null,
};
