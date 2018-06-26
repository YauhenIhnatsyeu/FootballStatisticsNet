import { getFavoriteTeams, addFavoriteTeam, removeFavoriteTeam } from "Clients/favoriteTeamsClient";

import tryExtractJsonFromResponse from "Helpers/jsonHelper";

export async function getFromFavorites() {
    const response = await getFavoriteTeams();

    if (response.ok) {
        const json = await tryExtractJsonFromResponse(response);

        return json && json.teamIds;
    }

    return null;
}

export async function addToFavorites(team) {
    if (!team || !team.id) return false;

    const response = await addFavoriteTeam(team.id);

    return response.ok;
}

export async function removeFromFavorites(team) {
    if (!team || !team.id) return false;

    const response = await removeFavoriteTeam(team.id);

    return response.ok;
}
