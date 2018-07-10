import React, { Component } from "react";

import PropTypes from "prop-types";

import leaguesData from "Constants/leaguesData";

import ComponentChooser from "Components/ComponentChooser";

import TeamItem from "Components/TeamItem";

export default class FanClubCreatePage extends Component {
    componentDidMount() {
        this.props.fetchTeams(leaguesData.map(league => league.id));
    }

    getTeamItems = teams => teams && teams.map((team, index) => (
        <TeamItem
            team={team}
            onClick={this.handleClick}
            key={index}
        />
    ))

    getComponents = (value) => {
        const relatedTeams = this.props.teams.filter(team =>
            this.valueRelatesToTeam(value, team));

        return this.getTeamItems(relatedTeams);
    }

    valueRelatesToTeam = (value, team) => {
        const { name, shortName } = team;

        return (name && name.toLowerCase().startsWith(value.toLowerCase()))
            || (shortName && shortName.toLowerCase().startsWith(value.toLowerCase()));
    }

    handleClick = (component) => {
        console.log(component);
    }

    handleSubmit = (user) => {
        this.props.createFanClub(user);
    }

    render() {
        return (
            <ComponentChooser
                getComponents={this.getComponents}
            />
        );
    }
}

FanClubCreatePage.propTypes = {
    createFanClub: PropTypes.func.isRequired,
    teams: PropTypes.arrayOf(PropTypes.object),
    fetchTeams: PropTypes.func.isRequired,
};

FanClubCreatePage.defaultProps = {
    teams: null,
};
