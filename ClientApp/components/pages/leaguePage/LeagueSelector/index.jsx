import React, { Component } from "react";

import PropTypes from "prop-types";

import Select from "Reusable/Select";

import leaguesData from "Constants/leaguesData";

export default class LeagueSelector extends Component {
    getOptions = () => leaguesData.map(({ id, title }) => ({
        option: title,
        value: id,
    }))

    getDefaultValue = () => leaguesData[this.props.leagueIndex].id

    handleChange = (event) => {
        const leagueIndex = leaguesData.findIndex(l => l.id === +event.target.value);

        if (this.props.onChange) {
            this.props.onChange(leagueIndex);
        }
    }

    render() {
        return (
            <Select
                onChange={this.handleChange}
                options={this.getOptions()}
                defaultValue={this.getDefaultValue()}
            />
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
