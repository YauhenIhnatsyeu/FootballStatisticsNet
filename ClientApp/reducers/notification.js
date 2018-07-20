import actionTypes from "ActionTypes";

import createUniqueId from "Utilities/createUniqueId";

const initialState = null;

export default function notification(state = initialState, action) {
    switch (action.type) {
    case actionTypes.NOTIFICATION_REQUESTED:
        return { ...action.payload, id: createUniqueId() };

    default:
        return state;
    }
}
