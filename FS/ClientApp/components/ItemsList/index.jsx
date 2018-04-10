import React, { Component } from "react";

import PropTypes from "prop-types";

import "./index.css";

export default class ItemsList extends Component {
    itemHOC = (props, extraProps) => ItemComponent =>
        <ItemComponent {...props} {...extraProps} />

    render() {
        const { itemComponent } = this.props;

        const extraProps = {};

        return (
            <div className="items-list">
                {this.props.items
                    .map((item, index) => {
                        extraProps[this.props.itemKey] = item;

                        return (
                            <div className="items-list__item-container" key={index}>
                                {this.itemHOC(itemComponent.props, extraProps)(itemComponent.type)}
                            </div>
                        );
                    })
                }
            </div>
        );
    }
}

ItemsList.propTypes = {
    items: PropTypes.arrayOf(PropTypes.object).isRequired,
    itemComponent: PropTypes.node.isRequired,
    itemKey: PropTypes.string.isRequired,
};
