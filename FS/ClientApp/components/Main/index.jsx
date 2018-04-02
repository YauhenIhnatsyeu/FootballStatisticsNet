import React, { Component } from "react";

import {
    Route,
    Switch,
    Redirect,
} from "react-router-dom";

import TablePageContainer from "Containers/TablePageContainer";
import LeaguePageContainer from "Containers/LeaguePageContainer";
import TeamPageContainer from "Containers/TeamPageContainer";

import routePathes from "Constants/routePathes";

import "./index.css";

export default class Main extends Component {
    render() {
        const tablePage = (
            <div className="main__table-panel-container">
                <TablePageContainer />
            </div>
        );

        const leaguePage = (
            <div className="main__league-panel-container">
                <LeaguePageContainer />
            </div>
        );

        const teamPage = props => (
            <div className="main__team-page-container">
                <TeamPageContainer teamId={+props.match.params.id} />
            </div>
        );

        return (
            <main>
                <div className="main__inner-container wrapper">
                    <Switch>
                        <Route path={routePathes.table} render={() => tablePage} />
                        <Route path={routePathes.teams} render={() => leaguePage} />
                        <Route path={routePathes.team} render={props => teamPage(props)} />
                        <Redirect to={routePathes.table} />
                    </Switch>
                </div>
            </main>
        );
    }
}
