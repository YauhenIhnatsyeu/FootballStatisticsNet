import { call, put } from "redux-saga/effects";

import { fetchFixtures as getFixtures } from "Clients/footballApiClient";

import {
    onFixturesFetchSucceeded,
    onFixturesFetchFailed,
} from "ActionCreators";

export default function* fetchFixtures(action) {
    const { teamId, dates } = action.payload;

    try {
        const fixtures = yield call(getFixtures, teamId, dates);
        yield put(onFixturesFetchSucceeded(fixtures));
    } catch (error) {
        yield put(onFixturesFetchFailed(error));
    }
}
