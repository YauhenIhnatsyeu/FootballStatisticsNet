import React, { Component } from "react";

import { NavLink } from "react-router-dom";

import routePathes from "Constants/routePathes";

import "./index.css";

export default class Nav extends Component {
    renderNavItem = path => (
        <li className="nav__item">
            <NavLink
                to={path}
                className="nav__link"
                activeClassName="nav__link_state_active"
            >
                Table
            </NavLink>
        </li>
    )

    render() {
        return (
            <nav className="nav">
                <ul className="nav__list">
                    {this.renderNavItem(routePathes.table)}
                    {this.renderNavItem(routePathes.teams)}
                </ul>
            </nav>
        );
    }
}
