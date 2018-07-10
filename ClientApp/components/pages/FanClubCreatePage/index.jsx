import React, { Component } from "react";

import PropTypes from "prop-types";

export default class FanClubCreatePage extends Component {
    handleSubmit = (user) => {
        this.props.createFanClub(user);
    }

    render() {
        return null;
    }
}

FanClubCreatePage.propTypes = {
    createFanClub: PropTypes.func.isRequired,
};
