import React, { Component } from "react";

import PropTypes from "prop-types";

import "./index.css";

export default class Item extends Component {
    render() {
        return (
            <div
                className={
                    this.props.isCurrent
                        ? "item item_current"
                        : "item"
                }
            >
                {this.props.children}
            </div>
        );
    }
}

Item.propTypes = {
    isCurrent: PropTypes.bool,
    children: PropTypes.node,
};

Item.defaultProps = {
    isCurrent: false,
    children: null,
};
