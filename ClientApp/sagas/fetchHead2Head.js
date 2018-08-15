import { call, put } from "redux-saga/effects";

import getHead2Head from "Services/head2HeadService";

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
