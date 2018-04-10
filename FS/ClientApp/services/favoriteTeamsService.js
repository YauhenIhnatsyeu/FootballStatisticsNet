import { getJSONValue, pushValue, popValue } from "Helpers/localStorageHelper";

export function getFromFavorites() {
    return getJSONValue("favorites") || [];
}

export function addToFavorites(team) {
    if (team.id) {
        pushValue("favorites", team.id);
    }
}

export function removeFromFavorites(team) {
    if (team.id) {
        popValue("favorites", team.id);
    }
}
