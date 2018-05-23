import React, { Component } from "react";

import PropTypes from "prop-types";

import { Link } from "react-router-dom";

import routePaths from "Constants/routePaths";

import "./index.css";

export default class AuthBar extends Component {
    renderLink = (path, caption) => (
        <div className="auth-bar__link-container">
            <Link to={path} className="auth-bar__link">{caption}</Link>
        </div>
    )

    renderSignedOutAuthBar = () => (
        <div className="auth-bar">
            {this.renderLink(routePaths.login, "Log in")}
            <p className="auth-bar__text">or</p>
            {this.renderLink(routePaths.register, "Sign up")}
        </div>
    )

    renderLoggedInAuthBar = () => {
        const { name } = this.props.user;
        return (
            <div className="auth-bar">
                <p className="auth-bar__text">
                    {
                        name
                            ? `Hello, ${name}`
                            : "You're logged in!"
                    }
                </p>
                {this.renderLink(routePaths.logout, "Log out")}
            </div>
        );
    }

    render() {
        return this.props.user
            ? this.renderLoggedInAuthBar()
            : this.renderSignedOutAuthBar();
    }
}

AuthBar.propTypes = {
    user: PropTypes.shape({
        name: PropTypes.string,
    }),
};

AuthBar.defaultProps = {
    user: null,
};
