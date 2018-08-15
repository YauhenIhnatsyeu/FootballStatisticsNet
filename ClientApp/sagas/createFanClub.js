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

    try {
        yield call(create, fanClub);
    } catch (error) {
        yield put(notify(notifications.createFanClubFailed));
    }

    yield put(finishLoading());
}
