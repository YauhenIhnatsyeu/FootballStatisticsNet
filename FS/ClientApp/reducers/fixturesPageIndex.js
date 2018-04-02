import actionTypes from "../actions/actionTypes";

const initialState = 0;

export default function fixturesPageIndex(state = initialState, action) {
    switch (action.type) {
    case actionTypes.FIXTURES_PAGE_INDEX_UPDATE_REQUESTED:
        return action.payload;

    case actionTypes.TEAM_PAGE_INDICES_RESET_REQUESTED:
        return initialState;

    default:
        return state;
    }
}
