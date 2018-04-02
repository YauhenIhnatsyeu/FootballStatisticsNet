import React, { Component } from "react";

import { Link } from "react-router-dom";

import "./index.css";

export default class Logo extends Component {
    render() {
        return (
            <Link to="/table" className="logo">Football Statistics</Link>
        );
    }
}
