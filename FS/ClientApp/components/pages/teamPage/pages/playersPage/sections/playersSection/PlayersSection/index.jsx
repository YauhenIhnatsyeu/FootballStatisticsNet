import React, { Component } from "react";

import PropTypes from "prop-types";

import ItemsListWithPagingControls from "Components/ItemsListWithPagingControls";

import Loading from "Components/messages/Loading";
import Error from "Components/messages/Error";

import PlayerItem from "PlayersPageSections/playersSection/PlayerItem";

export default class PlayersSection extends Component {
    constructor(props) {
        super(props);

        console.log(this.props);

        this.props.fetchPlayers(this.props.team._links.self.href);
    }

    componentWillReceiveProps = (nextProps) => {
        if (JSON.stringify(this.props.team) !== JSON.stringify(nextProps.team)) {
            this.props.fetchPlayers(nextProps.team._links.self.href)
        }
    }

    handlePageChanged = pageIndex =>
        this.props.updatePlayersPageIndex(pageIndex)

    render() {
        if (this.props.fetchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.players) {
            return <Loading />;
        }

        return (
            <ItemsListWithPagingControls
                items={this.props.players}
                itemComponent={<PlayerItem />}
                itemKey="player"
                currentPageIndex={this.props.playersPageIndex}
                onPageChanged={this.handlePageChanged}
            />
        );
    }
}

PlayersSection.propTypes = {
    fetchPlayers: PropTypes.func.isRequired,
    updatePlayersPageIndex: PropTypes.func.isRequired,
    fetchingErrorOccured: PropTypes.bool.isRequired,
    team: PropTypes.shape({
        _links: PropTypes.shape({
            self: PropTypes.shape({
                href: PropTypes.string.isRequired,
            }).isRequired,
        }).isRequired,
    }).isRequired,
    players: PropTypes.arrayOf(PropTypes.object),
    playersPageIndex: PropTypes.number.isRequired,
};

PlayersSection.defaultProps = {
    players: null,
};
