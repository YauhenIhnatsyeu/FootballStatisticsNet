import actionTypes from "ActionTypes";

export function createFanClub(fanClub) {
    return {
        type: actionTypes.FAN_CLUB_CREATE_REQUESTED,
        payload: fanClub,
    };
}
