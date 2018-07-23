import { call, put } from "redux-saga/effects";

import { create } from "Services/fanClubService";

import notifications from "Constants/notifications";

import {
    notify,
    startLoading,
    finishLoading,
} from "ActionCreators";

export default function* createFanClub(action) {
    yield put(startLoading());

    const fanClub = action.payload;
    const result = yield call(create, fanClub);

    yield put(finishLoading());

    if (!result) {
        yield put(notify(notifications.createFanClubFailed));
    }
}
