import { getFavoriteTeams, addFavoriteTeam, removeFavoriteTeam } from "Clients/favoriteTeamsClient";

export function* getFromFavorites() {
    console.log(yield getFavoriteTeams())
        // .then(response => response.json())
        // .then(json => json && json.teamIds)
        // .catch(() => null);
}

export function* addToFavorites(team) {
    if (!team || !team.id) return false;

    return yield addFavoriteTeam(team.id)
        .then(() => true)
        .catch(() => false);
}

export function* removeFromFavorites(team) {
    if (!team || !team.id) return false;

    return yield removeFavoriteTeam(team.id)
        .then(() => true)
        .catch(() => false);
}
