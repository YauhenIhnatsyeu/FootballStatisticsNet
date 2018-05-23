import { call, put } from "redux-saga/effects";

import { login as loginUser } from "Helpers/userHelper";

import { onLoginSucceeded } from "ActionCreators";

export default function* login(action) {
    try {
        let user = action.payload;

        user = yield call(loginUser, user);

        if (user) {
            yield put(onLoginSucceeded(user));
            console.log("Login!");
        } else {
            console.log("No login!");
        }
    } catch (error) {
        console.log(error);
    }
}
