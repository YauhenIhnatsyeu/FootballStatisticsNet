import actionTypes from "../actions/actionTypes";

const from = new Date();
const to = new Date(from.getTime() + 1209600000);

const initialState = { from, to };

export default function dates(state = initialState, action) {
    switch (action.type) {
    case actionTypes.FROM_DATE_UPDATE_REQUESTED:
        return { ...state, from: action.payload };

    case actionTypes.TO_DATE_UPDATE_REQUESTED:
        return { ...state, to: action.payload };

    default:
        return state;
    }
}
