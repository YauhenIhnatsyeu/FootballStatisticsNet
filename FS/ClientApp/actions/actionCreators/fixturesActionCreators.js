import actionTypes from "ActionTypes";

export function fetchFixtures(teamId, dates) {
    return {
        type: actionTypes.FIXTURES_FETCH_REQUESTED,
        payload: { teamId, dates },
    };
}

export function onFixturesFetchSucceeded(data) {
    return {
        type: actionTypes.FIXTURES_FETCH_SUCCEEDED,
        payload: data,
    };
}

export function onFixturesFetchFailed(error) {
    return {
        type: actionTypes.FIXTURES_FETCH_FAILED,
        payload: error,
    };
}

export function updateFixtureIndex(index) {
    return {
        type: actionTypes.FIXTURE_INDEX_UPDATE,
        payload: index,
    };
}
