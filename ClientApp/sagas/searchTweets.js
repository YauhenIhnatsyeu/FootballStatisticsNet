import { call, put } from "redux-saga/effects";

import search from "Services/twitterService";

import {
    onTweetsSearchSucceeded,
    onTweetsSearchFailed,
} from "ActionCreators";

export default function* searchTweets(action) {
    const query = action.payload;

    try {
        const tweets = yield call(search, query);

        yield put(onTweetsSearchSucceeded(tweets));
    } catch (error) {
        yield put(onTweetsSearchFailed(error));
    }
}
