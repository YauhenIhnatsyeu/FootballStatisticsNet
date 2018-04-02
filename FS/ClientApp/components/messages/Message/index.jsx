import React, { Component } from "react";

import PropTypes from "prop-types";

import "./index.css";

export default class Message extends Component {
    render() {
        return (
            <div className="message-container">
                <div className="message">
                    {this.props.children}
                </div>
            </div>
        );
    }
}

Message.propTypes = {
    children: PropTypes.node.isRequired,
};
