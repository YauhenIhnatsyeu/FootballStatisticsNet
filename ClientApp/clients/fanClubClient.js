import { fetchUrl, fetchJson } from "Helpers/ajaxHelper";
import getCurrentUrl from "Helpers/currentUrlHelper";
import apiRoutePaths from "Constants/apiRoutePaths";
import keys from "Constants/keys";
import { getValue } from "Helpers/localStorageHelper";

function getBearer() {
    return `Bearer ${getValue(keys.token)}`;
}

function getCreateRequestOptions(fanClub, avatarId) {
    return {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            Authorization: getBearer(),
        },
        body: JSON.stringify(Object.assign({}, fanClub, { avatarId })),
    };
}

export function create(fanClub, avatarId) {
    return fetchUrl(
        getCurrentUrl() + apiRoutePaths.createFanClub,
        getCreateRequestOptions(fanClub, avatarId),
    );
}

export function fetch() {
    return fetchJson(getCurrentUrl() + apiRoutePaths.fetchFanClubs);
}
