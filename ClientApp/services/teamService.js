import { fetchTeam as getTeam } from "Clients/footballApiClient";
import httpToHttps from "Utilities/httpToHttps";

export default function* fetchTeam(teamId) {
    const team = yield getTeam(teamId);

    team.id = teamId;
    team.crestUrl = httpToHttps(team.crestUrl);
    team._links.players.href = httpToHttps(team._links.players.href);
    team._links.fixtures.href = httpToHttps(team._links.fixtures.href);

    return team;
}
