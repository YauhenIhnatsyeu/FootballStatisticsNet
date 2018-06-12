import actionTypes from "ActionTypes";

import itemsOnOnePageCount from "Constants/itemsOnOnePageCount";

const initialState = {
    fixtures: null,
    currentFixtureId: 0,
    fixturesPageIndex: 0,
};

export default function fixturesData(state = initialState, action) {
    switch (action.type) {
    case actionTypes.FIXTURES_FETCH_REQUESTED:
        return {
            ...state,
            fixtures: initialState.fixtures,
            fixturesPageIndex: initialState.fixturesPageIndex,
        };

    case actionTypes.FIXTURES_FETCH_SUCCEEDED: {
        const currentFixtureId = action.payload.length > 0
            ? action.payload[0].id
            : initialState.currentFixtureId;

        return {
            ...state,
            fixtures: action.payload,
            currentFixtureId,
        };
    }

    case actionTypes.CURRENT_FIXTURE_ID_UPDATE:
        return { ...state, currentFixtureId: action.payload };

    case actionTypes.FIXTURES_PAGE_INDEX_UPDATE: {
        const currentFixtureId = state.fixtures.length >= action.payload * itemsOnOnePageCount
            ? state.fixtures[action.payload * itemsOnOnePageCount].id
            : initialState.currentFixtureId;

        return {
            ...state,
            currentFixtureId,
            fixturesPageIndex: action.payload,
        };
    }

    default:
        return state;
    }
}
