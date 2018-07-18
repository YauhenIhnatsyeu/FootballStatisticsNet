import React, { Component } from "react";

import {
    Route,
    Switch,
    Redirect,
} from "react-router-dom";

import routes from "Constants/routes";
import routePaths from "Constants/routePaths";

import "./index.css";

export default class Main extends Component {
    render() {
        return (
            <main>
                <div className="main__inner-container wrapper">
                    <div className="main__page-container">
                        <Switch>
                            {routes.map((route, index) => (
                                <Route
                                    path={route.path}
                                    render={props => <route.component {...props} />}
                                    key={index}
                                />
                            ))}
                            <Redirect to={routePaths.table} />
                        </Switch>
                    </div>
                </div>
            </main>
        );
    }
}
