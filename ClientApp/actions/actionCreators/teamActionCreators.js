import actionTypes from "ActionTypes";

export function fetchTeam(teamId) {
    return {
        type: actionTypes.TEAM_FETCH_REQUESTED,
        payload: teamId,
    };
}

export function onTeamFetchSucceeded(data) {
    return {
        type: actionTypes.TEAM_FETCH_SUCCEEDED,
        payload: data,
    };
}

export function onTeamFetchFailed(error) {
    return {
        type: actionTypes.TEAM_FETCH_FAILED,
        payload: error,
    };
}
