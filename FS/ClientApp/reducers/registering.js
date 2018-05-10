import actionTypes from "ActionTypes";

const initialState = false;

export default function registering(state = initialState, action) {
    switch (action.type) {
    case actionTypes.REGISTER_REQUESTED:
        return true;

    case actionTypes.REGISTER_SUCCEEDED:
        return false;

    case actionTypes.REGISTER_FAILED:
        return false;

    default:
        return state;
    }
}
