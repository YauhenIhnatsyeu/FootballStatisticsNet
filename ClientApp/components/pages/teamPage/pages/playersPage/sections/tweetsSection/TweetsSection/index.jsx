import React, { Component } from "react";

import PropTypes from "prop-types";

import { getComponentsUsingArrayOfProps } from "Helpers/reactHelper";

import ItemsList from "Reusable/items/ItemsList";

import Spinner from "Reusable/spinners/Spinner";
import Error from "Reusable/messages/Error";

import MountAnimation from "Components/animations/MountAnimation";

import TweetItem from "../TweetItem";

export default class TweetsSection extends Component {
    componentDidMount() {
        this.props.searchTweets(this.props.query);
    }

    render() {
        if (this.props.tweetsSearchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.tweets) {
            return <Spinner />;
        }

        return (
            <MountAnimation>
                <ItemsList>
                    {getComponentsUsingArrayOfProps(
                        TweetItem,
                        "tweet",
                        this.props.tweets,
                    )}
                </ItemsList>
            </MountAnimation>
        );
    }
}

TweetsSection.propTypes = {
    query: PropTypes.string,
    searchTweets: PropTypes.func.isRequired,
    tweetsSearchingErrorOccured: PropTypes.bool.isRequired,
    tweets: PropTypes.arrayOf(PropTypes.object),
};

TweetsSection.defaultProps = {
    query: "",
    tweets: null,
};
