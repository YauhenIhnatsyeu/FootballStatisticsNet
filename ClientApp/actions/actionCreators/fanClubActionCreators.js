import actionTypes from "ActionTypes";

export function createFanClub(fanClub) {
    return {
        type: actionTypes.FAN_CLUB_CREATE_REQUESTED,
        payload: fanClub,
    };
}

export function fetchFanClubs() {
    return {
        type: actionTypes.FAN_CLUBS_FETCH_REQUESTED,
    };
}

export function onFanClubsFetchSucceeded(fanClubs) {
    return {
        type: actionTypes.FAN_CLUBS_FETCH_SUCCEEDED,
        payload: fanClubs,
    };
}

export function onFanClubsFetchFailed(error) {
    return {
        type: actionTypes.FAN_CLUBS_FETCH_FAILED,
        payload: error,
    };
}
