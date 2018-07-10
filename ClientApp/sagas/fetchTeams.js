import { call, put } from "redux-saga/effects";

import getTeams from "Services/teamsService";

import {
    onTeamsFetchSucceeded,
    onTeamsFetchFailed,
} from "ActionCreators";

export default function* fetchTeams(action) {
    try {
        const leaguesIds = action.payload;
        const teams = yield call(getTeams, leaguesIds);
        yield put(onTeamsFetchSucceeded(teams));
    } catch (error) {
        console.log(error);
        yield put(onTeamsFetchFailed(error));
    }
}
