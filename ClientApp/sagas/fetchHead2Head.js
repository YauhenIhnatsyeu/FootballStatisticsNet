import { call, put } from "redux-saga/effects";

import { fetchHead2Head as getHead2Head } from "Clients/footballApiClient";

import {
    onHead2HeadFetchSucceeded,
    onHead2HeadFetchFailed,
} from "ActionCreators";

export default function* fetchHead2Head(action) {
    const fixtureId = action.payload;

    try {
        const head2Head = yield call(getHead2Head, fixtureId);
        yield put(onHead2HeadFetchSucceeded(head2Head));
    } catch (error) {
        yield put(onHead2HeadFetchFailed(error));
    }
}
