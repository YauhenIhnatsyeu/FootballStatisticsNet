import { call, put } from "redux-saga/effects";

import { createPlayersUrl } from "Utilities/fetchingUrlsCreators";

import sorterByJerseyNumber from "Utilities/sorterByJerseyNumber";

import {
    onPlayersFetchSucceeded,
    onFetchFailed,
} from "ActionCreators";

import fetchUrl from "Utilities/fetchFootballData";

export default function* fetchPlayers(action) {
    try {
        const playersUrl = createPlayersUrl(action.payload);
        let data = yield call(fetchUrl, playersUrl);
        data = data.players.sort(sorterByJerseyNumber);
        yield put(onPlayersFetchSucceeded(data));
    } catch (error) {
        yield put(onFetchFailed(error));
    }
}
