import React, { Component } from "react";

import PropTypes from "prop-types";

import Tabs from "Components/Tabs";

import LeagueTable from "Pages/tablePage/LeagueTable";

import leaguesData from "Constants/leaguesData";

export default class TablePage extends Component {
    handleTabClick = (newIndex) => {
        this.props.updateLeagueIndex(newIndex);
    }

    render() {
        return (
            <React.Fragment>
                <Tabs
                    titles={leaguesData.map(leagueData => leagueData.title)}
                    onTabClick={this.handleTabClick}
                />

                <LeagueTable
                    league={this.props.league}
                    leagueIndex={this.props.leagueIndex}
                    fetchLeague={this.props.fetchLeague}
                    leagueFetchingErrorOccured={this.props.leagueFetchingErrorOccured}
                />
            </React.Fragment>
        );
    }
}

TablePage.propTypes = {
    league: PropTypes.arrayOf(PropTypes.object),
    leagueIndex: PropTypes.number.isRequired,
    leagueFetchingErrorOccured: PropTypes.bool,
    updateLeagueIndex: PropTypes.func.isRequired,
    fetchLeague: PropTypes.func.isRequired,
};

TablePage.defaultProps = {
    league: PropTypes.shape({}),
    leagueFetchingErrorOccured: false,
};
