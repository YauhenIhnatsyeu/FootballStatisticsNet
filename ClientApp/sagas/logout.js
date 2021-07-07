import { call, put } from "redux-saga/effects";

import { logout as logoutUser } from "Services/userService";
import { push as pushToHistory } from "Helpers/historyHelper";
import routePaths from "Constants/routePaths";

import { startLoading, finishLoading } from "ActionCreators";

export default function* logout() {
    yield put(startLoading());

    try {
        yield call(logoutUser);
    } catch (error) {
        // TODO
    }

    yield put(finishLoading());

    pushToHistory(routePaths.table);
}
