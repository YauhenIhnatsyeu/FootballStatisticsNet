import React, { Component } from "react";

import PropTypes from "prop-types";

import { getComponentsUsingArrayOfProps } from "Helpers/reactHelper";

import ItemsListWithPagingControls from "Reusable/items/ItemsListWithPagingControls";

import Spinner from "Reusable/spinners/Spinner";
import Error from "Reusable/messages/Error";

import PlayerItem from "PlayersPageSections/playersSection/PlayerItem";

import MountAnimation from "Components/animations/MountAnimation";

export default class PlayersSection extends Component {
    componentDidMount() {
        this.props.fetchPlayers(this.props.team.id);
    }

    handlePageChanged = (pageIndex) => {
        this.props.updatePlayersPageIndex(pageIndex);
    }

    render() {
        if (this.props.playersFetchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.players) {
            return <Spinner />;
        }

        return (
            <MountAnimation>
                <ItemsListWithPagingControls
                    currentPageIndex={this.props.playersPageIndex}
                    onPageChanged={this.handlePageChanged}
                >
                    {getComponentsUsingArrayOfProps(
                        PlayerItem,
                        "player",
                        this.props.players,
                    )}
                </ItemsListWithPagingControls>
            </MountAnimation>
        );
    }
}

PlayersSection.propTypes = {
    fetchPlayers: PropTypes.func.isRequired,
    updatePlayersPageIndex: PropTypes.func.isRequired,
    playersFetchingErrorOccured: PropTypes.bool.isRequired,
    team: PropTypes.shape({
        id: PropTypes.number,
    }),
    players: PropTypes.arrayOf(PropTypes.object),
    playersPageIndex: PropTypes.number.isRequired,
};

PlayersSection.defaultProps = {
    team: null,
    players: null,
};
