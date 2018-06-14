import React, { Component } from "react";

import { Link } from "react-router-dom";

import routePaths from "Constants/routePaths";

import "./index.css";

export default class Logo extends Component {
    render() {
        return (
            <Link to={routePaths.table} className="logo">Football Statistics</Link>
        );
    }
}
