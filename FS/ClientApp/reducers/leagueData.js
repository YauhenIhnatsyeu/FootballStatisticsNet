import actionTypes from "ActionTypes";

const initialState = {
    league: null,
    leagueIndex: 0,
};

export default function leagueData(state = initialState, action) {
    switch (action.type) {
    case actionTypes.LEAGUE_FETCH_SUCCEEDED:
        return { ...state, league: action.payload };

    case actionTypes.LEAGUE_INDEX_UPDATE:
        return { ...state, leagueIndex: action.payload };

    default:
        return state;
    }
}
