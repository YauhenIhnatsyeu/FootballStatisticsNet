import React, { Component } from "react";

import PropTypes from "prop-types";

import Tab from "../Tab";

import "./index.css";

export default class Tabs extends Component {
    constructor(props) {
        super(props);

        this.state = {
            currentIndex: this.props.defaultIndex,
        };
    }

    handleClick = (e, newIndex) => {
        e.preventDefault();

        if (this.props.onTabClick) {
            this.props.onTabClick(newIndex);
        }

        this.setState({
            currentIndex: newIndex,
        });
    }

    render() {
        return (
            <div className="tabs">
                {this.props.children && this.props.children.map((tab, newIndex) => {
                    if (tab.type !== Tab) {
                        return null;
                    }

                    const isTabCurrent = newIndex === this.state.currentIndex;

                    const tabStyle = isTabCurrent ?
                        "tabs__tab tabs__tab_current" : "tabs__tab";

                    return (
                        <a
                            className={tabStyle}
                            key={newIndex}
                            href="#"
                            onClick={e => this.handleClick(e, newIndex)}
                        >
                            {tab.props.title}
                        </a>
                    );
                })}
            </div>
        );
    }
}

Tabs.propTypes = {
    children: PropTypes.node,
    defaultIndex: PropTypes.number,
    onTabClick: PropTypes.func,
};

Tabs.defaultProps = {
    children: null,
    defaultIndex: 0,
    onTabClick: null,
};
