import { fetchSucceeded, fetchJson } from "Helpers/ajaxHelper";
import getCurrentUrl from "Helpers/currentUrlHelper";
import apiRoutePaths from "Constants/apiRoutePaths";
import keys from "Constants/keys";
import { getValue } from "Helpers/localStorageHelper";

function getBearer() {
    return `Bearer ${getValue(keys.token)}`;
}

export function getFavoriteTeams() {
    return fetchJson(
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
    return fetchSucceeded(
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

export async function removeFavoriteTeam(teamId) {
    return fetchSucceeded(
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
