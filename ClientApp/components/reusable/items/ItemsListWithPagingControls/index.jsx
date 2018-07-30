import React, { Component } from "react";

import PropTypes from "prop-types";

import ItemsList from "Reusable/items/ItemsList";
import PagingControls from "Reusable/PagingControls";

import itemsOnOnePageCount from "Constants/itemsOnOnePageCount";

import "./index.css";

export default class ItemsListWithPagingControls extends Component {
    getChildren = () => {
        const { children } = this.props;

        if (!Array.isArray(children)) {
            return null;
        }

        const startIndex = this.props.currentPageIndex * itemsOnOnePageCount;

        return children.slice(
            startIndex,
            startIndex + itemsOnOnePageCount,
        );
    }

    renderPagingControls = () => {
        const { children } = this.props;

        if (!Array.isArray(children)) {
            return null;
        }

        if (children.length <= itemsOnOnePageCount) {
            return null;
        }

        const pagingControlsPagesCount =
            Math.ceil(children.length / itemsOnOnePageCount);

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
            <div className="ilwpc">
                {this.renderPagingControls()}

                <div className="ilwpc__items-list-container">
                    <ItemsList>
                        {this.getChildren()}
                    </ItemsList>
                </div>

                {this.renderPagingControls()}
            </div>
        );
    }
}

ItemsListWithPagingControls.propTypes = {
    children: PropTypes.arrayOf(PropTypes.node),
    currentPageIndex: PropTypes.number,
    onPageChanged: PropTypes.func,
};

ItemsListWithPagingControls.defaultProps = {
    children: null,
    currentPageIndex: 0,
    onPageChanged: null,
};

