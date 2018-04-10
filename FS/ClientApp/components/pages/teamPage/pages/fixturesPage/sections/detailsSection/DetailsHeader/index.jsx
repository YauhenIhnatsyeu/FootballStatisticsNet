import React from "react";

import PropTypes from "prop-types";

import Item from "Components/Item";
import FixtureInfo from "Pages/teamPage/pages/fixturesPage/FixtureInfo";

import "./index.css";

export default class DetailsHeader extends React.Component {
    render() {
        const { info, fixture } = this.props.head2Head;

        return (
            <Item>
                <div className="details-header">
                    <div className="details-header__header">
                        <FixtureInfo
                            fixture={fixture}
                        />
                    </div>
                    <div className="details-header__statistics">
                        <span className="details-header__statistics-title">
                            Statistics:
                        </span>
                        <p>
                            {fixture.homeTeamName}
                            {" wins: "}
                            {info.homeTeamWins}
                        </p>
                        <p>
                            {fixture.awayTeamName}
                            {" wins: "}
                            {info.awayTeamWins}
                        </p>
                        <p>
                            {"Draws: "}
                            {info.draws}
                        </p>
                    </div>
                </div>
            </Item>
        );
    }
}

DetailsHeader.propTypes = {
    head2Head: PropTypes.shape({
        fixture: PropTypes.shape({
            homeTeamName: PropTypes.string.isRequired,
            awayTeamName: PropTypes.string.isRequired,
            status: PropTypes.string.isRequired,
            result: PropTypes.shape({
                goalsHomeTeam: PropTypes.number,
                goalsAwayTeam: PropTypes.number,
            }).isRequired,
            date: PropTypes.string.isRequired,
            isFinished: PropTypes.bool,
        }).isRequired,
        info: PropTypes.shape({}).isRequired,
    }),
};

DetailsHeader.defaultProps = {
    head2Head: PropTypes.shape({
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
    }),
};
