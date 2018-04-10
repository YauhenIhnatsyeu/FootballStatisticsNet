import { call, put } from "redux-saga/effects";

import getTeams from "Services/teamsService";

import {
    onTeamsFetchSucceeded,
    onTeamsFetchFailed,
} from "ActionCreators";

export default function* fetchTeams(action) {
    try {
        const leagueId = action.payload;
        const teams = yield call(getTeams, leagueId);
        yield put(onTeamsFetchSucceeded(teams));
    } catch (error) {
        yield put(onTeamsFetchFailed(error));
    }
}
