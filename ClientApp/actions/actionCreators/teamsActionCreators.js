import actionTypes from "ActionTypes";

export function fetchTeams(leagueId) {
    return {
        type: actionTypes.TEAMS_FETCH_REQUESTED,
        payload: leagueId,
    };
}

export function onTeamsFetchSucceeded(data) {
    return {
        type: actionTypes.TEAMS_FETCH_SUCCEEDED,
        payload: data,
    };
}

export function onTeamsFetchFailed(error) {
    return {
        type: actionTypes.TEAMS_FETCH_FAILED,
        payload: error,
    };
}
