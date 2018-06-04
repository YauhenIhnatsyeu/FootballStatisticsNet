import { call } from "redux-saga/effects";

import { register as registerUser } from "Services/userService";
import { push as pushToHistory } from "Helpers/historyHelper";
import routePaths from "Constants/routePaths";

export default function* register(action) {
    try {
        const user = action.payload;

        const result = yield call(registerUser, user);
        console.log(result);
        if (result) {
            pushToHistory(routePaths.login);
        }
    } catch (error) {
        console.log(error);
    }
}
