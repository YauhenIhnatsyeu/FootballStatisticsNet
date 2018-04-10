import actionTypes from "ActionTypes";

export function fetchHead2Head(fixtureId) {
    return {
        type: actionTypes.HEAD_2_HEAD_FETCH_REQUESTED,
        payload: fixtureId,
    };
}

export function onHead2HeadFetchSucceeded(data) {
    return {
        type: actionTypes.HEAD_2_HEAD_FETCH_SUCCEEDED,
        payload: data,
    };
}

export function onHead2HeadFetchFailed(error) {
    return {
        type: actionTypes.HEAD_2_HEAD_FETCH_FAILED,
        payload: error,
    };
}
