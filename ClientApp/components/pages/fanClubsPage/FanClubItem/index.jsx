import React, { Component } from "react";

import PropTypes from "prop-types";

import Item from "Components/Item";

import unavailableUrl from "Constants/unavailableUrl";

import "./index.css";

export default class FanClubItem extends Component {
    handleImageError = (e) => {
        e.target.src = unavailableUrl;
    }

    render() {
        const { fanClub } = this.props;

        return (
            <Item>
                <div className="fan-club-item">
                    <div className="fan-club-item__img-container">
                        <img
                            className="fan-club-item__img"
                            src={fanClub.avatarUrl}
                            alt=""
                            onError={this.handleImageError}
                        />
                    </div>
                    <div className="fan-club-item__info-container">
                        <p className="fan-club-item__name">{fanClub.name}</p>
                        <p>Description: {fanClub.description}</p>
                        {fanClub.users && <p>Users count: {fanClub.users.length}</p>}
                    </div>
                </div>
            </Item>
        );
    }
}

FanClubItem.propTypes = {
    fanClub: PropTypes.shape({
        avatarUrl: PropTypes.string,
        name: PropTypes.string,
        description: PropTypes.string,
        users: PropTypes.arrayOf(PropTypes.object),
    }),
};

FanClubItem.defaultProps = {
    fanClub: {},
};
