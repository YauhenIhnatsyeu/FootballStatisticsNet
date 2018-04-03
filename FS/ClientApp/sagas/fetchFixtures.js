import { call, put } from "redux-saga/effects";

import {
    onFixturesFetchSucceeded,
    onFetchFailed,
} from "ActionCreators";

import extractIdFromUrl from "Utilities/extractIdFromUrl";

import { createFixturesUrl } from "Utilities/fetchingUrlsCreators";

import fetchUrl from "Utilities/fetchFootballData";

const filterFixturesByDate = (fixtures, dates) =>
    fixtures.filter((f) => {
        const fixtureDate = new Date(f.date);
        return fixtureDate >= dates.from && fixtureDate <= dates.to;
    });

const addIdToEachFixture = fixtures =>
    fixtures.map((fixtureParam) => {
        const fixture = fixtureParam;
        const fixtureId = extractIdFromUrl(fixture._links.self.href);
        fixture.id = fixtureId;
        return fixture;
    });

export default function* fetchFixtures(action) {
    try {
        const fixturesUrl = createFixturesUrl(action.payload.teamId);
        const data = yield call(fetchUrl, fixturesUrl);
        let { fixtures } = data;
        fixtures = yield call(filterFixturesByDate, fixtures, action.payload.dates);
        yield call(addIdToEachFixture, fixtures);
        yield put(onFixturesFetchSucceeded(fixtures));
    } catch (error) {
        yield put(onFetchFailed(error));
    }
}
