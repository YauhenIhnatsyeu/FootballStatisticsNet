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
        yield teams && put(onGetTeamsFromFavoritesSucceeded(teams));
    } catch (error) {
        // TODO
        console.log(error);
    }
}

export function* addTeamToFavorites(action) {
    try {
        const team = action.payload;
        const result = yield call(addToFavorites, team);
        yield result && call(getTeamsFromFavorites);
    } catch (error) {
        // TODO
        console.log(error);
    }
}

export function* removeTeamFromFavorites(action) {
    try {
        const team = action.payload;
        const result = yield call(removeFromFavorites, team);
        yield result && call(getTeamsFromFavorites);
    } catch (error) {
        // TODO
        console.log(error);
    }
}
