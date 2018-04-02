import actionTypes from "../actions/actionTypes";

const initialState = [];

export default function favouriteTeams(state = initialState, action) {
    switch (action.type) {
    case actionTypes.GET_TEAMS_FROM_FAVOURITES_SUCCEEDED:
        return action.payload;

    default:
        return state;
    }
}
