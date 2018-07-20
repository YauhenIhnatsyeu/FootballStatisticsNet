import React, { Component } from "react";

import SpinnerSvg from "./spinner.svg";

import "./index.css";

export default class Spinner extends Component {
    render() {
        return (
            <div className="spinner-container">
                <SpinnerSvg />
            </div>
        );
    }
}
