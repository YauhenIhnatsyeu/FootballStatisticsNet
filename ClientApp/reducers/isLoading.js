import actionTypes from "ActionTypes";

const initialState = false;

export default function teams(state = initialState, action) {
    switch (action.type) {
    case actionTypes.LOADING_STARTED:
        return true;

    case actionTypes.LOADING_FINISHED:
        return false;

    default:
        return state;
    }
}
