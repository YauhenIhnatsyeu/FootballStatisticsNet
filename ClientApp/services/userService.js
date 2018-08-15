import {
    register as registerUser,
    login as loginUser,
    logout as logoutUser,
} from "Clients/userClient";
import uploadAvatar from "Clients/avatarClient";
import keys from "Constants/keys";
import { setValue, setJSONValue, removeValue } from "Helpers/localStorageHelper";

export async function register(user) {
    let avatarJson;

    if (user.avatar && user.avatar[0]) {
        avatarJson = await uploadAvatar(user.avatar[0]);
    }

    await registerUser(user, avatarJson && avatarJson.avatarId);
}

export async function login(user) {
    const json = await loginUser(user);

    setJSONValue(keys.user, json.user);
    setValue(keys.token, json.token);

    return json.user;
}

export async function logout() {
    await logoutUser();

    removeValue(keys.user);
    removeValue(keys.token);
}
