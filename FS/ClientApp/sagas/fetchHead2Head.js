import { call, put } from "redux-saga/effects";

import {
    onHead2HeadFetchSucceeded,
    onFetchFailed,
} from "ActionCreators";

import extractIdFromUrl from "Utilities/extractIdFromUrl";

import { createHead2HeadUrl } from "Utilities/fetchingUrlsCreators";

import fetchUrl from "Utilities/fetchFootballData";

const addIdToEachFixture = fixtures =>
    fixtures.map((fixtureParam) => {
        const fixture = fixtureParam;
        const fixtureId = extractIdFromUrl(fixture._links.self.href);
        fixture.id = fixtureId;
        return fixture;
    });

export default function* fetchHead2Head(action) {
    try {
        const head2HeadUrl = createHead2HeadUrl(action.payload);
        const data = yield call(fetchUrl, head2HeadUrl);
        const { head2head } = data;
        const { fixtures } = head2head;
        yield call(addIdToEachFixture, fixtures);
        head2head.fixtures = fixtures;
        data.head2head = head2head;

        yield put(onHead2HeadFetchSucceeded(data));
    } catch (error) {
        yield put(onFetchFailed(error));
    }
}
