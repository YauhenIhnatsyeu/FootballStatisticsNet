import { call, put } from "redux-saga/effects";

//MOVE TO HELPERS
import createHistory from "history/createBrowserHistory";

import {
} from "ActionCreators";

export default function* register(action) {
    try {
        const history = createHistory();
        console.log(history);

        const user = action.payload;

        const requestOptions = {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(user),
        };

        fetch("http://localhost:5000/users/register", requestOptions);
    } catch (error) {
        console.log(error)
        yield put(onFixturesFetchFailed(error));
    }
}
