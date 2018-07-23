import { call, put } from "redux-saga/effects";

import { login as loginUser } from "Services/userService";
import { push as pushToHistory } from "Helpers/historyHelper";

import routePaths from "Constants/routePaths";
import notifications from "Constants/notifications";

import {
    onLoginSucceeded,
    notify,
    startLoading,
    finishLoading,
} from "ActionCreators";

export default function* login(action) {
    yield put(startLoading());

    let user = action.payload;

    user = yield call(loginUser, user);

    yield put(finishLoading());

    if (user) {
        yield put(onLoginSucceeded(user));
        pushToHistory(routePaths.teams);
    } else {
        yield put(notify(notifications.loginFailed));
    }
}
