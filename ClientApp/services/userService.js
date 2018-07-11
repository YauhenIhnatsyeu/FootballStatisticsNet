import {
    register as registerUser,
    login as loginUser,
    logout as logoutUser,
} from "Clients/userClient";
import { fetchFunctionWithOptionalAvatar } from "Services/fetchService";
import keys from "Constants/keys";
import tryExtractJsonFromResponse from "Helpers/jsonHelper";
import { setValue, setJSONValue, removeValue } from "Helpers/localStorageHelper";

export async function register(user) {
    return fetchFunctionWithOptionalAvatar(
        registerUser,
        user.avatar && user.avatar[0],
        user,
    );
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
