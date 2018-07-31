import React, { Component } from "react";

import PropTypes from "prop-types";

import "./index.css";

export default class ItemsListInColumns extends Component {
    renderItem = (node, index) => (
        <div className="items-list-in-columns__item-container" key={index}>
            {node}
        </div>
    )

    render() {
        return (
            <div className="items-list-in-columns">
                {this.props.children && this.props.children.map((child, index) =>
                    this.renderItem(child, index))}
            </div>
        );
    }
}

ItemsListInColumns.propTypes = {
    children: PropTypes.arrayOf(PropTypes.node),
};

ItemsListInColumns.defaultProps = {
    children: null,
};
