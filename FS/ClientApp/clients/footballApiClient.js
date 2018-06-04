import { fetchFootballUrl } from "Helpers/ajaxHelper";

import {
    createLeagueUrl,
    createTeamsUrl,
    createTeamUrl,
    createFixturesUrl,
    createHead2HeadUrl,
} from "Utilities/fetchingUrlsCreators";

export function* fetchLeague(leagueId) {
    const leagueUrl = createLeagueUrl(leagueId);
    return yield fetchFootballUrl(leagueUrl);
}

export function* fetchTeams(leagueId) {
    const teamsUrl = createTeamsUrl(leagueId);
    return yield fetchFootballUrl(teamsUrl);
}

export function* fetchTeam(teamId) {
    const teamUrl = createTeamUrl(teamId);
    return yield fetchFootballUrl(teamUrl);
}

export function* fetchPlayers(playersUrl) {
    return yield fetchFootballUrl(playersUrl);
}

export function* fetchFixtures(teamId) {
    const fixturesUrl = createFixturesUrl(teamId);
    return yield fetchFootballUrl(fixturesUrl);
}

export function* fetchHead2Head(fixtureId) {
    const fixturesUrl = createHead2HeadUrl(fixtureId);
    return yield fetchFootballUrl(fixturesUrl);
}
