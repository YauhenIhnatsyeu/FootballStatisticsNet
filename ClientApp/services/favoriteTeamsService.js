import {
    getFavoriteTeams,
    addFavoriteTeam,
    removeFavoriteTeam,
} from "Clients/favoriteTeamsClient";

export async function getFromFavorites() {
    const json = await getFavoriteTeams();
    return json.teamIds;
}

export async function addToFavorites(team) {
    await addFavoriteTeam(team.id);
}

export async function removeFromFavorites(team) {
    await removeFavoriteTeam(team.id);
}
