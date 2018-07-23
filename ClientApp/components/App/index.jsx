import React, { Component } from "react";

import { Router } from "react-router-dom";

import HeaderContainer from "Containers/HeaderContainer";
import NotificationsContainer from "Containers/NotificationsContainer";
import OverlaySpinnerContainer from "Containers/OverlaySpinnerContainer";

import Main from "Components/Main";

import { history } from "Helpers/historyHelper";

export default class App extends Component {
    render() {
        return (
            <Router history={history}>
                <React.Fragment>
                    <HeaderContainer />
                    <Main />
                    <NotificationsContainer />
                    <OverlaySpinnerContainer />
                </React.Fragment>
            </Router>
        );
    }
}
