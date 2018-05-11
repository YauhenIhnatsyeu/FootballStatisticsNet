import { call, put } from "redux-saga/effects";

import registerUser from "Helpers/registerHelper";
//MOVE TO HELPERS
import createHistory from "history/createBrowserHistory";

import {
} from "ActionCreators";

export default function* register(action) {
    try {
        const user = action.payload;

        registerUser(user);
    } catch (error) {
        console.log(error);
        //yield put(onFixturesFetchFailed(error));
    }
}
