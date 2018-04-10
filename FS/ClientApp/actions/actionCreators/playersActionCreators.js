import actionTypes from "ActionTypes";

export function fetchPlayers(teamUrl) {
    return {
        type: actionTypes.PLAYERS_FETCH_REQUESTED,
        payload: teamUrl,
    };
}

export function onPlayersFetchSucceeded(data) {
    return {
        type: actionTypes.PLAYERS_FETCH_SUCCEEDED,
        payload: data,
    };
}

export function onPlayersFetchFailed(error) {
    return {
        type: actionTypes.PLAYERS_FETCH_FAILED,
        payload: error,
    };
}
