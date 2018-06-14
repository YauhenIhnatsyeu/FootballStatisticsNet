import { fetchTeams as getTeams } from "Clients/footballApiClient";
import { addIdsToTeams } from "Utilities/addIdsToTeams";

export default function* fetchTeams(leagueId) {
    const teamsData = yield getTeams(leagueId);
    const { teams } = teamsData;
    addIdsToTeams(teams);
    return teams;
}
