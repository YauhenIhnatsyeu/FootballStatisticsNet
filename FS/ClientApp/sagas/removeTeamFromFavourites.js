import { call } from "redux-saga/effects";

const removeTeamFromLocalStorage = (teamId) => {
    let favourites = localStorage.getItem("favourites");

    if (favourites) {
        favourites = JSON.parse(favourites);
        const indexOfTeamId = favourites.indexOf(teamId);

        if (indexOfTeamId !== -1) {
            favourites.splice(indexOfTeamId, 1);
            favourites = JSON.stringify(favourites);
            localStorage.setItem("favourites", favourites);
        }
    }
};

export default function* removeTeamFromFavourites(action) {
    try {
        yield call(removeTeamFromLocalStorage, action.payload);
    } catch (error) {
        // TODO
        throw new Error();
    }
}
