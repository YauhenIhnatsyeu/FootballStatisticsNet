import { call, put } from "redux-saga/effects";

import { createLeagueUrl } from "Utilities/fetchingUrlsCreators";

import fetchUrl from "Utilities/fetchFootballData";

import {
    onLeagueFetchSucceeded,
    onFetchFailed,
} from "ActionCreators";

export default function* fetchLeague(action) {
    try {
        const leagueUrl = createLeagueUrl(action.payload);
        const data = yield call(fetchUrl, leagueUrl);
        yield put(onLeagueFetchSucceeded(data));
    } catch (error) {
        yield put(onFetchFailed(error));
    }
}
