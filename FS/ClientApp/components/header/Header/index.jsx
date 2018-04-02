import React, { Component } from "react";

import Logo from "../Logo";
import Nav from "../Nav";

import "./index.css";

export default class Header extends Component {
    render() {
        return (
            <header>
                <div className="header__inner-container">
                    <div className="header__wrapper wrapper">
                        <div className="header__logo-container">
                            <Logo />
                        </div>
                        <div className="header__nav-container">
                            <Nav />
                        </div>
                    </div>
                </div>
            </header>
        );
    }
}
