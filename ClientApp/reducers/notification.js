import actionTypes from "ActionTypes";

const initialState = null;

export default function notification(state = initialState, action) {
    switch (action.type) {
    case actionTypes.NOTIFICATION_REQUESTED:
        return action.payload;

    default:
        return state;
    }
}
