import actionTypes from "ActionTypes";

import { getValue, getJSONValue } from "Helpers/localStorageHelper";
import keys from "Constants/keys";

const user = getJSONValue(keys.user);
const token = getValue(keys.token);
const initialState = (user && token) ? user : null;

export default function teams(state = initialState, action) {
    switch (action.type) {
    case actionTypes.LOGIN_SUCCEEDED:
        return { ...action.payload };

    case actionTypes.LOGOUT_REQUESTED:
        return null;

    default:
        return state;
    }
}
