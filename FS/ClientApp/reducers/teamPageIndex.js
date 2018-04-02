import actionTypes from "../actions/actionTypes";

const initialState = 0;

export default function teamPageIndex(state = initialState, action) {
    switch (action.type) {
    case actionTypes.TEAM_PAGE_INDEX_UPDATE_REQUESTED:
        return action.payload;

    default:
        return state;
    }
}
