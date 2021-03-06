import actionTypes from "ActionTypes";

const initialState = null;

export default function favoriteTeams(state = initialState, action) {
    switch (action.type) {
    case actionTypes.GET_TEAMS_FROM_FAVORITES_REQUESTED:
        return null;

    case actionTypes.GET_TEAMS_FROM_FAVORITES_SUCCEEDED:
        return action.payload;

    default:
        return state;
    }
}
