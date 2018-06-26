import { fetchUrl } from "Helpers/ajaxHelper";
import getCurrentUrl from "Helpers/currentUrlHelper";
import apiRoutePaths from "Constants/apiRoutePaths";
import keys from "Constants/keys";
import { getValue } from "Helpers/localStorageHelper";

function getBearer() {
    return `Bearer ${getValue(keys.token)}`;
}

export function getFavoriteTeams() {
    return fetchUrl(
        getCurrentUrl() + apiRoutePaths.getFavoriteTeams,
        {
            method: "GET",
            headers: {
                Authorization: getBearer(),
            },
        },
    );
}

export function addFavoriteTeam(teamId) {
    return fetchUrl(
        getCurrentUrl() + apiRoutePaths.addFavoriteTeam,
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

export function removeFavoriteTeam(teamId) {
    return fetchUrl(
        getCurrentUrl() + apiRoutePaths.removeFavoriteTeam,
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
