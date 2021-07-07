import { call, put } from "redux-saga/effects";

import { fetchTeam as getTeam } from "Clients/footballApiClient";

import {
    onTeamFetchSucceeded,
    onTeamFetchFailed,
} from "ActionCreators";

export default function* fetchTeam(action) {
    try {
        const teamId = action.payload;
        const team = yield call(getTeam, teamId);
        yield put(onTeamFetchSucceeded(team));
    } catch (error) {
        yield put(onTeamFetchFailed(error));
    }
}
