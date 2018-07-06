import React, { Component } from "react";

import PropTypes from "prop-types";

import InputForm from "Components/inputForm/InputForm";
import inputProps from "Constants/inputProps";

export default class FanClubCreatePage extends Component {
    handleSubmit = (user) => {
        this.props.createFanClub(user);
    }

    render() {
        return (
            <InputForm
                inputProps={inputProps.createFanClub}
                submitValue="Create fan club"
                onSubmit={this.handleSubmit}
            />
        );
    }
}

FanClubCreatePage.propTypes = {
    createFanClub: PropTypes.func.isRequired,
};
