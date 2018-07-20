import React, { Component } from "react";

import PropTypes from "prop-types";

import Notification from "Components/Notification";

export default class Notifications extends Component {
    constructor(props) {
        super(props);

        this.state = { notifications: [] };
    }

    componentWillReceiveProps(nextProps) {
        const { notification } = nextProps;

        this.setState({
            notifications: [...this.state.notifications, notification],
        });
    }

    renderNotification = (notification, key) => notification && (
        <Notification
            title={notification.title}
            text={notification.text}
            key={key}
        />
    )

    render() {
        return this.state.notifications.map((notification, index) =>
            this.renderNotification(notification, index));
    }
}

Notifications.propTypes = {
    notification: PropTypes.shape({}),
};

Notifications.defaultProps = {
    notification: null,
};
