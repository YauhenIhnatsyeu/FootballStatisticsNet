import actionTypes from "ActionTypes";

import millisecondsValues from "Constants/millisecondsValues";

const from = new Date();
const to = new Date(from.getTime() + millisecondsValues.twoWeeks);

const initialState = { from, to };

export default function dates(state = initialState, action) {
    switch (action.type) {
    case actionTypes.DATES_UPDATE:
        return action.payload;

    default:
        return state;
    }
}
