import React, { Component } from "react";

import PropTypes from "prop-types";

import SectionHeader from "Components/SectionHeader";
import LeagueSelectorContainer from "Containers/LeagueSelectorContainer";
import TeamsListContainer from "Containers/TeamsListContainer";

import leaguesData from "Constants/leaguesData";

import "./index.css";

export default class LeaguePage extends Component {
    render() {
        return (
            <React.Fragment>
                <SectionHeader title={leaguesData[this.props.leagueIndex].title} />

                <div className="league-panel__legue-selector-container">
                    <LeagueSelectorContainer leagueIndex={this.props.leagueIndex} />
                </div>

                <div className="league-panel__teams-list-container">
                    <TeamsListContainer />
                </div>
            </React.Fragment>
        );
    }
}

LeaguePage.propTypes = {
    leagueIndex: PropTypes.number.isRequired,
};
