import React, { Component } from "react";

import PropTypes from "prop-types";

import Item from "Components/Item";
import TwoStatesButton from "Components/TwoStatesButton";

import { Link } from "react-router-dom";

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
        console.log(this.props.team)
        console.log(state)
        if (this.props.onButtonClick) {
            this.props.onButtonClick(this.props.team, state);
        }
    }

    render() {
        return (
            <Item onClick={this.props.onClick}>
                <div className="team-item">
                    {this.tryWrapWithTeamLink((
                        <div className="team-item__img-container">
                            <img src={this.props.team.crestUrl} className="team-item__img" alt="" />
                        </div>
                    ))}
                    <div className="team-item__info-container">
                        {this.tryWrapWithTeamLink((
                            <p className="team-item__name">{this.props.team.name}</p>
                        ))}
                        <p>Short name: {this.props.team.shortName}</p>

                        {this.props.team.squadMarketValue
                            && <p>Squad market value: {this.props.team.squadMarketValue}</p>}

                        {this.props.buttonRequired && (
                            <TwoStatesButton
                                className="team-item__button"
                                onClick={this.handleButtonClick}
                                falseStateCaption={this.props.falseStateCaption}
                                trueStateCaption={this.props.trueStateCaption}
                                defaultState={this.props.defaultState}
                            />
                        )}
                    </div>
                </div>
            </Item>
        );
    }
}

TeamItem.propTypes = {
    team: PropTypes.shape({
        id: PropTypes.number,
        crestUrl: PropTypes.string,
        name: PropTypes.string.isRequired,
        shortName: PropTypes.string.isRequired,
        squadMarketValue: PropTypes.string,
    }),
    teamUrl: PropTypes.string,
    onClick: PropTypes.func,
    buttonRequired: PropTypes.bool,
    onButtonClick: PropTypes.func,
    falseStateCaption: PropTypes.string,
    trueStateCaption: PropTypes.string,
    defaultState: PropTypes.bool,
};

TeamItem.defaultProps = {
    team: PropTypes.shape({
        crestUrl: null,
    }),
    teamUrl: null,
    onClick: null,
    buttonRequired: false,
    onButtonClick: null,
    falseStateCaption: null,
    trueStateCaption: null,
    defaultState: false,
};
