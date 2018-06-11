import actionTypes from "ActionTypes";

export function searchTweets(query) {
    return {
        type: actionTypes.TWEETS_SEARCH_REQUESTED,
        payload: query,
    };
}

export function onTweetsSearchSucceeded(tweets) {
    return {
        type: actionTypes.TWEETS_SEARCH_SUCCEEDED,
        payload: tweets,
    };
}

export function onTweetsSearchFailed(error) {
    return {
        type: actionTypes.TWEETS_SEARCH_FAILED,
        payload: error,
    };
}
