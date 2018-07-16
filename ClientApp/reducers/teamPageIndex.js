import actionTypes from "ActionTypes";

const initialState = 0;

export default function teams(state = initialState, action) {
    switch (action.type) {
    case actionTypes.TEAM_PAGE_INDEX_UPDATE_REQUESTED:
        return action.payload;

    default:
        return state;
    }
}
