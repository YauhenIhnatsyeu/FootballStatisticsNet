import { call, put } from "redux-saga/effects";

import { createTeamUrl } from "Utilities/fetchingUrlsCreators";

import extractIdFromUrl from "Utilities/extractIdFromUrl";

import {
    onTeamFetchSucceeded,
    onFetchFailed,
} from "ActionCreators";

import fetchUrl from "Utilities/fetchFootballData";

const addIdToTeam = (teamParam) => {
    const team = teamParam;
    team.id = extractIdFromUrl(team._links.self.href);
    return team;
};

export default function* fetchTeam(action) {
    try {
        const teamUrl = createTeamUrl(action.payload);
        let team = yield call(fetchUrl, teamUrl);
        team = yield call(addIdToTeam, team);
        yield put(onTeamFetchSucceeded(team));
    } catch (error) {
        yield put(onFetchFailed(error));
    }
}
