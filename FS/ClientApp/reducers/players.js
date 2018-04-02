import actionTypes from "../actions/actionTypes";

const initialState = null;

export default function tabs(state = initialState, action) {
    switch (action.type) {
    case actionTypes.PLAYERS_FETCH_SUCCEEDED:
        return action.payload;

    default:
        return state;
    }
}
