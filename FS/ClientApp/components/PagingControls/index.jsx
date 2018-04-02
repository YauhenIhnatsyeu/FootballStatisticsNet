import React, { Component } from "react";

import PropTypes from "prop-types";

import "./index.css";

export default class PagingControls extends Component {
    getOptions = () => {
        const pages = [];
        for (let i = 1; i <= this.props.pagesCount; i += 1) {
            pages.push(i);
        }

        return (
            pages.map((page, index) =>
                (
                    <option key={index}>
                        {page}
                    </option>
                ))
        );
    }

    newIndexIsValid = newIndex => (
        newIndex >= 0
        && newIndex < this.props.pagesCount
        && newIndex !== this.props.currentPageIndex
    )

    handleClickBase = (newIndex) => {
        if (!this.newIndexIsValid(newIndex)) {
            return;
        }

        if (this.props.onPageChanged) {
            this.props.onPageChanged(newIndex);
        }
    }

    handleClick = (e, newIndex) => {
        e.preventDefault();
        this.handleClickBase(newIndex);
    }

    handleChange = (newIndex) => {
        this.handleClickBase(newIndex);
    }

    render() {
        return (
            <div className="paging-controls">
                <select
                    className="paging-controls__item paging-controls__select"
                    onChange={e => this.handleChange(e.target.value - 1)}
                    value={this.props.currentPageIndex + 1}
                >
                    {this.getOptions()}
                </select>
                <a
                    className="paging-controls__item paging-controls__link"
                    href="#"
                    onClick={e => this.handleClick(e, 0)}
                >
                    first
                </a>
                <a
                    className="paging-controls__item paging-controls__link"
                    href="#"
                    onClick={e => this.handleClick(e, this.props.currentPageIndex - 1)}
                >
                    prev
                </a>
                <span className="paging-controls__item paging-controls__indicator">
                    {`${this.props.currentPageIndex + 1}/${this.props.pagesCount}`}
                </span>
                <a
                    className="paging-controls__item paging-controls__link"
                    href="#"
                    onClick={e => this.handleClick(e, this.props.currentPageIndex + 1)}
                >
                    next
                </a>
                <a
                    className="paging-controls__item paging-controls__link"
                    href="#"
                    onClick={e => this.handleClick(e, this.props.pagesCount - 1)}
                >
                    last
                </a>
            </div>
        );
    }
}

PagingControls.propTypes = {
    pagesCount: PropTypes.number.isRequired,
    currentPageIndex: PropTypes.number.isRequired,
    onPageChanged: PropTypes.func,
};

PagingControls.defaultProps = {
    onPageChanged: null,
};
