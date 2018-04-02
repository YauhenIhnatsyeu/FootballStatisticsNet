import { call } from "redux-saga/effects";

const addTeamToLocalStorage = (teamId) => {
    let favourites = localStorage.getItem("favourites");

    if (favourites) {
        favourites = JSON.parse(favourites);
        favourites.push(teamId);
        favourites = JSON.stringify(favourites);
    } else {
        favourites = JSON.stringify([teamId]);
    }

    localStorage.setItem("favourites", favourites);
};

export default function* addTeamToFavourites(action) {
    try {
        yield call(addTeamToLocalStorage, action.payload);
    } catch (error) {
        // TODO
        throw new Error();
    }
}
