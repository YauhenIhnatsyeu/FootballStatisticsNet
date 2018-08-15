import { call, put } from "redux-saga/effects";

import { fetch as getFanClubs } from "Services/fanClubService";

import {
    onFanClubsFetchSucceeded,
    onFanClubsFetchFailed,
} from "ActionCreators";

export default function* fetchFanClubs() {
    try {
        const fanClubs = yield call(getFanClubs);

        yield put(onFanClubsFetchSucceeded(fanClubs));
    } catch (error) {
        yield put(onFanClubsFetchFailed());
    }
}
