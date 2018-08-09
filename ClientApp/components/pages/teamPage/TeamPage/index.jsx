import React, { Component } from "react";

import PropTypes from "prop-types";

import {
    Route,
    Switch,
    Redirect,
} from "react-router-dom";

import routePaths from "Constants/routePaths";
import teamRoutes from "Constants/teamRoutes";
import teamRoutePaths from "Constants/teamRoutePaths";
import defaultRoutePaths from "Constants/defaultRoutePaths";

import Loading from "Reusable/messages/Loading";
import Error from "Reusable/messages/Error";

import createTeamUrl from "Utilities/urlsCreators";

import TeamItemForHeader from "../TeamItemForHeader";

import "./index.css";

export default class TeamPage extends Component {
    constructor(props) {
        super(props);

        this.teamId = +props.match.params.id;
    }

    componentDidMount() {
        this.props.fetchTeam(this.teamId);
    }

    getTabIndex = () => {
        const { pathname: currentPath } = this.props.location;
        const pathChunks = currentPath.split("/");
        const endOfThePath = pathChunks[pathChunks.length - 1];
        const teamRoutePathsKeys = Object.keys(teamRoutePaths);
        const index = teamRoutePathsKeys.indexOf(endOfThePath);

        return index <= 0 ? 0 : index;
    }

    renderRoutes = () => teamRoutes.map((route, index) => (
        <Route
            path={routePaths.team + route.path}
            render={() => <route.component />}
            key={index}
        />
    ))

    render() {
        if (this.props.teamFetchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.team) {
            return <Loading />;
        }

        const currentTeamUrl = createTeamUrl(this.teamId);

        return (
            <div className="team-page">
                <div className="team-page__team-item-for-header-container">
                    <TeamItemForHeader
                        team={this.props.team}
                        defaultTeamPageIndex={this.getTabIndex()}
                    />
                </div>
                <div className="team-page__info-container">
                    <Switch>
                        {this.renderRoutes()}
                        <Redirect to={currentTeamUrl + defaultRoutePaths.teamDefaultPath} />
                    </Switch>
                </div>
            </div>
        );
    }
}


TeamPage.propTypes = {
    match: PropTypes.shape({
        params: PropTypes.shape({
            id: PropTypes.string.isRequired,
        }).isRequired,
    }).isRequired,
    fetchTeam: PropTypes.func.isRequired,
    teamFetchingErrorOccured: PropTypes.bool,
    team: PropTypes.shape({}),
    location: PropTypes.shape({
        pathname: PropTypes.string.isRequired,
    }).isRequired,
};

TeamPage.defaultProps = {
    team: null,
    teamFetchingErrorOccured: false,
};
