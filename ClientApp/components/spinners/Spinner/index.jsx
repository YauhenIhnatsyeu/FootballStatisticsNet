import React, { Component } from "react";

import SpinnerSvg from "../svg/spinner.svg";

import "./index.css";

export default class Spinner extends Component {
    render() {
        return (
            <div className="spinner">
                <img src={SpinnerSvg} alt="" />
            </div>
        );
    }
}
