import React, { Component } from "react";

import PropTypes from "prop-types";

import "./index.css";

export default class OverlaySpinner extends Component {
    render() {
        return this.props.isLoading
            ? <div className="overlay-spinner" />
            : null;
    }
}

OverlaySpinner.propTypes = {
    isLoading: PropTypes.bool,
};

OverlaySpinner.defaultProps = {
    isLoading: false,
};
