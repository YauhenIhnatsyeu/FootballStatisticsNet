import actionTypes from "ActionTypes";

export function register(user) {
    return {
        type: actionTypes.REGISTER_REQUESTED,
        payload: user,
    };
}

export function onRegisterSucceeded(user) {
    return {
        type: actionTypes.REGISTER_SUCCEEDED,
        payload: user,
    };
}

export function onRegisterFailed(error) {
    return {
        type: actionTypes.REGISTER_FAILED,
        payload: error,
    };
}
