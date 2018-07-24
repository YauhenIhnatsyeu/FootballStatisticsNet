import React, { Component } from "react";

import PropTypes from "prop-types";

import TeamItem from "Reusable/TeamItem";

import Spinner from "Reusable/spinners/Spinner";
import Error from "Reusable/messages/Error";

import createTeamUrl from "Utilities/urlsCreators";

import "./index.css";

export default class TeamsList extends Component {
    componentDidMount() {
        if (this.props.loggedIn) {
            this.props.getTeamsFromFavorites();
        }
    }

    handleButtonClick = (team, state) => {
        if (state) {
            this.props.removeTeamFromFavorites(team);
        } else {
            this.props.addTeamToFavorites(team);
        }
    }

    isTeamInFavorites = teamId => this.props.favoriteTeams.includes(teamId);

    renderTeamItemWithButton = team => (
        <TeamItem
            team={team}
            teamUrl={createTeamUrl(team.id)}
            buttonRequired
            onButtonClick={this.handleButtonClick}
            falseStateCaption="Add to favorites"
            trueStateCaption="Remove from favorites"
            defaultState={this.isTeamInFavorites(team.id)}
        />
    )

    renderTeamItemWithoutButton = team => (
        <TeamItem
            team={team}
            teamUrl={createTeamUrl(team.id)}
        />
    )

    render() {
        const {
            teamsFetchingErrorOccured, teams, loggedIn, favoriteTeams,
        } = this.props;

        if (teamsFetchingErrorOccured) {
            return <Error />;
        }

        if (!teams || (loggedIn && !favoriteTeams)) {
            return <Spinner />;
        }

        return (
            <div className="teams-list">
                {this.props.teams.map((team, index) =>
                    (
                        <div className="teams-list__team-item-container" key={index}>
                            {this.props.loggedIn
                                ? this.renderTeamItemWithButton(team)
                                : this.renderTeamItemWithoutButton(team)}
                        </div>
                    ))
                }
            </div>
        );
    }
}

TeamsList.propTypes = {
    teams: PropTypes.arrayOf(PropTypes.object),
    teamsFetchingErrorOccured: PropTypes.bool,
    getTeamsFromFavorites: PropTypes.func.isRequired,
    favoriteTeams: PropTypes.arrayOf(PropTypes.number),
    removeTeamFromFavorites: PropTypes.func.isRequired,
    addTeamToFavorites: PropTypes.func.isRequired,
    loggedIn: PropTypes.bool.isRequired,
};

TeamsList.defaultProps = {
    teams: null,
    teamsFetchingErrorOccured: false,
    favoriteTeams: null,
};
