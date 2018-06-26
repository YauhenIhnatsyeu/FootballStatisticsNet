import { fetchTeams as getTeams } from "Clients/footballApiClient";
import { addIdsToTeams } from "Utilities/addIdsToTeams";
import httpToHttps from "Utilities/httpToHttps";

export default async function fetchTeams(leagueId) {
    const teamsData = await getTeams(leagueId);
    const { teams } = teamsData;

    addIdsToTeams(teams);
    for (let i = 0; i < teams.length; i += 1) {
        teams[i].crestUrl = httpToHttps(teams[i].crestUrl);
    }

    return teams;
}
