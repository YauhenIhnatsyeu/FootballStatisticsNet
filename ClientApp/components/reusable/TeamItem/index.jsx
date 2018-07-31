import React, { Component } from "react";

import PropTypes from "prop-types";

import Item from "Reusable/items/Item";
import ImageWithInfo from "Reusable/ImageWithInfo";
import TwoStatesButton from "Reusable/TwoStatesButton";

import unavailableUrl from "Constants/unavailableUrl";

import createTeamUrl from "Utilities/urlsCreators";

export default class TeamItem extends Component {
    getInfo = () => {
        const { shortName, squadMarketValue } = this.props.team;
        return [
            shortName && `Short name: ${shortName}`,
            squadMarketValue && `Squad market value: ${squadMarketValue}`,
        ];
    }

    getTeamUrl = () => createTeamUrl(this.props.team.id)

    handleButtonClick = (state) => {
        if (this.props.onButtonClick) {
            this.props.onButtonClick(this.props.team, state);
        }
    }

    handleImageError = (e) => {
        e.target.src = unavailableUrl;
    }

    renderButton = () => {
        const {
            buttonRequired, falseStateCaption, trueStateCaption, defaultState,
        } = this.props;

        return buttonRequired && (
            <TwoStatesButton
                onClick={this.handleButtonClick}
                falseStateCaption={falseStateCaption}
                trueStateCaption={trueStateCaption}
                defaultState={defaultState}
            />
        );
    }

    render() {
        const { onClick, team, children } = this.props;

        return (
            <Item onClick={onClick ? () => onClick(this) : null}>
                <ImageWithInfo
                    imageUrl={team.crestUrl}
                    title={team.name}
                    info={this.getInfo()}
                    link={this.props.linkRequired
                        && !this.props.onClick
                        && this.getTeamUrl()}
                    extraComponentForInfo={this.renderButton()}
                />

                {children}
            </Item>
        );
    }
}

TeamItem.propTypes = {
    team: PropTypes.shape({
        id: PropTypes.number,
        crestUrl: PropTypes.string,
        name: PropTypes.string,
        shortName: PropTypes.string,
        squadMarketValue: PropTypes.string,
    }),
    linkRequired: PropTypes.bool,
    onClick: PropTypes.func,
    buttonRequired: PropTypes.bool,
    onButtonClick: PropTypes.func,
    falseStateCaption: PropTypes.string,
    trueStateCaption: PropTypes.string,
    defaultState: PropTypes.bool,
    children: PropTypes.oneOfType([
        PropTypes.node,
        PropTypes.arrayOf(PropTypes.node),
    ]),
};

TeamItem.defaultProps = {
    team: PropTypes.shape({
        id: null,
        crestUrl: null,
        name: null,
        shortName: null,
        squadMarketValue: null,
    }),
    linkRequired: false,
    onClick: null,
    buttonRequired: false,
    onButtonClick: null,
    falseStateCaption: null,
    trueStateCaption: null,
    defaultState: false,
    children: null,
};
