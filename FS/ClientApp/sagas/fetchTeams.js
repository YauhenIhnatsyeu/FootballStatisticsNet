import { call, put } from "redux-saga/effects";

import { createTeamsUrl } from "Utilities/fetchingUrlsCreators";

import extractIdFromUrl from "Utilities/extractIdFromUrl";

import {
    onTeamsFetchSucceeded,
    onFetchFailed,
} from "ActionCreators";

import fetchUrl from "Utilities/fetchFootballData";

const addIdToEachTeam = teams =>
    teams.map((teamParam) => {
        const team = teamParam;
        const teamId = extractIdFromUrl(team._links.self.href);
        team.id = teamId;
        return team;
    });

export default function* fetchTeams(action) {
    try {
        const teamsUrl = createTeamsUrl(action.payload);
        const data = yield call(fetchUrl, teamsUrl);
        const { teams } = data;
        yield call(addIdToEachTeam, teams);
        yield put(onTeamsFetchSucceeded(teams));
    } catch (error) {
        yield put(onFetchFailed(error));
    }
}
