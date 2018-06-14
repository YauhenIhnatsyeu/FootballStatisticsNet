import { call, put } from "redux-saga/effects";

import getFixtures from "Services/fixturesService";

import {
    onFixturesFetchSucceeded,
    onFixturesFetchFailed,
} from "ActionCreators";

export default function* fetchFixtures(action) {
    try {
        const { teamId, dates } = action.payload;
        const fixtures = yield call(getFixtures, teamId, dates);
        yield put(onFixturesFetchSucceeded(fixtures));
    } catch (error) {
        yield put(onFixturesFetchFailed(error));
    }
}
