import React, { Component } from "react";

import PropTypes from "prop-types";

import Item from "Reusable/Item";
import TwoStatesButton from "Reusable/TwoStatesButton";

import { Link } from "react-router-dom";

import unavailableUrl from "Constants/unavailableUrl";

import "./index.css";

export default class TeamItem extends Component {
    tryWrapWithTeamLink = component => (
        this.props.teamUrl && !this.props.onClick
            ? (
                <Link to={this.props.teamUrl} className="team-item__link">
                    {component}
                </Link>
            )
            : component
    );

    handleButtonClick = (state) => {
        if (this.props.onButtonClick) {
            this.props.onButtonClick(this.props.team, state);
        }
    }

    handleImageError = (e) => {
        e.target.src = unavailableUrl;
    }

    render() {
        const {
            onClick, team, buttonRequired, falseStateCaption, trueStateCaption, defaultState, children,
        } = this.props;

        return (
            <Item onClick={onClick ? () => onClick(this) : null}>
                <div className="team-item">
                    {this.tryWrapWithTeamLink((
                        <div className="team-item__img-container">
                            <img
                                className="team-item__img"
                                src={team.crestUrl}
                                alt=""
                                onError={this.handleImageError}
                            />
                        </div>
                    ))}
                    <div className="team-item__info-container">
                        {this.tryWrapWithTeamLink((
                            <p className="team-item__name">{team.name}</p>
                        ))}
                        <p>Short name: {team.shortName}</p>

                        {team.squadMarketValue
                            && <p>Squad market value: {team.squadMarketValue}</p>}

                        {buttonRequired && (
                            <TwoStatesButton
                                className="team-item__button"
                                onClick={this.handleButtonClick}
                                falseStateCaption={falseStateCaption}
                                trueStateCaption={trueStateCaption}
                                defaultState={defaultState}
                            />
                        )}
                    </div>
                </div>

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
    teamUrl: PropTypes.string,
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
    teamUrl: null,
    onClick: null,
    buttonRequired: false,
    onButtonClick: null,
    falseStateCaption: null,
    trueStateCaption: null,
    defaultState: false,
    children: null,
};
