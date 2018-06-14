import actionTypes from "ActionTypes";

export function addTeamToFavorites(teamId) {
    return {
        type: actionTypes.ADD_TEAM_TO_FAVORITES,
        payload: teamId,
    };
}

export function removeTeamFromFavorites(teamId) {
    return {
        type: actionTypes.REMOVE_TEAM_FROM_FAVORITES,
        payload: teamId,
    };
}

export function getTeamsFromFavorites() {
    return {
        type: actionTypes.GET_TEAMS_FROM_FAVORITES_REQUESTED,
    };
}

export function onGetTeamsFromFavoritesSucceeded(teams) {
    return {
        type: actionTypes.GET_TEAMS_FROM_FAVORITES_SUCCEEDED,
        payload: teams,
    };
}
