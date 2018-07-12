import React, { Component } from "react";

import PropTypes from "prop-types";

import { Link } from "react-router-dom";

import Table from "Components/Table";

import Loading from "Components/messages/Loading";
import Error from "Components/messages/Error";

import leaguesData from "Constants/leaguesData";
import teamProperties from "Constants/teamProperties";

import createTeamUrl from "Utilities/urlsCreators";

import "./index.css";

export default class LeagueTable extends Component {
    componentDidMount() {
        this.props.fetchLeague(leaguesData[this.props.leagueIndex].id);
    }

    componentWillReceiveProps(nextProps) {
        if (this.props.leagueIndex !== nextProps.leagueIndex) {
            this.props.fetchLeague(leaguesData[nextProps.leagueIndex].id);
        }
    }

    getHeader = () => teamProperties.map(({ caption }) => caption);

    getRows = () => this.props.league.map(team =>
        teamProperties.map(({ key }) => (key === "teamName"
            ? <Link to={createTeamUrl(team.id)}>{team[key]}</Link>
            : team[key])))

    render() {
        if (this.props.leagueFetchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.league) {
            return <Loading />;
        }

        return (
            <Table
                header={this.getHeader()}
                rows={this.getRows()}
            />
        );
    }
}

LeagueTable.propTypes = {
    league: PropTypes.arrayOf(PropTypes.object),
    leagueIndex: PropTypes.number.isRequired,
    leagueFetchingErrorOccured: PropTypes.bool,
    fetchLeague: PropTypes.func.isRequired,
};

LeagueTable.defaultProps = {
    league: PropTypes.shape({}),
    leagueFetchingErrorOccured: false,
};
