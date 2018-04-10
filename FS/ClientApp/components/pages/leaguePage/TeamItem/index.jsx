import React, { Component } from "react";

import PropTypes from "prop-types";

import createTeamUrl from "Utilities/urlsCreators";

import Item from "Components/Item";

import { Link } from "react-router-dom";

import "./index.css";

export default class TeamItem extends Component {
    isThisTeamFavorite = () =>
        this.props.favoriteTeams.includes(this.props.team.id);

    handleButtonClick = () => {
        if (this.isThisTeamFavorite()) {
            this.props.removeTeamFromFavorites(this.props.team);
        } else {
            this.props.addTeamToFavorites(this.props.team);
        }
    }

    render() {
        const teamUrl = createTeamUrl(this.props.team.id);

        return (
            <Item>
                <div className="team-item">
                    <Link to={teamUrl} className="team-item__link">
                        <div className="team-item__img-container">
                            <img src={this.props.team.crestUrl} className="team-item__img" alt="" />
                        </div>
                    </Link>
                    <div className="team-item__info-container">
                        <Link to={teamUrl} className="team-item__link">
                            <p className="team-item__name">{this.props.team.name}</p>
                        </Link>
                        <p>Short name: {this.props.team.shortName}</p>
                        {
                            this.props.team.squadMarketValue &&
                            <p>Squad market value: {this.props.team.squadMarketValue}</p>
                        }
                        <button className="team-item__button" onClick={this.handleButtonClick}>
                            {this.isThisTeamFavorite() ? "Remove" : "Add"} team to favorites
                        </button>
                    </div>
                </div>
            </Item>
        );
    }
}

TeamItem.propTypes = {
    team: PropTypes.shape({
        id: PropTypes.number.isRequired,
        crestUrl: PropTypes.string,
        name: PropTypes.string.isRequired,
        shortName: PropTypes.string.isRequired,
        squadMarketValue: PropTypes.string,
    }),
    favoriteTeams: PropTypes.arrayOf(PropTypes.number).isRequired,
    removeTeamFromFavorites: PropTypes.func.isRequired,
    addTeamToFavorites: PropTypes.func.isRequired,
};

TeamItem.defaultProps = {
    team: PropTypes.shape({
        crestUrl: null,
    }),
};
