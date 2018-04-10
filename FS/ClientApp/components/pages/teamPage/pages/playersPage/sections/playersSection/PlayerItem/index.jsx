import React, { Component } from "react";

import PropTypes from "prop-types";

import Item from "Components/Item";

import "./index.css";

export default class PlayerItem extends Component {
    render() {
        return (
            <Item>
                <p className="player-item__name">
                    {this.props.player.jerseyNumber
                        && `${this.props.player.jerseyNumber}. `}
                    {this.props.player.name}
                </p>
                <p>Position: {this.props.player.position}</p>
                <p>Date of birth: {this.props.player.dateOfBirth}</p>
                {this.props.player.marketValue
                    && <p>Market value: {this.props.player.marketValue}</p>}
            </Item>
        );
    }
}

PlayerItem.propTypes = {
    player: PropTypes.shape({
        jerseyNumber: PropTypes.number,
        name: PropTypes.string.isRequired,
        position: PropTypes.string.isRequired,
        dateOfBirth: PropTypes.string.isRequired,
        marketValue: PropTypes.string,
    }),
};

PlayerItem.defaultProps = {
    player: null,
};
