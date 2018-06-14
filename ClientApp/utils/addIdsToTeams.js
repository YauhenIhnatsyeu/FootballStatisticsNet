import extractIdFromUrl from "Utilities/extractIdFromUrl";

function addIdToTeam(teamParam, teamUrl) {
    const team = teamParam;
    team.id = extractIdFromUrl(teamUrl);
    return team;
}

export function addIdsToLeagueTeams(teams) {
    teams.map(team => addIdToTeam(team, team._links.team.href));
}

export function addIdsToTeams(teams) {
    teams.map(team => addIdToTeam(team, team._links.self.href));
}
