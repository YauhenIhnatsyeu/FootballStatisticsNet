import React, { Component } from "react";

import PropTypes from "prop-types";

import Section from "Pages/teamPage/teamInfo/Section";

import PlayersSection from "PlayersPageSections/playersSection/PlayersSection";

export default class PlayersPage extends Component {
    render() {
        const hashtag = this.props.team.shortName ?
            this.props.team.shortName.toLowerCase() : "football";

        return (
            <React.Fragment>
                <Section title="Players">
                    <PlayersSection
                        team={this.props.team}
                        players={this.props.players}
                        playersPageIndex={this.props.playersPageIndex}
                        fetchPlayers={this.props.fetchPlayers}
                        updatePlayersPageIndex={this.props.updatePlayersPageIndex}
                        fetchingErrorOccured={this.props.fetchingErrorOccured}
                    />
                </Section>
                <Section title={`Tweets for tag #${hashtag}`} />
            </React.Fragment>
        );
    }
}

PlayersPage.propTypes = {
    fetchPlayers: PropTypes.func.isRequired,
    updatePlayersPageIndex: PropTypes.func.isRequired,
    fetchingErrorOccured: PropTypes.bool.isRequired,
    team: PropTypes.shape({
        shortName: PropTypes.string,
        _links: PropTypes.shape({
            self: PropTypes.shape({
                href: PropTypes.string.isRequired,
            }).isRequired,
        }).isRequired,
    }).isRequired,
    players: PropTypes.arrayOf(PropTypes.object),
    playersPageIndex: PropTypes.number.isRequired,
};

PlayersPage.defaultProps = {
    players: null,
};
