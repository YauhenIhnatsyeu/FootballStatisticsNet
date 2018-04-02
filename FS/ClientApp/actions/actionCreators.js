import actionTypes from "./actionTypes";

export function fetchLeague(leagueId) {
    return {
        type: actionTypes.LEAGUE_FETCH_REQUESTED,
        payload: leagueId,
    };
}

export function onLeagueFetchSucceeded(data) {
    return {
        type: actionTypes.LEAGUE_FETCH_SUCCEEDED,
        payload: data,
    };
}


export function fetchTeams(leagueId) {
    return {
        type: actionTypes.TEAMS_FETCH_REQUESTED,
        payload: leagueId,
    };
}

export function onTeamsFetchSucceeded(data) {
    return {
        type: actionTypes.TEAMS_FETCH_SUCCEEDED,
        payload: data,
    };
}


export function fetchTeam(teamId) {
    return {
        type: actionTypes.TEAM_FETCH_REQUESTED,
        payload: teamId,
    };
}

export function onTeamFetchSucceeded(data) {
    return {
        type: actionTypes.TEAM_FETCH_SUCCEEDED,
        payload: data,
    };
}


export function fetchPlayers(teamUrl) {
    return {
        type: actionTypes.PLAYERS_FETCH_REQUESTED,
        payload: teamUrl,
    };
}

export function onPlayersFetchSucceeded(data) {
    return {
        type: actionTypes.PLAYERS_FETCH_SUCCEEDED,
        payload: data,
    };
}


export function fetchFixtures(teamId) {
    return {
        type: actionTypes.FIXTURES_FETCH_REQUESTED,
        payload: teamId,
    };
}

export function onFixturesFetchSucceeded(data) {
    return {
        type: actionTypes.FIXTURES_FETCH_SUCCEEDED,
        payload: data,
    };
}


export function fetchHead2Head(fixtureId) {
    return {
        type: actionTypes.HEAD_2_HEAD_FETCH_REQUESTED,
        payload: fixtureId,
    };
}

export function onHead2HeadFetchSucceeded(data) {
    return {
        type: actionTypes.HEAD_2_HEAD_FETCH_SUCCEEDED,
        payload: data,
    };
}


export function onFetchFailed(error) {
    return {
        type: actionTypes.FETCH_FAILED,
        payload: error,
    };
}


export function updateLeagueIndex(index) {
    return {
        type: actionTypes.LEAGUE_INDEX_UPDATE_REQUESTED,
        payload: index,
    };
}

export function updateTeamPageIndex(index) {
    return {
        type: actionTypes.TEAM_PAGE_INDEX_UPDATE_REQUESTED,
        payload: index,
    };
}

export function updatePlayersPageIndex(index) {
    return {
        type: actionTypes.PLAYERS_PAGE_INDEX_UPDATE_REQUESTED,
        payload: index,
    };
}

export function updateFixtureIndex(index) {
    return {
        type: actionTypes.FIXTURE_INDEX_UPDATE_REQUESTED,
        payload: index,
    };
}

export function updateFixturesPageIndex(index) {
    return {
        type: actionTypes.FIXTURES_PAGE_INDEX_UPDATE_REQUESTED,
        payload: index,
    };
}


export function resetTeamPageIndices() {
    return {
        type: actionTypes.TEAM_PAGE_INDICES_RESET_REQUESTED,
    };
}


export function addTeamToFavourites(teamId) {
    return {
        type: actionTypes.ADD_TEAM_TO_FAVOURITES_REQUESTED,
        payload: teamId,
    };
}

export function removeTeamFromFavourites(teamId) {
    return {
        type: actionTypes.REMOVE_TEAM_FROM_FAVOURITES_REQUESTED,
        payload: teamId,
    };
}


export function getTeamsFromFavourites() {
    return {
        type: actionTypes.GET_TEAMS_FROM_FAVOURITES_REQUESTED,
    };
}

export function onGetTeamsFromFavouritesSucceeded(teams) {
    return {
        type: actionTypes.GET_TEAMS_FROM_FAVOURITES_SUCCEEDED,
        payload: teams,
    };
}


export function updateFromDate(date) {
    return {
        type: actionTypes.FROM_DATE_UPDATE_REQUESTED,
        payload: date,
    };
}

export function updateToDate(date) {
    return {
        type: actionTypes.TO_DATE_UPDATE_REQUESTED,
        payload: date,
    };
}
