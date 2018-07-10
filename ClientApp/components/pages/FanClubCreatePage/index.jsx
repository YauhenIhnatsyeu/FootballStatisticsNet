import React, { Component } from "react";

import PropTypes from "prop-types";

import ComponentChooser from "Components/ComponentChooser";

import TeamItem from "Components/TeamItem";

export default class FanClubCreatePage extends Component {
    componentDidMount() {
        this.props.fetchTeams(444);
    }

    getTeamItems = () => this.props.teams && this.props.teams.map((team, index) => (
        <TeamItem
            team={team}
            onClick={this.handleClick}
            key={index}
        />
    ))

    handleClick = (e) => {
        console.log(e);
    }

    handleSubmit = (user) => {
        this.props.createFanClub(user);
    }

    valueRelatesToComponent = (value, component) => {
        const { name, shortName } = component.props.team;

        return (name && name.toLowerCase().startsWith(value.toLowerCase()))
            || (shortName && shortName.toLowerCase().startsWith(value.toLowerCase()));
    }

    render() {
        console.log(this.props.teams)
        console.log(this.getTeamItems())
        return (
            <ComponentChooser
                components={this.getTeamItems()}
                valueRelatesToComponent={this.valueRelatesToComponent}
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
