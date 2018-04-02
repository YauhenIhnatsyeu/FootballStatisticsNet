import actionTypes from "../actions/actionTypes";

const initialState = 0;

export default function fixtureIndex(state = initialState, action) {
    switch (action.type) {
    case actionTypes.FIXTURE_INDEX_UPDATE_REQUESTED:
        return action.payload;

    case actionTypes.TEAM_PAGE_INDICES_RESET_REQUESTED:
        return initialState;

    default:
        return state;
    }
}
