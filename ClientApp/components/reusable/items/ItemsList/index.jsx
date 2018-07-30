import React, { Component } from "react";

import PropTypes from "prop-types";

import "./index.css";

export default class ItemsList extends Component {
    renderItem = (node, index) => (
        <div className="items-list__item-container" key={index}>
            {node}
        </div>
    )

    render() {
        return (
            <div className="items-list">
                {this.props.children && this.props.children.map((child, index) =>
                    this.renderItem(child, index))}
            </div>
        );
    }
}

ItemsList.propTypes = {
    children: PropTypes.arrayOf(PropTypes.node),
};

ItemsList.defaultProps = {
    children: null,
};
