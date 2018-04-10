import actionTypes from "ActionTypes";

export default function updateDates(dates) {
    return {
        type: actionTypes.DATES_UPDATE,
        payload: dates,
    };
}
