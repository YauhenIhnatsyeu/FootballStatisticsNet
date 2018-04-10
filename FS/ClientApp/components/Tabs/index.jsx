import React, { Component } from "react";

import PropTypes from "prop-types";

import { Link } from "react-router-dom";

import classNames from "classnames";

import "./index.css";

export default class Tabs extends Component {
    constructor(props) {
        super(props);

        this.state = {
            currentIndex: this.props.defaultIndex,
        };
    }

    handleClick = (newIndex) => {
        this.setState({
            currentIndex: newIndex,
        });

        if (this.props.onTabClick) {
            this.props.onTabClick(newIndex);
        }
    }

    renderTab = (style, index, title) => {
        if (this.props.hrefs) {
            return (
                <Link
                    to={this.props.hrefs[index]}
                    className={style}
                    key={index}
                    onClick={() => this.handleClick(index)}
                >
                    {title}
                </Link>
            );
        }
        return (
            <button
                className={style}
                key={index}
                onClick={() => this.handleClick(index)}
            >
                {title}
            </button>
        );
    }

    render() {
        return (
            <div className="tabs">
                {this.props.titles && this.props.titles.map((title, index) => {
                    const isTabCurrent = index === this.state.currentIndex;

                    const style = classNames({
                        tabs__tab: true,
                        tabs__tab_current: isTabCurrent,
                    });

                    return this.renderTab(style, index, title);
                })}
            </div>
        );
    }
}

Tabs.propTypes = {
    titles: PropTypes.arrayOf(PropTypes.string),
    defaultIndex: PropTypes.number,
    hrefs: PropTypes.arrayOf(PropTypes.string),
    onTabClick: PropTypes.func,
};

Tabs.defaultProps = {
    titles: null,
    defaultIndex: 0,
    hrefs: null,
    onTabClick: null,
};
