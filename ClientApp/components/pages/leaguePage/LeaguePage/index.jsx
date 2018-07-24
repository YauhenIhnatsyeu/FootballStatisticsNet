import React, { Component } from "react";

import PropTypes from "prop-types";

import SectionHeader from "Reusable/SectionHeader";
import TeamList from "Pages/leaguePage/TeamsList";
import leaguesData from "Constants/leaguesData";

import LeagueSelector from "../LeagueSelector";

import "./index.css";

export default class LeaguePage extends Component {
    componentDidMount() {
        const leagueId = leaguesData[this.props.leagueIndex].id;

        this.props.fetchTeams([leagueId]);
    }

    getTitle = () => leaguesData[this.props.leagueIndex].title

    handleSelectorChaged = (leagueIndex) => {
        this.props.updateLeagueIndex(leagueIndex);

        this.props.fetchTeams([leaguesData[leagueIndex].id]);
    }

    render() {
        return (
            <React.Fragment>
                <SectionHeader title={this.getTitle()} />

                <div className="league-panel__legue-selector-container">
                    <LeagueSelector
                        leagueIndex={this.props.leagueIndex}
                        onChange={this.handleSelectorChaged}
                    />
                </div>

                <div className="league-panel__teams-list-container">
                    <TeamList
                        teams={this.props.teams}
                        teamsFetchingErrorOccured={this.props.teamsFetchingErrorOccured}
                        getTeamsFromFavorites={this.props.getTeamsFromFavorites}
                        favoriteTeams={this.props.favoriteTeams}
                        addTeamToFavorites={this.props.addTeamToFavorites}
                        removeTeamFromFavorites={this.props.removeTeamFromFavorites}
                        loggedIn={this.props.loggedIn}
                    />
                </div>
            </React.Fragment>
        );
    }
}

LeaguePage.propTypes = {
    leagueIndex: PropTypes.number.isRequired,
    updateLeagueIndex: PropTypes.func.isRequired,
    teams: PropTypes.arrayOf(PropTypes.object),
    teamsFetchingErrorOccured: PropTypes.bool,
    getTeamsFromFavorites: PropTypes.func.isRequired,
    fetchTeams: PropTypes.func.isRequired,
    favoriteTeams: PropTypes.arrayOf(PropTypes.number).isRequired,
    removeTeamFromFavorites: PropTypes.func.isRequired,
    addTeamToFavorites: PropTypes.func.isRequired,
    loggedIn: PropTypes.bool.isRequired,
};

LeaguePage.defaultProps = {
    teams: null,
    teamsFetchingErrorOccured: false,
};
