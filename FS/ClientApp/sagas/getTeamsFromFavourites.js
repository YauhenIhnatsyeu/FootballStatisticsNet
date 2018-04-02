import { call, put } from "redux-saga/effects";

import { onGetTeamsFromFavouritesSucceeded } from "ActionCreators";

const getTeamsFromLocalStorage = () => {
    const favourites = localStorage.getItem("favourites");
    if (favourites) { return JSON.parse(favourites); }

    return [];
};

export default function* getTeamsFromFavourites() {
    try {
        const teams = yield call(getTeamsFromLocalStorage);
        yield put(onGetTeamsFromFavouritesSucceeded(teams));
    } catch (error) {
        // TODO
        throw new Error();
    }
}
