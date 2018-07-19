import React, { Component } from "react";

import { Link } from "react-router-dom";

import defaultRoutePaths from "Constants/defaultRoutePaths";

import "./index.css";

export default class Logo extends Component {
    render() {
        return (
            <Link to={defaultRoutePaths.rootDefaultPath} className="logo">Football Statistics</Link>
        );
    }
}
