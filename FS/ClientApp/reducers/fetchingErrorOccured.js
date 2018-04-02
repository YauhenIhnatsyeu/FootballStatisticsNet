import actionTypes from "../actions/actionTypes";

const initialState = false;

export default function fetchingErrorOccured(state = initialState, action) {
    switch (action.type) {
    case actionTypes.FETCH_FAILED:
        return true;

    default:
        return state;
    }
}
