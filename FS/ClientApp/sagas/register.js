import { call, put } from "redux-saga/effects";

import { register as registerUser } from "Helpers/userHelper";
import { push as pushToHistory } from "Helpers/historyHelper";
import routePaths from "Constants/routePaths";

export default function* register(action) {
    try {
        const user = action.payload;

        const result = yield call(registerUser, user);
        pushToHistory(routePaths.login);
        console.log("Registered!");
    } catch (error) {
        console.log(error);
    }
}
