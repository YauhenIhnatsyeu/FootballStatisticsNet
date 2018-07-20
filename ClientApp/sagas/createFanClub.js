import { call, put } from "redux-saga/effects";

import { create } from "Services/fanClubService";

import notifications from "Constants/notifications";

import { notify } from "ActionCreators";

export default function* createFanClub(action) {
    const fanClub = action.payload;
    const result = yield call(create, fanClub);

    if (!result) {
        yield put(notify(notifications.createFanClubFailed));
    }
}
