import { fetchTeams as getTeams } from "Clients/footballApiClient";
import { addIdsToTeams } from "Utilities/addIdsToTeams";
import httpToHttps from "Utilities/httpToHttps";

export default async function fetchTeams(leaguesIds) {
    const getTeamsPromises = leaguesIds.map(async (id) => {
        const { teams } = await getTeams(id);
        return teams;
    });

    const allTeams = await Promise.all(getTeamsPromises)
        .then(teams => Array.prototype.concat(...teams));

    addIdsToTeams(allTeams);

    for (let i = 0; i < allTeams.length; i += 1) {
        allTeams[i].crestUrl = httpToHttps(allTeams[i].crestUrl);
    }

    return allTeams;
}
