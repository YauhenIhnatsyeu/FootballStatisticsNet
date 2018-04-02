import React, { Component } from "react";

import PropTypes from "prop-types";

import leaguesData from "Constants/leaguesData";

import "./index.css";

export default class LeagueSelector extends Component {
    constructor(props) {
        super(props);

        const leagueId = leaguesData[this.props.leagueIndex].id;

        this.props.fetchTeams(leagueId);
    }

    handleChange = (event) => {
        const leagueIndex = leaguesData.findIndex(l => l.title === event.target.value);

        this.props.updateLeagueIndex(leagueIndex);

        this.props.fetchTeams(leaguesData[leagueIndex].id);
    }

    render() {
        return (
            <div className="selector">
                <select
                    className="selector__select"
                    onChange={this.handleChange}
                    value={leaguesData[this.props.leagueIndex].title}
                >
                    {leaguesData.map((leagueData, index) =>
                        (
                            <option key={index}>
                                {leagueData.title}
                            </option>
                        ))
                    }
                </select>
            </div>
        );
    }
}

LeagueSelector.propTypes = {
    fetchTeams: PropTypes.func.isRequired,
    updateLeagueIndex: PropTypes.func.isRequired,
    leagueIndex: PropTypes.number.isRequired,
};
