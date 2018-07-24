import {
    create as createFanClub,
    fetch as getFanClubs,
} from "Clients/fanClubClient";

import tryExtractJsonFromResponse from "Helpers/jsonHelper";

import { fetchFunctionWithOptionalAvatar } from "Services/fetchService";

export async function create(fanClub) {
    return fetchFunctionWithOptionalAvatar(
        createFanClub,
        fanClub.avatar && fanClub.avatar[0],
        fanClub,
    );
}

export async function fetch() {
    const response = await getFanClubs();

    if (response.ok) {
        const json = await tryExtractJsonFromResponse(response);
        if (json) {
            return json;
        }
    }

    return null;
}
