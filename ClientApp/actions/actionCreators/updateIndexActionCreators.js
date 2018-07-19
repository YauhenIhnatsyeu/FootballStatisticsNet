import actionTypes from "ActionTypes";

export function updatePlayersPageIndex(index) {
    return {
        type: actionTypes.PLAYERS_PAGE_INDEX_UPDATE,
        payload: index,
    };
}

export function updateFixturesPageIndex(index) {
    return {
        type: actionTypes.FIXTURES_PAGE_INDEX_UPDATE,
        payload: index,
    };
}
