import React, { Component } from "react";

import PropTypes from "prop-types";

import { getComponentsUsingArrayOfProps } from "Helpers/reactHelper";

import ItemsList from "Reusable/items/ItemsList";

import Spinner from "Reusable/spinners/Spinner";
import Error from "Reusable/messages/Error";

import MountAnimation from "Components/animations/MountAnimation";

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
            <MountAnimation>
                <ItemsList>
                    {getComponentsUsingArrayOfProps(
                        FanClubItem,
                        "fanClub",
                        this.props.fanClubs,
                    )}
                </ItemsList>
            </MountAnimation>
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
