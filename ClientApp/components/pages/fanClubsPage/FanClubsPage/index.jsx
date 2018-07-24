import React, { Component } from "react";

import PropTypes from "prop-types";

import Spinner from "Components/spinners/Spinner";
import Error from "Components/messages/Error";

import FanClubItem from "../FanClubItem";

export default class FanClubsPage extends Component {
    componentDidMount() {
        if (this.props.fetchFanClubs) {
            this.props.fetchFanClubs();
        }
    }

    render() {
        if (this.props.fanClubsFetchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.fanClubs) {
            return <Spinner />;
        }

        return (
            <div className="fan-club-list">
                {this.props.fanClubs.map((fanClub, index) => (
                    <FanClubItem fanClub={fanClub} key={index} />
                ))}
            </div>
        );
    }
}

FanClubsPage.propTypes = {
    fanClubs: PropTypes.arrayOf(PropTypes.object),
    fetchFanClubs: PropTypes.func,
    fanClubsFetchingErrorOccured: PropTypes.bool,
};

FanClubsPage.defaultProps = {
    fanClubs: null,
    fetchFanClubs: null,
    fanClubsFetchingErrorOccured: false,
};
