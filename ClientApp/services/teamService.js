import { fetchTeam as getTeam } from "Clients/footballApiClient";

export default function* fetchTeam(teamId) {
    const team = yield getTeam(teamId);
    team.id = teamId;
    return team;
}
