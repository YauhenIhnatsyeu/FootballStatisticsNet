import { call, put } from "redux-saga/effects";

import { fetchLeague as getLeague } from "Clients/footballApiClient";

import {
    onLeagueFetchSucceeded,
    onLeagueFetchFailed,
} from "ActionCreators";

export default function* fetchLeague(action) {
    try {
        const leagueId = action.payload;
        const league = yield call(getLeague, leagueId);
        yield put(onLeagueFetchSucceeded(league));
    } catch (error) {
        yield put(onLeagueFetchFailed(error));
    }
}
