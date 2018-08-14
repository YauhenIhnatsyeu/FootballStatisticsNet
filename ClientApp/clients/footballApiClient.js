import { fetchFootballUrl } from "Helpers/ajaxHelper";
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
    return fetchFootballUrl(leagueUrl);
}

export function fetchTeams(leagueId) {
    const teamsUrl = createTeamsUrl(leagueId);
    return fetchFootballUrl(teamsUrl);
}

export function fetchTeam(teamId) {
    const teamUrl = createTeamUrl(teamId);
    return fetchFootballUrl(teamUrl);
}

export function fetchPlayers(teamId) {
    const playersUrl = createPlayersUrl(teamId);
    return fetchFootballUrl(playersUrl);
}

export function fetchFixtures(teamId, dates) {
    const fixturesUrl = createFixturesUrl(
        teamId,
        dateToString(dates.from),
        dateToString(dates.to),
    );
    console.log(fixturesUrl);
    return fetchFootballUrl(fixturesUrl);
}

export function fetchHead2Head(fixtureId) {
    const fixturesUrl = createHead2HeadUrl(fixtureId);
    return fetchFootballUrl(fixturesUrl);
}
