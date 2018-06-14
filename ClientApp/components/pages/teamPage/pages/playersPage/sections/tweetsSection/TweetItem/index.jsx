import React, { Component } from "react";

import PropTypes from "prop-types";

import Item from "Components/Item";

import { fromStringToDateString } from "Utilities/castDate";

import "./index.css";

export default class TweetItem extends Component {
    render() {
        const { tweet } = this.props;

        if (!tweet) {
            return null;
        }

        return (
            <Item>
                <div className="tweet-item">
                    <div className="tweet-item__title-container">
                        <p className="tweet-item__title">@{tweet.name} at {fromStringToDateString(tweet.date)}</p>
                    </div>
                    {tweet.isRetweet
                        && <p>RT @{tweet.retweetName} at {tweet.retweetDate}</p>}
                    <p>{tweet.text}</p>
                </div>
            </Item>
        );
    }
}

TweetItem.propTypes = {
    tweet: PropTypes.shape({
        name: PropTypes.string,
        date: PropTypes.string,
        isRetweet: PropTypes.bool,
        retweetName: PropTypes.string,
        retweetDate: PropTypes.string,
        text: PropTypes.string,
    }),
};

TweetItem.defaultProps = {
    tweet: null,
};
