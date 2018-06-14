import React, { Component } from "react";

import PropTypes from "prop-types";

import ItemsList from "Components/ItemsList";

import Loading from "Components/messages/Loading";
import Error from "Components/messages/Error";

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
            return <Loading />;
        }

        return (
            <ItemsList
                items={this.props.tweets}
                itemComponent={<TweetItem />}
                itemKey="tweet"
            />
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
