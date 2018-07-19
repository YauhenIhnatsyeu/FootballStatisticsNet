import React, { Component } from "react";

import PropTypes from "prop-types";

import "./index.css";

export default class Notification extends Component {
    constructor(props) {
        super(props);

        this.state = {
            visible: true,
        };
    }

    componentDidMount() {
        if (!this.props.alwaysVisible) {
            window.setTimeout(this.handleCrossClick, this.props.timeout);
        }
    }

    handleCrossClick = () => {
        this.setState({
            visible: false,
        });
    }

    renderTitle = () => this.props.title && (
        <div className="notification__title-container">
            <span className="notification__title">{this.props.title}</span>
        </div>
    )

    renderText = () => this.props.text && (
        <div className="notification__text-container">
            <span className="notification_text">{this.props.text}</span>
        </div>
    )

    renderCross = () => this.props.closable && (
        <div className="notification__cross-container">
            <button
                className="notification__cross"
                onClick={this.handleCrossClick}
            >
                &#10006; {/* Cross */}
            </button>
        </div>
    )

    renderNotification = () => (
        <div className={`notification notification_${this.props.position}`}>
            <div className="notification__inner-container">
                {this.renderTitle()}
                {this.renderText()}
                {this.renderCross()}
            </div>
        </div>
    )

    render() {
        return this.state.visible
            ? this.renderNotification()
            : null;
    }
}

Notification.propTypes = {
    text: PropTypes.string,
    title: PropTypes.string,
    position: PropTypes.string,
    closable: PropTypes.bool,
    alwaysVisible: PropTypes.bool,
    timeout: PropTypes.number,
};

Notification.defaultProps = {
    text: null,
    title: null,
    position: "bottom-right",
    closable: true,
    alwaysVisible: false,
    timeout: 5000,
};
