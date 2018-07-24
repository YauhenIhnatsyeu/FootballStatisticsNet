import actionTypes from "ActionTypes";

const initialState = null;

export default function fanClubs(state = initialState, action) {
    switch (action.type) {
    case actionTypes.FAN_CLUBS_FETCH_REQUESTED:
        return null;

    case actionTypes.FAN_CLUBS_FETCH_SUCCEEDED:
        return action.payload;

    default:
        return state;
    }
}
