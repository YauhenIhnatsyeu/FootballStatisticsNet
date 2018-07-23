import actionTypes from "ActionTypes";

export function startLoading() {
    return {
        type: actionTypes.LOADING_STARTED,
    };
}

export function finishLoading() {
    return {
        type: actionTypes.LOADING_FINISHED,
    };
}
