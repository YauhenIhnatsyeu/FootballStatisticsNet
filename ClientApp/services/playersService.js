import { fetchPlayers as getPlayers } from "Clients/footballApiClient";

import sorterByJerseyNumber from "Utilities/sorterByJerseyNumber";

export default async function fetchPlayers(playersUrl) {
    const playersData = await getPlayers(playersUrl);
    const { players } = playersData;
    return players.sort(sorterByJerseyNumber);
}
