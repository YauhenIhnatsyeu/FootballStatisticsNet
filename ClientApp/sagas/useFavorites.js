import { call, put } from "redux-saga/effects";

import { onGetTeamsFromFavoritesSucceeded, notify } from "ActionCreators";
import {
    addToFavorites,
    removeFromFavorites,
    getFromFavorites,
} from "Services/favoriteTeamsService";

import notifications from "Constants/notifications";

export function* getTeamsFromFavorites() {
    try {
        const teams = yield call(getFromFavorites);

        yield put(onGetTeamsFromFavoritesSucceeded(teams));
    } catch (error) {
        yield put(notify(notifications.getFavoriteTeamsFailed));
    }
}

export function* addTeamToFavorites(action) {
    const team = action.payload;

    try {
        yield call(addToFavorites, team);
        yield call(getTeamsFromFavorites);
    } catch (error) {
        yield put(notify(notifications.addTeamToFavoritesFailed));
    }
}

export function* removeTeamFromFavorites(action) {
    const team = action.payload;

    try {
        yield call(removeFromFavorites, team);
        yield call(getTeamsFromFavorites);
    } catch (error) {
        yield put(notify(notifications.removeTeamFromFavoritesFailed));
    }
}
