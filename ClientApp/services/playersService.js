import { fetchPlayers as getPlayers } from "Clients/footballApiClient";

import sorterByJerseyNumber from "Utilities/sorterByJerseyNumber";

export default async function fetchPlayers(teamId) {
    const playersData = await getPlayers(teamId);
    const { players } = playersData;
    return players.sort(sorterByJerseyNumber);
}
