import { call, put } from "redux-saga/effects";

import search from "Services/twitterService";

import {
    onTweetsSearchSucceeded,
    onTweetsSearchFailed,
} from "ActionCreators";

export default function* searchTweets(action) {
    try {
        const query = action.payload;

        const tweets = yield call(search, query);

        if (tweets) {
            yield put(onTweetsSearchSucceeded(tweets));
        }
    } catch (error) {
        yield put(onTweetsSearchFailed(error));
    }
}
