import { call } from "redux-saga/effects";

import { logout as logoutUser } from "Helpers/userHelper";
import { push as pushToHistory } from "Helpers/historyHelper";
import routePaths from "Constants/routePaths";

export default function* logout() {
    try {
        yield call(logoutUser);

        pushToHistory(routePaths.table);
    } catch (error) {
        console.log(error);
    }
}
