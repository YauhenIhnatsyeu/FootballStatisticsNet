export function createLeagueUrl(leagueId) {
    return `/api/football/league/${leagueId}/tables`;
}

export function createTeamsUrl(leagueId) {
    return `/api/football/league/${leagueId}/teams`;
}

export function createTeamUrl(teamId) {
    return `/api/football/teams/${teamId}`;
}

export function createPlayersUrl(teamId) {
    return `/api/football/teams/${teamId}/players`;
}

export function createTweetsUrl(word) {
    return `/api/tweets/${word}`;
}

export function createFixturesUrl(teamId, dateFrom, dateTo) {
    return `/api/football/teams/${teamId}/fixtures/${dateFrom}/${dateTo}`;
}

export function createHead2HeadUrl(fixtureId) {
    return `/api/football/fixtures/${fixtureId}/head-to-head`;
}
