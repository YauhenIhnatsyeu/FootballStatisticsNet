import actionTypes from "ActionTypes";

import millisecondsValues from "Constants/millisecondsValues";

const from = new Date();
const to = new Date(from.getTime() + millisecondsValues.twoWeeks);

const initialState = { from, to };

function validateDate(date) {
    return Number.isNaN(date.getTime()) ? new Date() : date;
}

export default function dates(state = initialState, action) {
    switch (action.type) {
    case actionTypes.DATES_UPDATE:
        return {
            from: validateDate(action.payload.from),
            to: validateDate(action.payload.to),
        };

    default:
        return state;
    }
}
