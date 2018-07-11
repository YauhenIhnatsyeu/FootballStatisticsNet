import { create as createFanClub } from "Clients/fanClubClient";

import { fetchFunctionWithOptionalAvatar } from "Services/fetchService";

export async function create(fanClub) {
    return fetchFunctionWithOptionalAvatar(
        createFanClub,
        fanClub.avatar && fanClub.avatar[0],
        fanClub,
    );
}
