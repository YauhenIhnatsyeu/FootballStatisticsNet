import actionTypes from "../actions/actionTypes";

const initialState = null;

export default function head2Head(state = initialState, action) {
    switch (action.type) {
    case actionTypes.HEAD_2_HEAD_FETCH_SUCCEEDED:
        return action.payload;

    default:
        return state;
    }
}
