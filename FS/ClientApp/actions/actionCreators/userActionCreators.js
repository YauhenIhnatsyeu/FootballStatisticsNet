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

export function login(user) {
    return {
        type: actionTypes.LOGIN_REQUESTED,
        payload: user,
    };
}

export function onLoginSucceeded(user) {
    return {
        type: actionTypes.LOGIN_SUCCEEDED,
        payload: user,
    };
}

export function onLoginFailed(error) {
    return {
        type: actionTypes.LOGIN_FAILED,
        payload: error,
    };
}

export function logout() {
    return {
        type: actionTypes.LOGOUT_REQUESTED,
    };
}
