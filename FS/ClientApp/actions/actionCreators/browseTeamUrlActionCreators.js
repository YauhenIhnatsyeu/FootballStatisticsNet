import actionTypes from "ActionTypes";

export default function browseTeamUrl(currentPath, newPath, history) {
    return {
        type: actionTypes.BROWSE_TEAM_URL,
        payload: { currentPath, newPath, history },
    };
}
