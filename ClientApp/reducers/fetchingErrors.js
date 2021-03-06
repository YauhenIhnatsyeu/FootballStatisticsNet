import actionTypes from "ActionTypes";

const initialState = {
    leagueFetchingErrorOccured: false,
    teamsFetchingErrorOccured: false,
    teamFetchingErrorOccured: false,
    playersFetchingErrorOccured: false,
    fixturesFetchingErrorOccured: false,
    head2HeadFetchingErrorOccured: false,
    tweetsSearchingErrorOccured: false,
    fanClubsFetchingErrorOccured: false,
};

export default function fetchingErrors(state = initialState, action) {
    switch (action.type) {
    case actionTypes.LEAGUE_FETCH_FAILED:
        return { ...state, leagueFetchingErrorOccured: true };

    case actionTypes.TEAMS_FETCH_FAILED:
        return { ...state, teamsFetchingErrorOccured: true };

    case actionTypes.TEAM_FETCH_FAILED:
        return { ...state, teamFetchingErrorOccured: true };

    case actionTypes.PLAYERS_FETCH_FAILED:
        return { ...state, playersFetchingErrorOccured: true };

    case actionTypes.FIXTURES_FETCH_FAILED:
        return { ...state, fixturesFetchingErrorOccured: true };

    case actionTypes.HEAD2HEAD_FETCH_FAILED:
        return { ...state, head2HeadFetchingErrorOccured: true };

    case actionTypes.TWEETS_SEARCH_FAILED:
        return { ...state, tweetsSearchingErrorOccured: true };

    case actionTypes.FAN_CLUBS_FETCH_FAILED:
        return { ...state, fanClubsFetchingErrorOccured: true };

    default:
        return state;
    }
}
