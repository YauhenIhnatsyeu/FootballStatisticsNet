import uploadAvatar from "Clients/avatarClient";

import tryExtractJsonFromResponse from "Helpers/jsonHelper";

export async function fetchFunction(fetchFunc, ...param) {
    const response = await fetchFunc(...param);
    return response.ok;
}

export async function fetchFunctionWithOptionalAvatar(fetchFunc, avatar, ...param) {
    if (avatar) {
        // If user wants to upload avatar
        const avatarResponse = await uploadAvatar(avatar);

        if (avatarResponse.ok) {
            const json = await tryExtractJsonFromResponse(avatarResponse);

            if (json && json.avatarId) {
                return fetchFunction(fetchFunc, ...param, json.avatarId);
            }
        }
    } else {
        // If user doesn't want to upload avatar
        return fetchFunction(fetchFunc, ...param);
    }

    return false;
}
