import { call, put } from "redux-saga/effects";

import { onGetTeamsFromFavoritesSucceeded, notify } from "ActionCreators";
import {
    addToFavorites,
    removeFromFavorites,
    getFromFavorites,
} from "Services/favoriteTeamsService";

import notifications from "Constants/notifications";

export function* getTeamsFromFavorites() {
    const teams = yield call(getFromFavorites);

    if (teams) {
        yield put(onGetTeamsFromFavoritesSucceeded(teams));
    } else {
        yield put(notify(notifications.getFavoriteTeamsFailed));
    }
}

export function* addTeamToFavorites(action) {
    const team = action.payload;
    const result = yield call(addToFavorites, team);

    if (result) {
        yield call(getTeamsFromFavorites);
    } else {
        yield put(notify(notifications.addTeamToFavoritesFailed));
    }
}

export function* removeTeamFromFavorites(action) {
    const team = action.payload;
    const result = yield call(removeFromFavorites, team);

    if (result) {
        yield call(getTeamsFromFavorites);
    } else {
        yield put(notify(notifications.removeTeamFromFavoritesFailed));
    }
}
