import React, { Component } from "react";

import PropTypes from "prop-types";

import classNames from "classnames";

import "./index.css";

export default class ItemsList extends Component {
    getListStyle = () => classNames({
        "items-list": true,
        "items-list_in-columns": this.props.inColumns,
    })

    getItemStyle = () => classNames({
        "items-list__item-container": true,
        "items-list__item-container_in-columns": this.props.inColumns,
    })

    renderItem = (node, index) => (
        <div className={this.getItemStyle()} key={index}>
            {node}
        </div>
    )

    render() {
        return (
            <div className={this.getListStyle()}>
                {this.props.children && this.props.children.map((child, index) =>
                    this.renderItem(child, index))}
            </div>
        );
    }
}

ItemsList.propTypes = {
    children: PropTypes.arrayOf(PropTypes.node),
    inColumns: PropTypes.bool,
};

ItemsList.defaultProps = {
    children: null,
    inColumns: false,
};
