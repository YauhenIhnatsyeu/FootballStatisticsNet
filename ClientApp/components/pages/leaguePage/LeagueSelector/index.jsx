import React, { Component } from "react";

import PropTypes from "prop-types";

import leaguesData from "Constants/leaguesData";

import "./index.css";

export default class LeagueSelector extends Component {
    handleChange = (event) => {
        const leagueIndex = leaguesData.findIndex(l => l.title === event.target.value);

        if (this.props.onChange) {
            this.props.onChange(leagueIndex);
        }
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
    onChange: PropTypes.func,
    leagueIndex: PropTypes.number.isRequired,
};

LeagueSelector.defaultProps = {
    onChange: null,
};
