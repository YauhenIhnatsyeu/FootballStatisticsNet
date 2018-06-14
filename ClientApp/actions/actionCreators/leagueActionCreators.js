import actionTypes from "ActionTypes";

export function fetchLeague(leagueId) {
    return {
        type: actionTypes.LEAGUE_FETCH_REQUESTED,
        payload: leagueId,
    };
}

export function onLeagueFetchSucceeded(data) {
    return {
        type: actionTypes.LEAGUE_FETCH_SUCCEEDED,
        payload: data,
    };
}

export function onLeagueFetchFailed(error) {
    return {
        type: actionTypes.LEAGUE_FETCH_FAILED,
        payload: error,
    };
}

export function updateLeagueIndex(index) {
    return {
        type: actionTypes.LEAGUE_INDEX_UPDATE,
        payload: index,
    };
}
