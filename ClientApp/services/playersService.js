import { fetchPlayers as getPlayers } from "Clients/footballApiClient";

import sorterByJerseyNumber from "Utilities/sorterByJerseyNumber";

export default function* fetchPlayers(playersUrl) {
    const playersData = yield getPlayers(playersUrl);
    const { players } = playersData;
    return players.sort(sorterByJerseyNumber);
}
