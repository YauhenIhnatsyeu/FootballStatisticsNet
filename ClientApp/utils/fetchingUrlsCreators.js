export function createLeagueUrl(leagueId) {
    return `//api.football-data.org/v1/competitions/${leagueId}/leagueTable`;
}

export function createTeamsUrl(leagueId) {
    return `//api.football-data.org/v1/competitions/${leagueId}/teams`;
}

export function createTeamUrl(teamId) {
    return `//api.football-data.org/v1/teams/${teamId}`;
}

export function createFixturesUrl(teamId) {
    return `//api.football-data.org/v1/teams/${teamId}/fixtures`;
}

export function createHead2HeadUrl(fixtureId) {
    return `//api.football-data.org/v1/fixtures/${fixtureId}?head2head=10`;
}
