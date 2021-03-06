import React, { Component } from "react";

import PropTypes from "prop-types";

import inputProps from "Constants/inputProps";
import leaguesData from "Constants/leaguesData";

import Form from "Components/form/Form";
import Input from "Components/form/Input";
import Custom from "Components/form/Custom";

import ComponentChooser from "Reusable/ComponentChooser";

import TeamItem from "Reusable/TeamItem";

import { renderInputs } from "Helpers/formHelper";

import {
    getChangedValueFromTeamChooser,
    getChangedValueFromFileEvent,
} from "Helpers/getChangedValueHelper";

export default class FanClubCreatePage extends Component {
    componentDidMount() {
        this.props.fetchTeams(leaguesData.map(league => league.id));
    }

    getTeamItems = teams => teams && teams.map(team => <TeamItem team={team} />)

    getComponents = (value) => {
        const relatedTeams = this.props.teams
            .filter(team => this.valueRelatesToTeam(value, team))
            .slice(0, 5);

        return this.getTeamItems(relatedTeams);
    }

    getSelectedComponentValue = (teamComponent) => {
        if (teamComponent && teamComponent.props && teamComponent.props.team && teamComponent.props.team.name) {
            return teamComponent.props.team.name;
        }
        return "";
    }

    handleSubmit = (user) => {
        this.props.createFanClub(user);
    }

    valueRelatesToTeam = (value, team) => {
        const { name, shortName } = team;

        return (name && name.toLowerCase().startsWith(value.toLowerCase()))
            || (shortName && shortName.toLowerCase().startsWith(value.toLowerCase()));
    }

    render() {
        return (
            <Form onSubmit={this.handleSubmit}>
                {[
                    ...renderInputs(inputProps.createFanClub),
                    <Custom
                        name="teamId"
                        label="Team"
                        component={
                            <ComponentChooser
                                getComponents={this.getComponents}
                                getSelectedComponentValue={this.getSelectedComponentValue}
                            />
                        }
                        getChangedValueFunc={getChangedValueFromTeamChooser}
                        key={Object.keys(inputProps.createFanClub).length}
                    />,
                    <Input
                        name="avatar"
                        type="file"
                        label="Fan club picture"
                        getChangedValueFunc={getChangedValueFromFileEvent}
                        key={Object.keys(inputProps.register).length + 1}
                    />,
                ]}
            </Form>
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
