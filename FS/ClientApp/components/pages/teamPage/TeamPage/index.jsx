import React, { Component } from "react";

import PropTypes from "prop-types";

import Loading from "Components/messages/Loading";
import Error from "Components/messages/Error";
import PlayersPageContainer from "Containers/PlayersPageContainer";
import FixturesPageContainer from "Containers/FixturesPageContainer";

import TeamItemForHeader from "../TeamItemForHeader";
import TeamInfo from "../teamInfo/TeamInfo";

import "./index.css";

export default class TeamPage extends Component {
    constructor(props) {
        super(props);

        this.props.resetTeamPageIndices();

        this.props.fetchTeam(this.props.teamId);
    }

    render() {
        if (this.props.fetchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.team) {
            return <Loading />;
        }

        return (
            <div className="team-page">
                <div className="team-page__team-item-for-header-container">
                    <TeamItemForHeader
                        team={this.props.team}
                        defaultTeamPageIndex={this.props.teamPageIndex}
                        updateTeamPageIndex={this.props.updateTeamPageIndex}
                    />
                </div>
                <TeamInfo>
                    {this.props.teamPageIndex === 0 ?
                        <PlayersPageContainer
                            team={this.props.team}
                            fetchingErrorOccured={this.props.fetchingErrorOccured}
                        />
                        :
                        <FixturesPageContainer
                            teamId={this.props.teamId}
                            fetchingErrorOccured={this.props.fetchingErrorOccured}
                        />
                    }
                </TeamInfo>
            </div>
        );
    }
}

TeamPage.propTypes = {
    resetTeamPageIndices: PropTypes.func.isRequired,
    teamId: PropTypes.number.isRequired,
    fetchTeam: PropTypes.func.isRequired,
    fetchingErrorOccured: PropTypes.bool.isRequired,
    team: PropTypes.shape({
        id: PropTypes.number,
        crestUrl: PropTypes.string.isRequired,
        name: PropTypes.string.isRequired,
        shortName: PropTypes.string.isRequired,
        squadMarketValue: PropTypes.string,
    }),
    teamPageIndex: PropTypes.number.isRequired,
    updateTeamPageIndex: PropTypes.func.isRequired,
};

TeamPage.defaultProps = {
    team: null,
};
