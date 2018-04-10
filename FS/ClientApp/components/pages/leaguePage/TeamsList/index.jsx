import React, { Component } from "react";

import PropTypes from "prop-types";

import TeamItem from "Pages/leaguePage/TeamItem";

import Loading from "Components/messages/Loading";
import Error from "Components/messages/Error";

import "./index.css";

export default class TeamsList extends Component {
    componentDidMount() {
        this.props.getTeamsFromFavorites();
    }

    render() {
        if (this.props.teamsFetchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.teams) {
            return <Loading />;
        }

        return (
            <div className="teams-list">
                {this.props.teams.map((team, index) =>
                    (
                        <div className="teams-list__team-item-container" key={index}>
                            <TeamItem
                                team={team}
                                favoriteTeams={this.props.favoriteTeams}
                                addTeamToFavorites={this.props.addTeamToFavorites}
                                removeTeamFromFavorites={this.props.removeTeamFromFavorites}
                            />
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
    favoriteTeams: PropTypes.arrayOf(PropTypes.number).isRequired,
    removeTeamFromFavorites: PropTypes.func.isRequired,
    addTeamToFavorites: PropTypes.func.isRequired,
};

TeamsList.defaultProps = {
    teams: null,
    teamsFetchingErrorOccured: false,
};
