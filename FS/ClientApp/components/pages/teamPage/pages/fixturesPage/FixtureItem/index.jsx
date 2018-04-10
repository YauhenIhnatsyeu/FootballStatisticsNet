import React, { Component } from "react";

import PropTypes from "prop-types";

import classNames from "classnames";

import Item from "Components/Item";
import FixtureInfo from "../FixtureInfo";

import "./index.css";

export default class FixtureItem extends Component {
    handleClick = () => {
        if (this.props.onClick) {
            this.props.onClick(this.props.fixture.id);
        }
    }

    render() {
        const style = classNames({
            "fixture-item": true,
            "fixture-item_clickable": this.props.onClick,
        });

        return (
            <Item isCurrent={this.props.currentFixtureId === this.props.fixture.id}>
                <div
                    className={style}
                    onClick={this.handleClick}
                    onKeyDown={this.handleClick}
                    role="link"
                    tabIndex="0"
                >
                    <FixtureInfo fixture={this.props.fixture} />
                </div>
            </Item>
        );
    }
}

FixtureItem.propTypes = {
    fixture: PropTypes.shape({
        id: PropTypes.number,
        homeTeamName: PropTypes.string,
        awayTeamName: PropTypes.string,
        result: PropTypes.shape({
            goalsHomeTeam: PropTypes.number,
            goalsAwayTeam: PropTypes.number,
        }),
        status: PropTypes.string,
        date: PropTypes.string,
        isFinished: PropTypes.bool,
    }),
    currentFixtureId: PropTypes.number.isRequired,
    onClick: PropTypes.func,
};

FixtureItem.defaultProps = {
    fixture: {
        id: null,
        homeTeamName: null,
        awayTeamName: null,
        result: {
            goalsHomeTeam: null,
            goalsAwayTeam: null,
        },
        status: null,
        date: null,
        isFinished: false,
    },
    onClick: null,
};
