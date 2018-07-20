import { call, put } from "redux-saga/effects";

import { register as registerUser } from "Services/userService";
import { push as pushToHistory } from "Helpers/historyHelper";

import routePaths from "Constants/routePaths";
import notifications from "Constants/notifications";

import { notify } from "ActionCreators";

export default function* register(action) {
    const user = action.payload;
    const result = yield call(registerUser, user);

    if (result) {
        pushToHistory(routePaths.login);
    } else {
        yield put(notify(notifications.registerFailed));
    }
}
