import { call, put } from "redux-saga/effects";

import { fetch as getFanClubs } from "Services/fanClubService";

import {
    onFanClubsFetchSucceeded,
    onFanClubsFetchFailed,
} from "ActionCreators";

export default function* fetchFanClubs() {
    const fanClubs = yield call(getFanClubs);
    if (fanClubs) {
        yield put(onFanClubsFetchSucceeded(fanClubs));
    } else {
        yield put(onFanClubsFetchFailed());
    }
}
