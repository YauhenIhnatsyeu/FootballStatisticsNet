import actionTypes from "ActionTypes";

const initialState = {
    team: null,
    teamPageIndex: 0,
};

export default function teamData(state = initialState, action) {
    switch (action.type) {
    case actionTypes.TEAM_FETCH_SUCCEEDED:
        return { ...state, team: action.payload };

    default:
        return state;
    }
}
