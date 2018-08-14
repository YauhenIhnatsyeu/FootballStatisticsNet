import { call, put } from "redux-saga/effects";

import { fetchFixtures as getFixtures } from "Clients/footballApiClient";

import {
    onFixturesFetchSucceeded,
    onFixturesFetchFailed,
} from "ActionCreators";

export default function* fetchFixtures(action) {
    try {
        const { teamId, dates } = action.payload;
        console.log(getFixtures)
        const fixtures = yield call(getFixtures, teamId, dates);
        console.log(fixtures)
        yield put(onFixturesFetchSucceeded(fixtures));
    } catch (error) {
        yield put(onFixturesFetchFailed(error));
    }
}
