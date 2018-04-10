import { call, put } from "redux-saga/effects";

import {
    onPlayersFetchSucceeded,
    onPlayersFetchFailed,
} from "ActionCreators";

import getPlayers from "Services/playersService";

export default function* fetchPlayers(action) {
    try {
        const playersUrl = action.payload;
        const players = yield call(getPlayers, playersUrl);
        yield put(onPlayersFetchSucceeded(players));
    } catch (error) {
        yield put(onPlayersFetchFailed(error));
    }
}
