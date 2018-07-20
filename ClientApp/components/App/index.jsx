import React, { Component } from "react";

import { BrowserRouter as Router } from "react-router-dom";

import HeaderContainer from "Containers/HeaderContainer";
import NotificationsContainer from "Containers/NotificationsContainer";

import Main from "Components/Main";

export default class App extends Component {
    render() {
        return (
            <Router>
                <React.Fragment>
                    <HeaderContainer />
                    <Main />
                    <NotificationsContainer />
                </React.Fragment>
            </Router>
        );
    }
}
