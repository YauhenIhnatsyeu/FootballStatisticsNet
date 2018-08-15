import { call, put, all } from "redux-saga/effects";

import { fetchTeams as getTeams } from "Clients/footballApiClient";

import {
    onTeamsFetchSucceeded,
    onTeamsFetchFailed,
} from "ActionCreators";

export default function* fetchTeams(action) {
    const leaguesIds = action.payload;

    try {
        const arraysOfTeams =
            yield all(leaguesIds.map(leagueId => call(getTeams, leagueId)));
        const teams = [].concat(...arraysOfTeams);

        yield put(onTeamsFetchSucceeded(teams));
    } catch (error) {
        yield put(onTeamsFetchFailed(error));
    }
}
