import { call, put } from "redux-saga/effects";

import {
    onPlayersFetchSucceeded,
    onPlayersFetchFailed,
} from "ActionCreators";

import { fetchPlayers as getPlayers } from "Clients/footballApiClient";

export default function* fetchPlayers(action) {
    try {
        const teamId = action.payload;
        const players = yield call(getPlayers, teamId);
        yield put(onPlayersFetchSucceeded(players));
    } catch (error) {
        yield put(onPlayersFetchFailed(error));
    }
}
