import { fetchJson } from "Helpers/ajaxHelper";
import { dateToString } from "Utilities/castDate";

import {
    createLeagueUrl,
    createTeamsUrl,
    createTeamUrl,
    createPlayersUrl,
    createFixturesUrl,
    createHead2HeadUrl,
} from "Helpers/fetchingUrlsCreators";

export function fetchLeague(leagueId) {
    const leagueUrl = createLeagueUrl(leagueId);
    return fetchJson(leagueUrl);
}

export function fetchTeams(leagueId) {
    const teamsUrl = createTeamsUrl(leagueId);
    return fetchJson(teamsUrl);
}

export function fetchTeam(teamId) {
    const teamUrl = createTeamUrl(teamId);
    return fetchJson(teamUrl);
}

export function fetchPlayers(teamId) {
    const playersUrl = createPlayersUrl(teamId);
    return fetchJson(playersUrl);
}

export function fetchFixtures(teamId, dates) {
    const fixturesUrl = createFixturesUrl(
        teamId,
        dateToString(dates.from),
        dateToString(dates.to),
    );
    return fetchJson(fixturesUrl);
}

export function fetchHead2Head(fixtureId) {
    console.log(fixtureId);
    const head2HeadUrl = createHead2HeadUrl(fixtureId);
    console.log(head2HeadUrl);
    return fetchJson(head2HeadUrl);
}
