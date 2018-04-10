import React, { Component } from "react";

import PropTypes from "prop-types";

import { formatDate } from "Utilities/castDate";

export default class FixtureItem extends Component {
    render() {
        return (
            <React.Fragment>
                <p>
                    {this.props.fixture.homeTeamName}
                    {" - "}
                    {this.props.fixture.awayTeamName}
                    {this.props.fixture.isFinished &&
                        (` ${this.props.fixture.result.goalsHomeTeam}` +
                        ` - ${this.props.fixture.result.goalsAwayTeam}`)
                    }
                </p>
                <p>Date: {formatDate(this.props.fixture.date)}</p>
            </React.Fragment>
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
};
