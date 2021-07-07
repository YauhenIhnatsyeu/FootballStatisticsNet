import React, { Component } from "react";

import PropTypes from "prop-types";

import { Link } from "react-router-dom";

import Table from "Reusable/Table";

import Spinner from "Reusable/spinners/Spinner";
import Error from "Reusable/messages/Error";

import leaguesData from "Constants/leaguesData";
import teamProperties from "Constants/teamProperties";

import createTeamUrl from "Utilities/urlsCreators";

import classNames from "classnames";

import MountAnimation from "Components/animations/MountAnimation";

export default class LeagueTable extends Component {
    constructor(props) {
        super(props);

        this.state = ({ visible: true });
    }

    componentDidMount() {
        this.props.fetchLeague(leaguesData[this.props.leagueIndex].id);
    }

    componentWillReceiveProps(nextProps) {
        if (this.props.leagueIndex !== nextProps.leagueIndex) {
            this.props.fetchLeague(leaguesData[nextProps.leagueIndex].id);
        }
    }

    getClassName = () => classNames({
        "table-container": true,
        "table-container_visible": this.state.visible,
    })

    getHeader = () => teamProperties.map(({ caption }) => caption);

    getRows = () => this.props.league.map(team => {
        console.log(team)
        return teamProperties.map(({ key }) => (key === "teamName"
        ? <Link to={createTeamUrl(team.id)}>{team[key]}</Link>
        : team[key]))
    })
        

    render() {
        if (this.props.leagueFetchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.league) {
            return <Spinner />;
        }

        console.log(this.props.league)

        return (
            <MountAnimation>
                <Table
                    header={this.getHeader()}
                    rows={this.getRows()}
                />
            </MountAnimation>
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
