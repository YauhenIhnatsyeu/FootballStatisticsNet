import actionTypes from "ActionTypes";

const initialState = null;

export default function dates(state = initialState, action) {
    switch (action.type) {
    case actionTypes.TWEETS_SEARCH_REQUESTED:
        return null;

    case actionTypes.TWEETS_SEARCH_SUCCEEDED:
        return action.payload;

    default:
        return state;
    }
}
