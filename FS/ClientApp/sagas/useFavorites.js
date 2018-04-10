import { call, put } from "redux-saga/effects";

import { onGetTeamsFromFavoritesSucceeded } from "ActionCreators";
import {
    addToFavorites,
    removeFromFavorites,
    getFromFavorites,
} from "Services/favoriteTeamsService";

export function* getTeamsFromFavorites() {
    try {
        const teams = yield call(getFromFavorites);
        yield put(onGetTeamsFromFavoritesSucceeded(teams));
    } catch (error) {
        // TODO
        throw new Error();
    }
}

export function* addTeamToFavorites(action) {
    try {
        const team = action.payload;
        yield call(addToFavorites, team);
        yield call(getTeamsFromFavorites);
    } catch (error) {
        // TODO
        throw new Error();
    }
}

export function* removeTeamFromFavorites(action) {
    try {
        const team = action.payload;
        yield call(removeFromFavorites, team);
        yield call(getTeamsFromFavorites);
    } catch (error) {
        // TODO
        throw new Error();
    }
}
