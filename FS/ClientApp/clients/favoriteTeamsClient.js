import { fetchUrl } from "Helpers/ajaxHelper";
import getCurrentUrl from "Helpers/currentUrlHelper";
import routePaths from "Constants/routePaths";
import keys from "Constants/keys";
import { getValue } from "Helpers/localStorageHelper";

function getBearer() {
    return `Bearer ${getValue(keys.token)}`;
}

export function* getFavoriteTeams() {
    return yield fetchUrl(
        getCurrentUrl() + routePaths.getFavoriteTeams,
        {
            method: "GET",
            headers: {
                Authorization: getBearer(),
            },
        },
    );
}

export function* addFavoriteTeam(teamId) {
    return yield fetchUrl(
        getCurrentUrl() + routePaths.addFavoriteTeam,
        {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Authorization: getBearer(),
            },
            body: JSON.stringify({ teamId }),
        },
    );
}

export function* removeFavoriteTeam(teamId) {
    return yield fetchUrl(
        getCurrentUrl() + routePaths.removeFavoriteTeam,
        {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json",
                Authorization: getBearer(),
            },
            body: JSON.stringify({ teamId }),
        },
    );
}
