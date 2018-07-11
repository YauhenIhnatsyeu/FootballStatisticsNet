import { getFavoriteTeams, addFavoriteTeam, removeFavoriteTeam } from "Clients/favoriteTeamsClient";

import { fetchFunction } from "Services/fetchService";

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
    return fetchFunction(addFavoriteTeam, team.id);
}

export async function removeFromFavorites(team) {
    if (!team || !team.id) return false;
    return fetchFunction(removeFavoriteTeam, team.id);
}
