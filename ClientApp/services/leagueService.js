import { fetchLeague as getLeague } from "Clients/footballApiClient";
import { addIdsToLeagueTeams } from "Utilities/addIdsToTeams";

export default async function fetchLeague(leagueId) {
    const leagueData = await getLeague(leagueId);
    const { standing: league } = leagueData;
    addIdsToLeagueTeams(league);
    return league;
}
