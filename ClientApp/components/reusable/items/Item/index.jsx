import React, { Component } from "react";

import PropTypes from "prop-types";

import classNames from "classnames";

import "./index.css";

export default class Item extends Component {
    render() {
        const itemStyle = classNames(
            "item",
            {
                item_current: this.props.isCurrent,
                item_clickable: this.props.onClick,
            },
        );

        const props = this.props.onClick && {
            onClick: this.props.onClick,
            onKeyDown: this.props.onClick,
            role: "link",
            tabIndex: "0",
        };

        return (
            <div className={itemStyle} {...props} >
                {this.props.children}
            </div>
        );
    }
}

Item.propTypes = {
    onClick: PropTypes.func,
    isCurrent: PropTypes.bool,
    children: PropTypes.node,
};

Item.defaultProps = {
    onClick: null,
    isCurrent: false,
    children: null,
};
