import actionTypes from "ActionTypes";

const initialState = null;

export default function teams(state = initialState, action) {
    switch (action.type) {
    case actionTypes.TEAMS_FETCH_SUCCEEDED:
        return action.payload;

    default:
        return state;
    }
}
