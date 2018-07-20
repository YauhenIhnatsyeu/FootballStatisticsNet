import { call } from "redux-saga/effects";

import { logout as logoutUser } from "Services/userService";
import { push as pushToHistory } from "Helpers/historyHelper";
import routePaths from "Constants/routePaths";

export default function* logout() {
    yield call(logoutUser);

    pushToHistory(routePaths.table);
}
