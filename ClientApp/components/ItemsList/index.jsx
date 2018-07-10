import React, { Component } from "react";

import PropTypes from "prop-types";

import { injectPropsIntoComponent } from "Helpers/propsHelper";

import "./index.css";

export default class ItemsList extends Component {
    render() {
        const { itemComponent } = this.props;

        const extraProps = {};

        return (
            <div className="items-list">
                {this.props.items && this.props.items
                    .map((item, index) => {
                        extraProps[this.props.itemKey] = item;

                        return (
                            <div className="items-list__item-container" key={index}>
                                {injectPropsIntoComponent(itemComponent, extraProps)}
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
