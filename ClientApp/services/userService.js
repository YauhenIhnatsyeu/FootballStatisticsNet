import {
    uploadAvatar,
    register as registerUser,
    login as loginUser,
    logout as logoutUser,
} from "Clients/userClient";
import keys from "Constants/keys";
import tryExtractJsonFromResponse from "Helpers/jsonHelper";
import { setValue, setJSONValue, removeValue } from "Helpers/localStorageHelper";

export async function register(user) {
    if (user) {
        // If user wants to upload avatar
        if (user.avatar && user.avatar[0]) {
            const avatarResponse = await uploadAvatar(user.avatar[0]);

            if (avatarResponse.ok) {
                const json = await tryExtractJsonFromResponse(avatarResponse);

                if (json && json.avatarId) {
                    const registerResponse = await registerUser(user, json.avatarId);
                    return registerResponse.ok;
                }
            }
        // If user doesn't want to upload avatar
        } else {
            const registerResponse = await registerUser(user);
            return registerResponse.ok;
        }
    }

    return false;
}

export async function login(user) {
    const response = await loginUser(user);

    if (response.ok) {
        const json = await tryExtractJsonFromResponse(response);
        if (json && json.user && json.token) {
            setJSONValue(keys.user, json.user);
            setValue(keys.token, json.token);
            return json.user;
        }
    }

    return null;
}

export async function logout() {
    await logoutUser();

    removeValue(keys.user);
    removeValue(keys.token);
}
