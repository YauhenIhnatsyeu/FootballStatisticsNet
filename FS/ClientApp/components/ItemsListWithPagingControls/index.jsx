import React, { Component } from "react";

import PropTypes from "prop-types";

import ItemsList from "Components/ItemsList";
import PagingControls from "Components/PagingControls";

import itemsOnOnePageCount from "Constants/itemsOnOnePageCount";

import "./index.css";

export default class ItemsListWithPagingControls extends Component {
    render() {
        const pagingControlsPagesCount =
            Math.ceil(this.props.items.length / itemsOnOnePageCount);

        const pagingControls = this.props.items.length > itemsOnOnePageCount ?
            (
                <PagingControls
                    pagesCount={pagingControlsPagesCount}
                    onPageChanged={this.props.onPageChanged}
                    currentPageIndex={this.props.currentPageIndex}
                />
            )
            :
            null;

        const startIndex = this.props.currentPageIndex * itemsOnOnePageCount;

        return (
            <React.Fragment>
                {pagingControls}

                <div className="items-list-with-paging-controls__items-list-container">
                    <ItemsList
                        items={
                            this.props.items.slice(
                                startIndex,
                                startIndex + itemsOnOnePageCount,
                            )
                        }
                        itemComponent={this.props.itemComponent}
                        itemKey={this.props.itemKey}
                    />
                </div>

                {pagingControls}
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
