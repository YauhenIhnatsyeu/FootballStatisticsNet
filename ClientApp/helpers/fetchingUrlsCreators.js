export function createLeagueUrl(leagueId) {
    return `/api/football/leagues/${leagueId}`;
}

export function createTeamsUrl(leagueId) {
    return `//api.football-data.org/v1/competitions/${leagueId}/teams`;
}

export function createTeamUrl(teamId) {
    return `/api/football/teams/${teamId}`;
}

export function createPlayersUrl(teamId) {
    return `//api.football-data.org/v1/teams/${teamId}/players`;
}

export function createFixturesUrl(teamId, dateFrom, dateTo) {
    return `//api.football-data.org/v1/teams/${teamId}/fixtures?timeFrameStart=${dateFrom}&timeFrameEnd=${dateTo}`;
}

export function createHead2HeadUrl(fixtureId) {
    return `//api.football-data.org/v1/fixtures/${fixtureId}?head2head=10`;
}
