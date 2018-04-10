import fetchUrl from "Helpers/ajaxHelper";

import {
    createLeagueUrl,
    createTeamsUrl,
    createTeamUrl,
    createFixturesUrl,
    createHead2HeadUrl,
} from "Utilities/fetchingUrlsCreators";

export function* fetchLeague(leagueId) {
    const leagueUrl = createLeagueUrl(leagueId);
    return yield fetchUrl(leagueUrl);
}

export function* fetchTeams(leagueId) {
    const teamsUrl = createTeamsUrl(leagueId);
    return yield fetchUrl(teamsUrl);
}

export function* fetchTeam(teamId) {
    const teamUrl = createTeamUrl(teamId);
    return yield fetchUrl(teamUrl);
}

export function* fetchPlayers(playersUrl) {
    return yield fetchUrl(playersUrl);
}

export function* fetchFixtures(teamId) {
    const fixturesUrl = createFixturesUrl(teamId);
    return yield fetchUrl(fixturesUrl);
}

export function* fetchHead2Head(fixtureId) {
    const fixturesUrl = createHead2HeadUrl(fixtureId);
    return yield fetchUrl(fixturesUrl);
}
