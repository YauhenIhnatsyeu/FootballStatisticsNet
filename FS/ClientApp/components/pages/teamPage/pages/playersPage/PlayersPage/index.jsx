import React, { Component } from "react";

import PropTypes from "prop-types";

import Section from "Pages/teamPage/Section";

import PlayersSection from "PlayersPageSections/playersSection/PlayersSection";
import TweetsSection from "PlayersPageSections/tweetsSection/TweetsSection";

export default class PlayersPage extends Component {
    render() {
        const teamName = this.props.team.shortName
            ? this.props.team.shortName.toLowerCase()
            : "football";

        return (
            <React.Fragment>
                <Section title="Players">
                    <PlayersSection
                        team={this.props.team}
                        players={this.props.players}
                        playersPageIndex={this.props.playersPageIndex}
                        fetchPlayers={this.props.fetchPlayers}
                        updatePlayersPageIndex={this.props.updatePlayersPageIndex}
                        playersFetchingErrorOccured={this.props.playersFetchingErrorOccured}
                    />
                </Section>
                <Section title={`Tweets for tag #${teamName}`}>
                    <TweetsSection
                        query={`#${teamName}`}
                        tweets={this.props.tweets}
                        tweetsSearchingErrorOccured={this.props.tweetsSearchingErrorOccured}
                        searchTweets={this.props.searchTweets}
                    />
                </Section>
            </React.Fragment>
        );
    }
}

PlayersPage.propTypes = {
    fetchPlayers: PropTypes.func.isRequired,
    updatePlayersPageIndex: PropTypes.func.isRequired,
    playersFetchingErrorOccured: PropTypes.bool.isRequired,
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
    tweets: PropTypes.arrayOf(PropTypes.object),
    tweetsSearchingErrorOccured: PropTypes.bool.isRequired,
    searchTweets: PropTypes.func.isRequired,
};

PlayersPage.defaultProps = {
    players: null,
    tweets: null,
};
