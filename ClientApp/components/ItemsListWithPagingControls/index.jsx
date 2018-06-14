import React, { Component } from "react";

import PropTypes from "prop-types";

import ItemsList from "Components/ItemsList";
import PagingControls from "Components/PagingControls";

import itemsOnOnePageCount from "Constants/itemsOnOnePageCount";

import "./index.css";

export default class ItemsListWithPagingControls extends Component {
    getItems = () => {
        const startIndex = this.props.currentPageIndex * itemsOnOnePageCount;

        return this.props.items.slice(
            startIndex,
            startIndex + itemsOnOnePageCount,
        );
    }

    renderPagingControls = () => {
        const pagingControlsPagesCount =
            Math.ceil(this.props.items.length / itemsOnOnePageCount);

        return (
            <PagingControls
                pagesCount={pagingControlsPagesCount}
                onPageChanged={this.props.onPageChanged}
                currentPageIndex={this.props.currentPageIndex}
            />
        );
    }

    render() {
        return (
            <React.Fragment>
                {this.props.items.length > itemsOnOnePageCount
                    ? this.renderPagingControls()
                    : null
                }

                <div className="items-list-with-paging-controls__items-list-container">
                    <ItemsList
                        items={this.getItems()}
                        itemComponent={this.props.itemComponent}
                        itemKey={this.props.itemKey}
                    />
                </div>

                {this.props.items.length > itemsOnOnePageCount
                    ? this.renderPagingControls()
                    : null
                }
            </React.Fragment>
        );
    }
}

ItemsListWithPagingControls.propTypes = {
    currentPageIndex: PropTypes.number.isRequired,
    items: PropTypes.arrayOf(PropTypes.object).isRequired,
    itemComponent: PropTypes.node.isRequired,
    itemKey: PropTypes.string.isRequired,
    onPageChanged: PropTypes.func.isRequired,
};
