import React, { Component } from "react";

import PropTypes from "prop-types";

import Item from "Reusable/items/Item";
import ImageWithInfo from "Reusable/ImageWithInfo";

import unavailableUrl from "Constants/unavailableUrl";

export default class FanClubItem extends Component {
    getInfo = () => {
        const { description, users } = this.props.fanClub;
        return [
            description && `Description: ${description}`,
            users && `Users count: ${users.length}`,
        ];
    }

    handleImageError = (e) => {
        e.target.src = unavailableUrl;
    }

    render() {
        const { fanClub } = this.props;

        return (
            <Item>
                <ImageWithInfo
                    imageUrl={fanClub.avatarUrl}
                    title={fanClub.name}
                    info={this.getInfo()}
                />
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
