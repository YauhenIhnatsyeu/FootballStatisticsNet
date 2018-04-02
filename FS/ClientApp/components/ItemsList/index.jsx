import React, { Component } from "react";

import PropTypes from "prop-types";

import "./index.css";

export default class ItemsList extends Component {
    render() {
        const extraProps = {};

        return (
            <div className="items-list">
                {this.props.items
                    .map((item, index) => {
                        extraProps.index = index;
                        extraProps[this.props.itemKey] = item;

                        const newItem = React.cloneElement(
                            this.props.itemComponent,
                            extraProps,
                        );

                        return (
                            <div className="items-list__item-container" key={index}>
                                {newItem}
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
