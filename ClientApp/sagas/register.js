import { call, put } from "redux-saga/effects";

import { register as registerUser } from "Services/userService";
import { push as pushToHistory } from "Helpers/historyHelper";

import routePaths from "Constants/routePaths";
import notifications from "Constants/notifications";

import {
    notify,
    startLoading,
    finishLoading,
} from "ActionCreators";

export default function* register(action) {
    yield put(startLoading());

    const user = action.payload;
    const result = yield call(registerUser, user);

    yield put(finishLoading());

    if (result) {
        pushToHistory(routePaths.login);
        yield put(notify(notifications.registerSucceeded));
    } else {
        yield put(notify(notifications.registerFailed));
    }
}
