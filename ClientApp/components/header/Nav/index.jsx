import React, { Component } from "react";

import { NavLink } from "react-router-dom";

import routes from "Constants/routes";

import "./index.css";

export default class Nav extends Component {
    renderNavItem = route => (
        <li className="nav__item">
            <NavLink
                to={route.path}
                className="nav__link"
                activeClassName="nav__link_state_active"
            >
                {route.caption}
            </NavLink>
        </li>
    )

    render() {
        return (
            <nav className="nav">
                <ul className="nav__list">
                    {this.renderNavItem(routes[0])}
                    {this.renderNavItem(routes[1])}
                </ul>
            </nav>
        );
    }
}
