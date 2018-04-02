import { call, put } from "redux-saga/effects";

import {
    onFixturesFetchSucceeded,
    onFetchFailed,
} from "ActionCreators";

import extractIdFromUrl from "Utilities/extractIdFromUrl";

import { createFixturesUrl } from "Utilities/fetchingUrlsCreators";

import fetchUrl from "Utilities/fetchFootballData";

const addIdToEachFixture = fixtures =>
    fixtures.map((fixtureParam) => {
        const fixture = fixtureParam;
        const fixtureId = extractIdFromUrl(fixture._links.self.href);
        fixture.id = fixtureId;
        return fixture;
    });

export default function* fetchFixtures(action) {
    try {
        const fixturesUrl = createFixturesUrl(action.payload);
        const data = yield call(fetchUrl, fixturesUrl);
        const { fixtures } = data;
        yield call(addIdToEachFixture, fixtures);
        yield put(onFixturesFetchSucceeded(fixtures));
    } catch (error) {
        yield put(onFetchFailed(error));
    }
}
