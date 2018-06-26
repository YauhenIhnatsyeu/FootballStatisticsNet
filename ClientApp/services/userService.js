import {
    uploadAvatar,
    register as registerUser,
    login as loginUser,
    logout as logoutUser,
} from "Clients/userClient";
import keys from "Constants/keys";
import tryExtractJsonFromResponse from "Helpers/jsonHelper";
import { setValue, setJSONValue, removeValue } from "Helpers/localStorageHelper";

export function* register(user) {
    if (user) {
        if (user.avatar && user.avatar[0]) {
            const avatarResponse = yield uploadAvatar(user.avatar[0]);

            if (avatarResponse.ok) {
                const json = yield tryExtractJsonFromResponse(avatarResponse);

                if (json && json.avatarId) {
                    const registerResponse = yield registerUser(user, json.avatarId);
                    return registerResponse.ok;
                }
            }
        } else {
            const registerResponse = yield registerUser(user);
            return registerResponse.ok;
        }
    }

    return false;
}

export function* login(user) {
    const response = yield loginUser(user);

    if (response.ok) {
        const json = yield tryExtractJsonFromResponse(response);
        if (json && json.user && json.token) {
            setJSONValue(keys.user, json.user);
            setValue(keys.token, json.token);
            return json.user;
        }
    }

    return null;
}

export function* logout() {
    yield logoutUser();

    removeValue(keys.user);
    removeValue(keys.token);
}
