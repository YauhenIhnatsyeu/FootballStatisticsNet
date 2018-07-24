import React, { Component } from "react";

import {
    Route,
    Switch,
    Redirect,
} from "react-router-dom";

import routes from "Constants/routes";
import defaultRoutePaths from "Constants/defaultRoutePaths";

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
                                    exact={route.exact}
                                    render={props => <route.component {...props} />}
                                    key={index}
                                />
                            ))}
                            <Redirect to={defaultRoutePaths.rootDefaultPath} />
                        </Switch>
                    </div>
                </div>
            </main>
        );
    }
}
