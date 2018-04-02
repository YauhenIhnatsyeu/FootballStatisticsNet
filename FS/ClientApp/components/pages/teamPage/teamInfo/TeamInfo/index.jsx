import React, { Component } from "react";

import PropTypes from "prop-types";

export default class TeamInfo extends Component {
    render() {
        return (
            <div className="team-page__info-container">
                {this.props.children}
            </div>
        );
    }
}

TeamInfo.propTypes = {
    children: PropTypes.node.isRequired,
};
