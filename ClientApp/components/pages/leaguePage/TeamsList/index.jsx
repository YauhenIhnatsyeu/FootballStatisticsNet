import React, { Component } from "react";

import PropTypes from "prop-types";

import ItemsListInColumns from "Reusable/items/ItemsListInColumns";

import TeamItem from "Reusable/TeamItem";

import Spinner from "Reusable/spinners/Spinner";
import Error from "Reusable/messages/Error";

import MountAnimation from "Components/animations/MountAnimation";

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

    renderTeamItemWithButton = (team, index) => (
        <TeamItem
            team={team}
            linkRequired
            buttonRequired
            onButtonClick={this.handleButtonClick}
            falseStateCaption="Add to favorites"
            trueStateCaption="Remove from favorites"
            defaultState={this.isTeamInFavorites(team.id)}
            key={index}
        />
    )

    renderTeamItemWithoutButton = (team, index) => (
        <TeamItem
            team={team}
            linkRequired
            key={index}
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
            <MountAnimation>
                <ItemsListInColumns>
                    {this.props.teams.map((team, index) => (this.props.loggedIn
                        ? this.renderTeamItemWithButton(team, index)
                        : this.renderTeamItemWithoutButton(team, index)))}
                </ItemsListInColumns>
            </MountAnimation>
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
