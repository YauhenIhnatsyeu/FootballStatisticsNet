import actionTypes from "ActionTypes";

import itemsOnOnePageCount from "Constants/itemsOnOnePageCount";

const initialState = {
    fixtures: null,
    fixtureIndex: 0,
    fixturesPageIndex: 0,
};

export default function fixturesData(state = initialState, action) {
    switch (action.type) {
    case actionTypes.FIXTURES_FETCH_REQUESTED:
        return {
            ...state,
            fixtures: null,
            fixtureIndex: initialState.fixtureIndex,
            fixturesPageIndex: initialState.fixturesPageIndex,
        };

    case actionTypes.FIXTURES_FETCH_SUCCEEDED:
        return { ...state, fixtures: action.payload };

    case actionTypes.FIXTURE_INDEX_UPDATE:
        return { ...state, fixtureIndex: action.payload };

    case actionTypes.FIXTURES_PAGE_INDEX_UPDATE:
        return {
            ...state,
            fixtureIndex: action.payload * itemsOnOnePageCount,
            fixturesPageIndex: action.payload,
        };

    default:
        return state;
    }
}
