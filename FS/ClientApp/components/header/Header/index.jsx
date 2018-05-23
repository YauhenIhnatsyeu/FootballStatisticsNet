import React, { Component } from "react";

import PropTypes from "prop-types";

import Logo from "../Logo";
import Nav from "../Nav";
import AuthBar from "../AuthBar";

import "./index.css";

export default class Header extends Component {
    render() {
        return (
            <header>
                <div className="header__inner-container">
                    <div className="header__wrapper wrapper">
                        <div className="header__logo-nav-container">
                            <Logo />
                            <div className="header__nav-container">
                                <Nav />
                            </div>
                        </div>
                        <div className="header__auth-bar-container">
                            <AuthBar user={this.props.user} />
                        </div>
                    </div>
                </div>
            </header>
        );
    }
}

Header.propTypes = {
    user: PropTypes.shape({}),
};

Header.defaultProps = {
    user: null,
};
