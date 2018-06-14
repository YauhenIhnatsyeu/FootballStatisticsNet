import { getFavoriteTeams, addFavoriteTeam, removeFavoriteTeam } from "Clients/favoriteTeamsClient";

import tryExtractJsonFromResponse from "Helpers/jsonHelper";

export function* getFromFavorites() {
    const response = yield getFavoriteTeams();

    if (response.ok) {
        const json = yield tryExtractJsonFromResponse(response);

        return json && json.teamIds;
    }

    return null;
}

export function* addToFavorites(team) {
    if (!team || !team.id) return false;

    const response = yield addFavoriteTeam(team.id);

    return response.ok;
}

export function* removeFromFavorites(team) {
    if (!team || !team.id) return false;

    const response = yield removeFavoriteTeam(team.id);

    return response.ok;
}
