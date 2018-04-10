import actionTypes from "ActionTypes";

const initialState = {
    players: null,
    playersPageIndex: 0,
};

export default function playersData(state = initialState, action) {
    switch (action.type) {
    case actionTypes.PLAYERS_FETCH_SUCCEEDED:
        return { ...state, players: action.payload };

    case actionTypes.PLAYERS_PAGE_INDEX_UPDATE:
        return { ...state, playersPageIndex: action.payload };

    case actionTypes.PLAYERS_FETCH_REQUESTED:
        return { ...state, playersPageIndex: initialState.playersPageIndex };

    default:
        return state;
    }
}
