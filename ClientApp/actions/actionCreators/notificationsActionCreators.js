import actionTypes from "ActionTypes";

export function notify(notification) {
    return {
        type: actionTypes.NOTIFICATION_REQUESTED,
        payload: notification,
    };
}
